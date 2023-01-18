using AutoMapper;
using BooksStore.Tests.Common;
using BooksStore.Tests.Common.Comparers.Book;
using BookStore.BLL.Handlers.Book;
using BookStore.BLL.Models.Book;
using BookStore.BLL.Queries.Book;
using BookStore.DAL.Interfaces;
using Moq;

namespace BookStore.BLl.Tests.Book
{
    [TestFixture]
    public class GetAllBooksHandlerTests : TestSetup
    {
        [Test]
        public async Task Should_ReturnAllBooks()
        {
            //arrange
            var books = TestHelper.GetAllBooks();
            var request = new GetAllBooksQuery();
            _mockUnitOfWork.Setup(x => x.Books.GetAllAsync(It.IsAny<string>()))
                .ReturnsAsync(books);
            var handler = new GetAllBooksHandler(_mockUnitOfWork.Object, _mapper);
            var expected = _mapper.Map<IEnumerable<BookDto>>(books);
            //act
            var actual = await handler.Handle(request);
            //assert
            Assert.That(actual, Is.EqualTo(expected).Using(new BookDtoComparer()),
                "GetAllBooksHandler does not return all books");
        }
    }
}
