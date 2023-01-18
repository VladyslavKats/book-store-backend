using BookStore.BLL.Models.Genre;
using System.Diagnostics.CodeAnalysis;

namespace BooksStore.Tests.Common.Comparers.Genre
{
    public class GenreDtoComparer : IEqualityComparer<GenreDto>
    {
        public bool Equals(GenreDto? x, GenreDto? y)
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
                   x.Description == y.Description;
        }

        public int GetHashCode([DisallowNull] GenreDto obj)
        {
            return obj.GetHashCode();
        }
    }
}
