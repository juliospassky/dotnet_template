namespace Domain.Common;

public abstract class TraceInformation
{
    public string? TrueClientIp { get; set; }

    public string? XForwardedFor { get; set; }

    public string? Hostname { get; set; }

    public string? SessionFlowId { get; set; }

    public string? Xb3TraceId { get; set; }
}
