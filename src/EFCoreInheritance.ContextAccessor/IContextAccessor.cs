namespace EFCoreInheritance.ContextAccessor;

public interface IContextAccessor<TContext>
{
    TContext Context { get; set; }
}
