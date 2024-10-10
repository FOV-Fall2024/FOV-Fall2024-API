using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Common;

public interface IsSoftDeleted
{
    public Status Status { get; set; }
}

