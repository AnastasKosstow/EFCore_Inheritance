﻿
namespace EFCoreInheritance.Persistence.Models
{
    public class EFBlog : Blog
    {
        public override string GetBlogType() 
            => GetType().Name;
    }
}
