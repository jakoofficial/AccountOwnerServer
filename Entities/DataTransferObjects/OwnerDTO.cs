namespace Entities.DataTransferObjects;

public class OwnerDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Address { get; set; }
}