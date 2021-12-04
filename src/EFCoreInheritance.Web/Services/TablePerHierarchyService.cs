using EFCoreInheritance.Persistence.TablePerHierarchy;
using EFCoreInheritance.Persistence.TablePerHierarchy.Models;
using EFCoreInheritance.Web.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Web.Services
{
    public class TablePerHierarchyService : ITablePerHierarchyService
    {
        private readonly TablePerHierarchyDbContext _context;

        public TablePerHierarchyService(TablePerHierarchyDbContext context)
        {
            _context = context;
        }

        public async Task<TResponseModel> GetResult<TResponseModel>(CancellationToken cancellationToken)
            where TResponseModel : class, new()
        {
            if (!_context.Blogs.Any())
            {
                Blog blogToAdd = new EFBlog
                {
                    Discriminator = BlogType.EF
                };

                _context.Blogs.Add(blogToAdd);
                _context.SaveChanges();
            }

            // Get all by Type
            var all = await _context
                .Blogs?
                .OfType<EFBlog>()
                .ToListAsync(cancellationToken);

            // Get single as parent object, or cast it
            var blog = await _context
                .Blogs?
                .FirstOrDefaultAsync(cancellationToken);

            return (TResponseModel)Convert.ChangeType(
                new TablePerHierarchyResponseModel
                {
                    Result = blog.GetBlogType()
                }, 
                typeof(TResponseModel));
        }
    }
}
