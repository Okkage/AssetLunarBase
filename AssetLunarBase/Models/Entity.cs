namespace AssetLunarBase.Models;

public abstract class Entity
{
    public Guid Id { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    public void Update() => UpdatedAt = DateTime.UtcNow;
    
    protected Entity()
    {
        Id = Guid.NewGuid();                         
    }
}