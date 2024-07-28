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
    [StringAttribute]
    public string? TableNumber { get; set; }
    [StringAttribute]
    public string? TableCode { get; set; }
    [StringAttribute]
    public string? TableStatus { get; set; }
    [StringAttribute]
    public string? TableState { get; set; }
    [StringAttribute]
    public string? TableType { get; set; }
    [StringAttribute]
    public string? TableDescription { get; set; }
    [StringAttribute]
    public string? TableImage { get; set; }
    [StringAttribute]
    public string? TableQRCode { get; set; }
    [BooleanAttribute]
    public bool IsDeleted { get; set; }
    [ChildAttribute]
    public Restaurant? Restaurant { get; set; }
    [GuidAttribute]
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
