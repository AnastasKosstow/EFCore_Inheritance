namespace EFCoreInheritance.Web.Services.Abstractions
{
    public interface IService
    {
        Task<TResponseModel> GetResult<TResponseModel>(CancellationToken cancellationToken)
             where TResponseModel : class, new();
    }
}
