namespace BookStore.DAL.Interfaces
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
