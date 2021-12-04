using EFCoreInheritance.Web.Factory.Utils;

namespace EFCoreInheritance.Web.Factory
{
    public abstract class FactoryBase
    {
        protected IDictionary<ResponseObjectType, Func<IResponse>> Responses = CreateResponseObjectMap();

        private static IDictionary<ResponseObjectType, Func<IResponse>> CreateResponseObjectMap()
        {
            return new Dictionary<ResponseObjectType, Func<IResponse>>()
            {
                { ResponseObjectType.TPH, () => new TablePerHierarchyResponseModel() },
                { ResponseObjectType.TPT, () => new TablePerTypeResponseModel() },
            };
        }
    }
}
