using HomeworkClass03.Models;

namespace HomeworkClass03
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Author = "Napoleon Hill",
                Title = "Outwitting the Devil"
            },
            new Book
            {
                Id = 2,
                Author = "Paulo Coelho",
                Title = "The Alchemist"
            },
            new Book
            {
                Id = 3,
                Author = "Robert Greene",
                Title = "The 48 Laws of Power"
            }
        };
    }
}
