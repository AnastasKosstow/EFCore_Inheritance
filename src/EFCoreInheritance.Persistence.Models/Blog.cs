﻿
namespace EFCoreInheritance.Persistence.Models
{
    public abstract class Blog
    {
        public int Id { get; set; }

        public BlogType Discriminator { get; set; }

        public abstract string GetBlogType();
    }
}
