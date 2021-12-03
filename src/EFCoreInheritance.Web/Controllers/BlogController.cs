using EFCoreInheritance.Web.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreInheritance.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ITablePerHierarchyService _tablePerHierarchyService;
        private readonly ITablePerTypeService _tablePerTypeService;


        public BlogController(
            ITablePerHierarchyService tablePerHierarchyService,
            ITablePerTypeService tablePerTypeService)
        {
            _tablePerHierarchyService = tablePerHierarchyService;
            _tablePerTypeService = tablePerTypeService;
        }

        [HttpGet]
        [Route("TPH")]
        public async Task<TablePerHierarchyResponseModel> GetTablePerHierarchyExampleResult(
            CancellationToken cancellationToken)
        {
            return await _tablePerHierarchyService.GetResult<TablePerHierarchyResponseModel>(cancellationToken);
        }

        [HttpGet]
        [Route("TPT")]
        public async Task<TablePerTypeResponseModel> GetTablePerTypeExampleResult(
            CancellationToken cancellationToken)
        {
            return await _tablePerTypeService.GetResult<TablePerTypeResponseModel>(cancellationToken);
        }

        //[HttpGet]
        //public async Task<ResponseModel> Get(
        //    RequestModel requestModel,
        //    CancellationToken cancellationToken)
        //{

        //    BankAccount ba = new BankAccount()
        //    {
        //        Number = "98765432111111111",
        //        Owner = "AB1111111",
        //        BankName = "THEBANK1111111111",
        //        Swift = "swift111111111"
        //    };
        //    _context.BillingDetails.Add(ba);
        //    _context.SaveChanges();
        //    User user = new User()
        //    {
        //        FirstName = "211111111",
        //        LastName = "111111",
        //        BillingInfo = ba,
        //    };

        //    _context.Users.Add(user);
        //    _context.SaveChanges();

        //    var user2 = _context.Users.FirstOrDefault(x => x.Id == 1);
        //    var details = user2.BillingInfo;

        //    var details2 = user2.BillingInfo as CreditCard;

        //    return null;
        //    //return await GetFromDb(requestModel, cancellationToken);
        //}


        //private async Task<ResponseModel> GetFromDb(
        //    RequestModel requestModel,
        //    CancellationToken cancellationToken)
        //{
        //    var blog = await _context?.Blogs?.FirstOrDefaultAsync(
        //            x => x.Id == requestModel.Id,
        //            cancellationToken);

        //    return new ResponseModel()
        //    {
        //        Result = blog.GetBlogType()
        //    };
        //}
    }
}
