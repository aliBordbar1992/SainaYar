namespace SainaYar.SharedKernel.Shared
{
    public abstract class AggregateRoot<TId> : Entity<TId>
    {
        protected AggregateRoot(TId id) : base(id) {}
    }
}
