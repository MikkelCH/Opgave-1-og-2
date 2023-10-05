namespace BookLib
{
    public class Book
    {
        public int Id { get; set; }
        public string? Titel { get; set; }
        public double Price { get; set; }

        public Book(int id, string titel, double price)
        {
            Id = id;
            Titel = titel;
            Price = price;
        }

        public void ValidateTitel()
        {
            if (Titel == null)
            {
                throw new ArgumentNullException("Titel is null");
            }

            if (Titel.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Titel must be at least 3 characters");
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException("Price was outofrange");
            }
        }

        public override string ToString()
        {
            return $"Titel = {Titel};  Price = {Price};";
        }

        public void Validate()
        {
            ValidateTitel();
            ValidatePrice();
        }
    }
}