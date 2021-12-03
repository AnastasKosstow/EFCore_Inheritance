using EFCoreInheritance.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInheritance.Web.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    //public class BlogController : ControllerBase
    //{
    //    private readonly EFCoreInheritanceDbContext _context;

    //    public BlogController(EFCoreInheritanceDbContext context)
    //        => _context = context;

    //    [HttpGet]
    //    public async Task<ResponseModel> Get(
    //        RequestModel requestModel,
    //        CancellationToken cancellationToken)
    //        =>
    //        await GetFromDb(requestModel, cancellationToken);


    //    private async Task<ResponseModel> GetFromDb(
    //        RequestModel requestModel,
    //        CancellationToken cancellationToken)
    //    {
    //        var blog = await _context?.Blogs?.FirstOrDefaultAsync(
    //                x => x.Id == requestModel.Id,
    //                cancellationToken);

    //        return new ResponseModel()
    //        {
    //            Result = blog.GetBlogType()
    //        };
    //    }
    //}

    #region RequestResponseModels
    public class RequestModel
    {
        public int? Id { get; set; }
    }
    public class ResponseModel
    {
        public string? Result { get; set; }
    }
    #endregion
}
