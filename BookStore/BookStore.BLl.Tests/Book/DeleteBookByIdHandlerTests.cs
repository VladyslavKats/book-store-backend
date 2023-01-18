using BookStore.BLL.Commands.Book;
using BookStore.BLL.Exceptions;
using BookStore.BLL.Handlers.Book;
using BookStore.BLL.Queries.Book;
using BookStore.DAL.Entities;
using Moq;

namespace BookStore.BLl.Tests.Book
{
    [TestFixture]
    public class DeleteBookByIdHandlerTests : TestSetup
    {
        [Test]
        public async Task Should_DeleteBook()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            var book = new BookEntity {Id = id};
            var query = new DeleteBookByIdCommand(id);
            _mockUnitOfWork.Setup(x => x.Books.GetAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(book);
            var handler = new DeleteBookByIdHandler(_mockUnitOfWork.Object);
            //act
            await handler.Handle(query);
            //assert
            _mockUnitOfWork.Verify(x => x.Books.DeleteAsync(It.Is<string>(x => x == id)));
            _mockUnitOfWork.Verify(x => x.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public void Should_ThrowEntityDoesNotExistException_WhenSuchBookDoesNotExist()
        {
            //arrange
            var id = Guid.NewGuid().ToString();
            var query = new DeleteBookByIdCommand(id);
            _mockUnitOfWork.Setup(x => x.Books.GetAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync((BookEntity)null);
            var handler = new DeleteBookByIdHandler(_mockUnitOfWork.Object);
            //act
            AsyncTestDelegate action = async () => await handler.Handle(query);
            //assert
            Assert.ThrowsAsync<EntityDoesNotExistException>(action);
        }
    }
}
