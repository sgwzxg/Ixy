namespace Ixy.Core.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
