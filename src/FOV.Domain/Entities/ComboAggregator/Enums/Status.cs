using System.Text.Json.Serialization;

namespace FOV.Domain.Entities.ComboAggregator.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ComboStatus : byte
{
    InStock = 0,
    OutOfStock = 1,
}
