
namespace SharedProject.BaseEntities
{
    public abstract class BaseEntity<TEntityId>
    {
        public TEntityId Id { get; set; }
    }
}
