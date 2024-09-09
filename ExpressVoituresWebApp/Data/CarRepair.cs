using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoituresWebApp.Data
{
    [PrimaryKey("CarVin", "RepairId")]
    public class CarRepair
    {
        [ForeignKey("Cars")]
        public required int CarVin { get; set; }
        [ForeignKey("Repairs")]
        public required int RepairId { get; set; }

        public required float Cost { get; set; }

        public virtual Car? Car { get; set; }
        public virtual Repair? Repair { get; set; }
    }
}
