
namespace EFCoreInheritance.Persistence.Models
{
    public class RssBlog : Blog
    {
        public override string GetBlogType() 
            => GetType().Name;
    }
}