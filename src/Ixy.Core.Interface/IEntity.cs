namespace Ixy.Core.Interface
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
