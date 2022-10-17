namespace Application.Adapter.Rest.Contract.Request;

public class TodoRequest
{
    public string? Title { get; set; }

    public string? Note { get; set; }

    public Address? Address { get; set; }

    public DateTime? Reminder { get; set; }

    public Priority Priority { get; set; }
}
