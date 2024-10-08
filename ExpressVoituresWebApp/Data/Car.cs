﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoituresWebApp.Data
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required long Vin { get; set; }
        [ForeignKey("CarModels")]
        public required int ModelId { get; set; }
        public required float PurchasePrice { get; set; }
        public required DateOnly PurchaseDate { get; set; }
        public DateOnly? ListingDate { get; set; }
        public float? ResellPrice { get; set; }
        public DateOnly? ResellDate { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual CarModel? Model { get; set; }
    }
}
