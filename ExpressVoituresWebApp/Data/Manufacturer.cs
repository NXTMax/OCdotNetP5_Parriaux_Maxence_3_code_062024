namespace ExpressVoituresWebApp.Data
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual List<CarModel>? Models { get; set; }

        override public string ToString()
        {
            return Name;
        }
    }
}
