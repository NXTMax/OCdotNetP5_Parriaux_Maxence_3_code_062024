using System.ComponentModel.DataAnnotations;

namespace ExpressVoituresWebApp.Data
{
    public class Car
    {
        [Key]
        public required int Vin { get; set; }
        public required virtual CarModel Model { get; set; }
        public float PurchasePrice { get; set; }
        public required string PurchaseDate { get; set; }
        public string? ListingDate { get; set; }
        public float? ResellPrice { get; set; }
        public string? ResellDate { get; set; }
    }
}
