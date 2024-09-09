using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoituresWebApp.Data
{
    public class CarModel
    {
        public int Id { get; set; }
        [ForeignKey("Manufacturer")]
        public required int ManufacturerId { get; set; }
        public required string Name { get; set; }
        public string? Finition { get; set; }
        public int? Year { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }

        override public string ToString()
        {
            return Manufacturer + " " + Name + " " + Finition + " " + Year;
        }
    }
}
