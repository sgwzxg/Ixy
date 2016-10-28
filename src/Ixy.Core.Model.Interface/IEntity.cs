namespace Ixy.Core.Model.Interface
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
