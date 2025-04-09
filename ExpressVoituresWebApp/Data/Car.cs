using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoituresWebApp.Data
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "VIN")]
        public required long Vin { get; set; }

        [ForeignKey("CarModels")]
        [Display(Name = "Modèle")]
        public required int ModelId { get; set; }

        [Display(Name = "Prix d'achat")]
        public required float PurchasePrice { get; set; }

        [Display(Name = "Date d'achat")]
        public required DateOnly PurchaseDate { get; set; }

        [Display(Name = "Date de mise en vente")]
        public DateOnly? ListingDate { get; set; }

        [Display(Name = "Prix de vente")]
        public float? ResellPrice { get; set; }

        [Display(Name = "Date de revente")]
        public DateOnly? ResellDate { get; set; }

        public string? Description { get; set; }
        public string? ImageUrl { get; set; }


        public virtual CarModel? Model { get; set; }
    }
}
