using EFCoreInheritance.ContextAccessor;
using EFCoreInheritance.Persistence.TablePerHierarchy;
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
