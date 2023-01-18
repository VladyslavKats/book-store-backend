using AutoMapper;
using BooksStore.Tests.Common;
using BookStore.DAL.Interfaces;
using Moq;

namespace BookStore.BLl.Tests
{
    public class TestSetup
    {
        protected readonly IMapper _mapper = TestHelper.CreateMapper();
        protected Mock<IBookStoreUW> _mockUnitOfWork;

        [SetUp]
        public virtual void Setup()
        {
            _mockUnitOfWork = new Mock<IBookStoreUW>();
        }
    }
}
