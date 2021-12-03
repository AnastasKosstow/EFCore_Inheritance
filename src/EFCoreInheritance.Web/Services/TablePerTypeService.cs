using EFCoreInheritance.Persistence.TablePerType;
using EFCoreInheritance.Persistence.TablePerType.Models;
using EFCoreInheritance.Web.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Web.Services
{
    public class TablePerTypeService : ITablePerTypeService
    {
        private readonly TablePerTypeDbContext _context;

        public TablePerTypeService(TablePerTypeDbContext context)
        {
            _context = context;
        }

        public async Task<TResponseModel> GetResult<TResponseModel>(CancellationToken cancellationToken) 
            where TResponseModel : class, new()
        {
            var billingInfo = (await _context
                .Users?
                .FirstOrDefaultAsync(cancellationToken))
                .BillingInfo as BankAccount;

            return (TResponseModel)Convert.ChangeType(
                new TablePerTypeResponseModel
                {
                    Info = billingInfo,
                    TypeName = billingInfo.GetType().Name
                },
                typeof(TResponseModel));
        }
    }
}
