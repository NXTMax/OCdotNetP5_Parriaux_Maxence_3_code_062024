using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoituresWebApp.Data
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required int Vin { get; set; }
        [ForeignKey("CarModels")]
        public required int ModelId { get; set; }
        public required float PurchasePrice { get; set; }
        public required string PurchaseDate { get; set; }
        public string? ListingDate { get; set; }
        public float? ResellPrice { get; set; }
        public string? ResellDate { get; set; }

        public virtual CarModel? Model { get; set; }
    }
}
