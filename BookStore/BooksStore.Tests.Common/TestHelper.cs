using AutoMapper;
using BookStore.BLL.Mapper;
using BookStore.DAL.Entities;

namespace BooksStore.Tests.Common
{
    public static class TestHelper
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(
                conf => conf.AddMaps(typeof(BookProfile).Assembly)
            ).CreateMapper();
        }

        public static IEnumerable<BookEntity> GetAllBooks()
        {
            return new List<BookEntity>
            {
                new BookEntity
                {
                     Id = Guid.NewGuid().ToString(),
                     ImageUrl = "url1",
                     Name = "name1",
                     CreatedAt = new DateTime(2010 , 9 , 10),
                     Description = "description1",
                     Price = 100,
                     PageCount = 100,
                     Rating = 4.5d,
                     ViewCount = 34,
                     PublishedYear = 1990
                },
                new BookEntity
                {
                     Id = Guid.NewGuid().ToString(),
                     ImageUrl = "url2",
                     Name = "name2",
                     CreatedAt = new DateTime(2010 , 9 , 11),
                     Description = "description2",
                     Price = 200,
                     PageCount = 200,
                     Rating = 4.0d,
                     ViewCount = 40,
                     PublishedYear = 1991
                },
                new BookEntity
                {
                     Id = Guid.NewGuid().ToString(),
                     ImageUrl = "url3",
                     Name = "name3",
                     CreatedAt = new DateTime(2010 , 9 , 12),
                     Description = "description3",
                     Price = 300,
                     PageCount = 300,
                     Rating = 3.5d,
                     ViewCount = 45,
                     PublishedYear = 1993
                }
            };
        }

        public static IEnumerable<GenreEntity> GetAllGenres()
        {
            return new List<GenreEntity>
            {
                new GenreEntity
                {
                     Id = Guid.NewGuid().ToString(),
                     Name = "name1",
                     Description = "desctiption1",
                },
                new GenreEntity
                {
                     Id = Guid.NewGuid().ToString(),
                     Name = "name2",
                     Description = "desctiption2",
                },
                new GenreEntity
                {
                     Id = Guid.NewGuid().ToString(),
                     Name = "name3",
                     Description = "desctiption3",
                }
            };
        }
    }
}