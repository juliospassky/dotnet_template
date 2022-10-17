namespace Domain.Common;

public class AuditInformation
{
    public DateTime? CreationDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public ChannelData? ChannelData { get; set; }

    public TraceInformation? TraceInformation { get; set; }
}

