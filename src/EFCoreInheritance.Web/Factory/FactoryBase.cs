using EFCoreInheritance.Web.Factory.Utils;

namespace EFCoreInheritance.Web.Factory
{
    public abstract class FactoryBase
    {
        protected IDictionary<ResponseObjectType, Func<object[], IResponse>> Responses = CreateResponseObjectMap();

        private static IDictionary<ResponseObjectType, Func<object[], IResponse>> CreateResponseObjectMap()
        {
            return new Dictionary<ResponseObjectType, Func<object[], IResponse>>()
            {
                { ResponseObjectType.TPH, responseData => new TablePerHierarchyResponseModel(responseData) },
                { ResponseObjectType.TPT, responseData => new TablePerTypeResponseModel(responseData) },
            };
        }
    }
}
