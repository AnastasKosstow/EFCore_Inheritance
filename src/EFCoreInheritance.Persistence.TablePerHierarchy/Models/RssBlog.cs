namespace EFCoreInheritance.Persistence.TablePerHierarchy.Models;

public class RssBlog : Blog
{
    public override string GetBlogType()
        => GetType().Name;
}