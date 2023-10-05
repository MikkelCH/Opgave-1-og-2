using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class BooksRepository
    {
        private int nextId = 1;
        private List<Book> Books = new List<Book>();

        public BooksRepository()
        {
            Books.Add(new Book(nextId++, "HarryPotter", 700.00));
            Books.Add(new Book(nextId++, "2. Verdenskrig", 500.00));
            Books.Add(new Book(nextId++, "Den kolde krig", 450.00));
            Books.Add(new Book(nextId++, "Programming for dummies", 900.00));
            Books.Add(new Book(nextId++, "How to build a table", 50.00));
        }

        public List<Book> Get(int? priceBelow=null, string? OrderBy=null)
        {
            IEnumerable<Book> result = new List<Book>(Books);
            if (priceBelow != null) 
            {
                result.Where(book => book.Price < priceBelow);
            }
            if (OrderBy != null)
            {
                result = OrderBy switch
                {
                    "Titel" => result.OrderBy(book => book.Titel),
                    "PriceDesc" => result.OrderByDescending(book => book.Price),
                    "Price" => result.OrderBy(book => book.Price),
                    _ => throw new ArgumentException("Invalid Orderby")
                };
            }

            return result.ToList();
        }

        public Book? GetById(int id)
        {
            return Books.FirstOrDefault(a => a.Id == id);
        }

        public Book Add(Book book)
        {
            book.Validate();
            book.Id = nextId++;
            Books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book != null)
            {
                Books.Remove(book);
                return(book);
            }
            return null;
        }

        public Book? Update(int id,  Book book)
        {
            book.Validate();
            Book? existingBook = GetById(id);
            if (existingBook != null)
            {
                existingBook.Titel = book.Titel;
                existingBook.Price = book.Price;
            }
            return existingBook;

        }
    }
}
