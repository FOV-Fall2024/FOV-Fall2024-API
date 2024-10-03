using FOV.Domain.Common;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;

namespace FOV.Domain.Entities.TableAggregator;
public class Table : BaseAuditableEntity, IsSoftDeleted
{
    public int TableNumber { get; set; }
    public string? TableCode { get; set; }
    public TableStatus TableStatus { get; set; }
    public string? TableQRCode { get; set; }
    public bool IsDeleted { get; set; }
    public Restaurant? Restaurant { get; set; }
    public Guid RestaurantId { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = [];

    public Table()
    {

    }

    public Table(TableStatus tableStatus)
    {
        this.TableStatus = tableStatus;
    }
    public void Update(int tableNumber, string tableCode, TableStatus tableStatus, string TableQRCode)
    {
        this.TableNumber = tableNumber;
        this.TableCode = tableCode;
        this.TableStatus = tableStatus;
        this.TableQRCode = TableQRCode;
    }
    public void UpdateState(bool state) => IsDeleted = state;
}
