using BookStore.BLL.Models.Book;
using System.Diagnostics.CodeAnalysis;

namespace BooksStore.Tests.Common.Comparers.Book
{
    public class BookDtoComparer : IEqualityComparer<BookDto>
    {
        public bool Equals(BookDto? x, BookDto? y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            if (x == y)
            {
                return true;
            }
            return x.Id == y.Id &&
                   x.Name == y.Name &&
                   x.ImageUrl == y.ImageUrl &&
                   x.PageCount == y.PageCount &&
                   x.Description == y.Description &&
                   x.Rating == y.Rating;
        }

        public int GetHashCode([DisallowNull] BookDto obj)
        {
            return obj.GetHashCode();
        }
    }
}
