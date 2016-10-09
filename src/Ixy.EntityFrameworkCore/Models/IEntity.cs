namespace Ixy.EntityFrameworkCore.Models
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
