namespace BlogAPI.Models.Common;

public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string? CreatedAt { get; set; } = DateTime.UtcNow.ToString();

    public string? UpdatedAt { get; set; } 

    public string? DeletedAt { get; set; }


}