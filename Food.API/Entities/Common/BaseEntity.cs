using System.ComponentModel.DataAnnotations;

namespace Food.API.Entities.Common;

public interface IEntity
{

}
public interface IEntity<TKey>:IEntity
{
    [Key]
    TKey Id { get; set; }
     DateTime CreatedDateTime { get; set; }
     DateTime? ModifiedDateTime { get; set; }
     bool IsActive { get; set; } 

}

public abstract class BaseEntity<TKey> : IEntity<TKey>
{
    [Key]
    
    public TKey Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
    public bool IsActive { get; set; } = true;

    protected BaseEntity()
    {
        CreatedDateTime= DateTime.UtcNow;
    }
}
public abstract class BaseEntity : BaseEntity<Guid>
{
}