namespace Catalog
{
    class Book
    {
        public Book(string name, string author, string isbn, int publicationYear)
        {
            Name = name;
            Author = author;
            ISBN = isbn;
            PublicationYear = publicationYear;
        }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }

        public override string ToString()
        {
            return $"{Name}, {Author}, {ISBN}";
        }
    }

    class MediaItem
    {
        public MediaItem(string title, string mediaType, int duration)
        {
            Title = title;
            MediaType = mediaType;
            Duration = duration;
        }
        public string Title { get; set; }
        public string MediaType { get; set; }
        public int Duration { get; set; }

        public override string ToString()
        {
            return $"{Title}, {MediaType}, {Duration}";
        }
    }

    class Library
    {
        public Library(string name, string address)
        {
            Name = name;
            Address = address;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> Books = new();
        public List<MediaItem> MediaItems = new();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }

        public void AddMediaItem(MediaItem item)
        {
            MediaItems.Add(item);
        }

        public void PrintCatalog()
        {
            Console.WriteLine($"-----------All the books in the {Name}-------------");
            foreach (Book book in Books)
            {
                Console.WriteLine(book.ToString());
            }

            Console.WriteLine($"-----------All the medias in {Name}----------------");
            foreach (MediaItem item in MediaItems)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}