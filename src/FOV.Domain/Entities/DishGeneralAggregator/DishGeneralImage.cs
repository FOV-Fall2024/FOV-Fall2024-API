using System.ComponentModel.DataAnnotations.Schema;
using FOV.Domain.Common;

namespace FOV.Domain.Entities.DishGeneralAggregator;
public class DishGeneralImage : BaseAuditableEntity
{
    public DishGeneral DishGeneral { get; set; }
    public Guid? DishGeneralId { get; set; }
    public string Url { get; set; } = string.Empty;
    public int Order { get; set; }
    public DishGeneralImage()
    {

    }

    public DishGeneralImage(string url, Guid dishGeneralId)
    {
        DishGeneralId = dishGeneralId;
        Url = url;
    }

    public void UpdateImage(string imageUrl) => Url = imageUrl;
}
