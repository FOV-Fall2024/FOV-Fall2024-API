using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Domain.DTOs;
public class ComboQuantityDtos
{
    public Guid ComboId { get; set; }
    public string ComboName { get; set; }
    public int TotalQuantity { get; set; }
}
