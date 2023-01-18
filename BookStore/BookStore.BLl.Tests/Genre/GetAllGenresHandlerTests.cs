using BooksStore.Tests.Common;
using BooksStore.Tests.Common.Comparers.Genre;
using BookStore.BLL.Handlers.Genre;
using BookStore.BLL.Models.Genre;
using BookStore.BLL.Queries.Genre;
using Moq;

namespace BookStore.BLl.Tests.Genre
{
    [TestFixture]
    public class GetAllGenresHandlerTests : TestSetup
    {
        [Test]
        public async Task Should_ReturnAllGenres()
        {
            //arrange
            var genres = TestHelper.GetAllGenres();
            var expected = _mapper.Map<IEnumerable<GenreDto>>(genres);
            _mockUnitOfWork.Setup(x => x.Genres.GetAllAsync(It.IsAny<string>()))
                .ReturnsAsync(genres);
            var request = new GetAllGenresQuery();
            var handler = new GetAllGenresHandler(_mockUnitOfWork.Object , _mapper);
            //act
            var actual = await handler.Handle(request);
            //assert
            Assert.That(actual, Is.EqualTo(expected).Using(new GenreDtoComparer()),
                "GetAllGenresHandler does not return all genres");
        }
    }
}
