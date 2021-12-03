using EFCoreInheritance.Web.Services.Abstractions;

namespace EFCoreInheritance.Web.Services
{
    public class TablePerTypeService : ITablePerTypeService
    {
        public Task<TResponseModel> GetResult<TResponseModel>(CancellationToken cancellationToken) 
            where TResponseModel : IResponse, new()
        {
            throw new NotImplementedException();
        }
    }
}
