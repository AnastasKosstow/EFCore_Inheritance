using EFCoreInheritance.Web.Factory.Utils;

namespace EFCoreInheritance.Web.Factory
{
    public interface IResponseModelFactory
    {
        IResponse CreateResponseObject(ResponseObjectType responseObjectType, params object[] parameters);
    }
}
