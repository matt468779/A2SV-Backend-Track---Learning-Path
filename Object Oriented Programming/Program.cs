using Task2;
using Catalog;

Circle circle = new Circle(5);
circle.PrintShapeArea();

Rectangle rectangle = new Rectangle(10, 20);
rectangle.PrintShapeArea();

Triangle triangle = new Triangle(10, 20);
triangle.PrintShapeArea();

Book book1 = new("The Lord of the Rings", "J.R.R Tolkien", "122-0-3242313-9-7", 1954);
Book book2 = new("The Chronicles of Narnia", "C.S. Lewis", "231-0-2343232-2-0", 1950);
Book book3 = new("Pride and Prejudice", "Jane Austen", "543-0-2343652-0-7", 1813);

MediaItem media1 = new MediaItem("media1", "CD-ROM", 40);
MediaItem media2 = new MediaItem("media2", "DVD", 60);
MediaItem media3 = new MediaItem("media3", "Floppy Disk", 5);

Library library = new Library("Abrehot", "Arat Kilo");

library.AddBook(book1);
library.AddBook(book2);
library.AddBook(book3);

library.AddMediaItem(media1);
library.AddMediaItem(media2);
library.AddMediaItem(media3);

library.PrintCatalog();