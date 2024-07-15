namespace ExpressVoituresWebApp.Data
{
    public class CarModel
    {
        public int Id { get; set; }
        public virtual required Manufacturer Manufacturer { get; set; }
        public required string Name { get; set; }
        public string? Finition { get; set; }
        public int? Year { get; set; }

        override public string ToString()
        {
            return Manufacturer + " " + Name + " " + Finition + " " + Year;
        }
    }
}
