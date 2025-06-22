using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoituresWebApp.Data
{
    public class CarModel
    {
        public int Id { get; set; }

        [ForeignKey("Manufacturer")]
        public required int ManufacturerId { get; set; }

        [Display(Name = "Modèle")]
        public required string Name { get; set; }

        [Display(Name = "Année")]
        public int? Year { get; set; }


        [Display(Name = "Constructeur")]
        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual ModelFinition? Finition { get; set; }

        override public string ToString()
        {
            return Manufacturer + " " + Name + " " + Finition + " " + Year;
        }
    }
}
