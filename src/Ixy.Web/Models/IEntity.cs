namespace Ixy.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
