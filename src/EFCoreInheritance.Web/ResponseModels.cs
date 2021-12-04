namespace EFCoreInheritance.Web
{
    public interface IResponse
    {
    }

    public class TablePerHierarchyResponseModel : IResponse
    {
        public object Result { get; set; }
    }

    public class TablePerTypeResponseModel : IResponse
    {
        public object Info { get; set; }
        public string TypeName { get; set; }
    }
}
