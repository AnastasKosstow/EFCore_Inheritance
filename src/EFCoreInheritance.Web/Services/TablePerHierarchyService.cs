using EFCoreInheritance.Persistence.TablePerHierarchy;
using EFCoreInheritance.Persistence.TablePerHierarchy.Models;
using EFCoreInheritance.Web.Factory;
using EFCoreInheritance.Web.Factory.Utils;
using EFCoreInheritance.Web.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Web.Services
{
    public class TablePerHierarchyService : ITablePerHierarchyService
    {
        private readonly TablePerHierarchyDbContext _context;
        private readonly IResponseModelFactory _responseModelFactory;

        public TablePerHierarchyService(
            TablePerHierarchyDbContext context, 
            IResponseModelFactory responseModelFactory)
        {
            _context = context;
            _responseModelFactory = responseModelFactory;
        }

        public async Task<IResponse> GetResult(CancellationToken cancellationToken)
        {
            if (!_context.Blogs.Any())
            {
                await AddInitialData();
            }

            // To get all by Type: _context.Blogs.OfType<EFBlog>()

            var blog = await _context
                .Blogs?
                .FirstOrDefaultAsync(cancellationToken);

            return _responseModelFactory.CreateResponseObject(ResponseObjectType.TPH, blog.GetBlogType());
        }

        #region InitialData
        private Task AddInitialData()
        {
            Blog blogToAdd = new EFBlog
            {
                Discriminator = BlogType.EF
            };

            _context.Blogs.Add(blogToAdd);
            return Task.FromResult(
                _context.SaveChanges());
        }
        #endregion
    }
}
