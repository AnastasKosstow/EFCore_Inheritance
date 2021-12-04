using EFCoreInheritance.Persistence.TablePerType;
using EFCoreInheritance.Persistence.TablePerType.Models;
using EFCoreInheritance.Web.Factory;
using EFCoreInheritance.Web.Factory.Utils;
using EFCoreInheritance.Web.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Web.Services
{
    public class TablePerTypeService : ITablePerTypeService
    {
        private readonly TablePerTypeDbContext _context;
        private readonly IResponseModelFactory _responseModelFactory;

        public TablePerTypeService(
            TablePerTypeDbContext context,
            IResponseModelFactory responseModelFactory)
        {
            _context = context;
            _responseModelFactory = responseModelFactory;
        }

        public async Task<IResponse> GetResult(CancellationToken cancellationToken)
        {
            if (!_context.Users.Any())
            {
                await AddInitialData();
            }

            // To get all by Type: _context.Users.OfType<BankAccount>()

            var bankAccount = (await _context
                .Users?
                .FirstOrDefaultAsync(cancellationToken))
                .BillingInfo as BankAccount;

            return _responseModelFactory.CreateResponseObject
                (ResponseObjectType.TPT, 
                bankAccount.BankName, 
                bankAccount.GetType().Name);
        }

        #region InitialData
        private Task AddInitialData()
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
            return Task.FromResult(_context.SaveChanges());
        }
        #endregion
    }
}
