using EFCoreInheritance.Web.Factory.Utils;

namespace EFCoreInheritance.Web.Factory
{
    public class ResponseModelFactory : FactoryBase, IResponseModelFactory
    {
        public IResponse CreateHttpRequest(ResponseObjectType responseObjectType)
        {
            Responses.TryGetValue(responseObjectType, out var responseProvider);
            if (responseProvider is null)
                throw new NotSupportedException("No provider found!");

            return responseProvider();
        }
    }
}
