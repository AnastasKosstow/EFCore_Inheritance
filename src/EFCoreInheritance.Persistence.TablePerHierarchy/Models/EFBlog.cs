namespace EFCoreInheritance.Persistence.TablePerHierarchy.Models;

public class EFBlog : Blog
{
    public override string GetBlogType()
        => GetType().Name;
}
