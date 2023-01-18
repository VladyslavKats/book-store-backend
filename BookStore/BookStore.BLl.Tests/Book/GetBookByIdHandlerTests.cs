using AutoMapper;
using BooksStore.Tests.Common;
using BooksStore.Tests.Common.Comparers.Book;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Handlers.Book;
using BookStore.BLL.Models.Book;
using BookStore.BLL.Queries.Book;
using BookStore.DAL.Entities;
using Moq;

namespace BookStore.BLl.Tests
{
    [TestFixture]
    public class GetBookByIdHandlerTests : TestSetup
    {
        [Test]
        public async Task Should_ReturnBookById()
        {
            //arrange 
            var book = TestHelper.GetAllBooks().First();
            var expected = _mapper.Map<BookDto>(book);
            var id = expected.Id;
            _mockUnitOfWork.Setup(x => x.Books.GetAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(book);
            var handler = new GetBookByIdHandler(_mockUnitOfWork.Object , _mapper);
            var request = new GetBookByIdQuery(id);
            //act
            var actual = await handler.Handle(request);
            //assert
            Assert.That(actual, Is.EqualTo(expected).Using(new BookDtoComparer()),
                "GetBookByIdHandler does not return book");
        }

        [Test]
        public void WhenBookDoesNotExist_Should_ThrowEntityDoesNotExistException()
        {
            //arrange
            var id = "some_id";
            _mockUnitOfWork.Setup(x => x.Books.GetAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((BookEntity)null);
            var handler = new GetBookByIdHandler(_mockUnitOfWork.Object, _mapper);
            var request = new GetBookByIdQuery(id);
            //act
            AsyncTestDelegate action = async () => await handler.Handle(request);
            //assert
            Assert.ThrowsAsync<EntityDoesNotExistException>(action);
        }
    }
}
