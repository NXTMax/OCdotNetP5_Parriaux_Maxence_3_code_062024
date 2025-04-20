using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoituresWebApp.Data
{
    public class ModelFinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public required string Name { get; set; }

        override public string ToString() => Name;
    }
}
