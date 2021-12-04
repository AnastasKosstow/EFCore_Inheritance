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
        public async Task<IResponse> GetTablePerHierarchyExampleResult(
            CancellationToken cancellationToken)
        {
            return await _tablePerHierarchyService.GetResult(cancellationToken);
        }

        [HttpGet]
        [Route("TPT")]
        public async Task<IResponse> GetTablePerTypeExampleResult(
            CancellationToken cancellationToken)
        {
            return await _tablePerTypeService.GetResult(cancellationToken);
        }
    }
}
