namespace Entities.Models;

public class ShapedEntity : TableBase
{
    public Guid Id { get; set; }
    public Entity Entity { get; set; }
    
    public ShapedEntity()
    {
        Entity = new Entity();
    }
}