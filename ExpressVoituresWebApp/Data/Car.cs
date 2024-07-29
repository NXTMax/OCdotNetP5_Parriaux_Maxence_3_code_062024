using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoituresWebApp.Data
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Vin { get; set; }
        public required virtual CarModel Model { get; set; }
        public float PurchasePrice { get; set; }
        public required string PurchaseDate { get; set; }
        public string? ListingDate { get; set; }
        public float? ResellPrice { get; set; }
        public string? ResellDate { get; set; }
    }
}
