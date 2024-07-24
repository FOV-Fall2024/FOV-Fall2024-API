using FOV.Domain.Common;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.Entities.TableAggregator;
public class Table : BaseAuditableEntity, IsSoftDeleted
{
    public string TableNumber { get; set; } = string.Empty;
    public string TableCode { get; set; } = string.Empty;
    public string TableStatus { get; set; } = string.Empty;
    public string TableState { get; set; } = string.Empty;
    public string TableType { get; set; } = string.Empty;
    public string TableDescription { get; set; } = string.Empty;
    public string TableImage { get; set; } = string.Empty;
    public string TableQRCode { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public Restaurant? Restaurant { get; set; }
    public Guid RestaurantId { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = [];

    public Table()
    {

    }

    public Table(string tableNumber, string tableCode, string tableStatus, string tableState, string tableType, string tableDescription, string tableImage)
    {
        //this.RestaurantId = restaurantId; Guid restaurantId,
        this.TableNumber = tableNumber;
        this.TableCode = tableCode;
        this.TableStatus = tableStatus;
        this.TableState = tableState;
        this.TableType = tableType;
        this.TableDescription = tableDescription;
        this.TableImage = tableImage;
    }
    public void Update(string tableNumber, string tableCode, string tableStatus, string tableState, string tableType, string tableDescription, string tableImage, string TableQRCode)
    {
        this.TableNumber = tableNumber;
        this.TableCode = tableCode;
        this.TableStatus = tableStatus;
        this.TableState = tableState;
        this.TableType = tableType;
        this.TableDescription = tableDescription;
        this.TableImage = tableImage;
        this.TableQRCode = TableQRCode;
    }
    public void UpdateState(bool state) => IsDeleted = state;
}
