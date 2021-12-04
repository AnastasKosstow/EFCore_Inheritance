namespace EFCoreInheritance.Web
{
    public interface IResponse
    {
    }

    /*
     * Just for testing!
     * These methods of adding data do not follow any good practices!!!
     */
    public class TablePerHierarchyResponseModel : IResponse
    {
        public TablePerHierarchyResponseModel(object[] responseData)
        {
            Result = responseData[0];
        }

        public object Result { get; set; }
    }

    public class TablePerTypeResponseModel : IResponse
    {
        public TablePerTypeResponseModel(object[] responseData)
        {
            Info = responseData[0];
            TypeName = responseData[1];
        }

        public object Info { get; set; }
        public object TypeName { get; set; }
    }
}
