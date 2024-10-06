using System.Globalization;

namespace FOV.Domain.Common;

public static class DefaultDatetime
{
    // Minimum value for DateTime
    public static readonly DateTime MinValue = DateTime.SpecifyKind(
       DateTime.ParseExact("12-12-2002", "MM-dd-yyyy", CultureInfo.InvariantCulture),
       DateTimeKind.Utc
   );

}
