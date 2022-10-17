namespace Domain.Entities;

public class Todo : IAggregateRoot
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public Address? Address { get; set; }

    public DateTime? Reminder { get; set; }

    public Priority Priority { get; set; }

    public AuditInformation? AuditInformation { get; set; }
}
