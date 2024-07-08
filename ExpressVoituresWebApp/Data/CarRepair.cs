using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresWebApp.Data
{
    [PrimaryKey("CarVin", "RepairId")]
    public class CarRepair
    {
        public int CarVin { get; set; }
        public int RepairId { get; set; }

        public virtual required Car Car { get; set; }
        public virtual required Repair Repair { get; set; }

        public float Cost { get; set; }
    }
}
