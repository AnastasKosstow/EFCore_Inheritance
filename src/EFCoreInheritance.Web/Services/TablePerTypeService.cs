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
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    FirstName = "A",
                    LastName = "K",
                    BillingInfo = new BankAccount()
                    {
                        Number = "9876543210",
                        Owner = "A/K",
                        BankName = "theBank",
                    },
                });
                _context.SaveChanges();
            }

            // Get all by Type
            var bankAccouns = await _context.Users
                .OfType<BankAccount>()
                .ToListAsync(cancellationToken);

            // Get single as parent object, or cast it
            var billingInfo = (await _context
                .Users?
                .FirstOrDefaultAsync(cancellationToken))
                .BillingInfo;

            // Check is BillingDetail object is of Type BankAccount
            var isBankAccount = billingInfo is BankAccount;

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
