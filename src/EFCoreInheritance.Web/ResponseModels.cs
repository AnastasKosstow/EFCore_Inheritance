namespace EFCoreInheritance.Web
{
    public class TablePerHierarchyResponseModel
    {
        public object Result { get; set; }
    }

    public class TablePerTypeResponseModel
    {
        public object Info { get; set; }
        public string TypeName { get; set; }
    }
}
