namespace EFCoreInheritance.ContextAccessor;

public class ContextAccessor<TContext> : IContextAccessor<TContext>
{
    private static readonly AsyncLocal<ContextHolder> _context = new();

    public TContext Context
    {
        get
        {
            if (_context.Value == null)
            {
                return default(TContext) 
                    ?? throw new ArgumentNullException(nameof(ContextAccessor));
            }

            return _context.Value.Context 
                ?? throw new ArgumentNullException(nameof(ContextAccessor));
        }
        set
        {
            var httpContextHolder = _context.Value;
            if (httpContextHolder != null)
                httpContextHolder.Context = default;
            if (value == null)
                return;

            _context.Value = new ContextHolder
            {
                Context = value
            };
        }
    }

    private class ContextHolder
    {
        public TContext? Context;
    }
}
