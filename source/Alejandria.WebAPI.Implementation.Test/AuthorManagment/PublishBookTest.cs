using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Exceptions;
using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Services;
using Alejandria.WebAPI.Implementation.Business.Common.Dtos;
using Alejandria.WebAPI.Implementation.Data.Database;
using Alejandria.WebAPI.Implementation.Data.Entities;
using Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace Alejandria.WebAPI.Implementation.Test.AuthorManagment
{
    public class PublishBookTest
    {
        private readonly Mock<IUnitOfWork<AlejandriaContext>> _unitOfWork;
        private readonly Mock<IAuthorRepository> _mockAuthorRepository;
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IAuthorBookRepository> _mockAuthorBookRepository;

        public PublishBookTest()
        {
            _unitOfWork = new Mock<IUnitOfWork<AlejandriaContext>>();
            _mockAuthorRepository = new Mock<IAuthorRepository>();
            _mockBookRepository = new Mock<IBookRepository>();
            _mockAuthorBookRepository = new Mock<IAuthorBookRepository>();

            _unitOfWork.Setup(uow => uow.Repository<IAuthorRepository, Author>()).Returns(_mockAuthorRepository.Object);
            _unitOfWork.Setup(uow => uow.Repository<IBookRepository, Book>()).Returns(_mockBookRepository.Object);
            _unitOfWork.Setup(uow => uow.Repository<IAuthorBookRepository, AuthorBook>()).Returns(_mockAuthorBookRepository.Object);
        }

        [Fact]
        public async void NonExistingAuthorPublishBook()
        {
            // Arrange
            var authorId = Guid.NewGuid();
            var request = new PublishBookRequestDto
            {
                Title = "New Title",
                Summary = "Summary",
                Genre = "Action"
            };

            _mockAuthorRepository
                .Setup(repo => repo.GetFirstOrDefault(aut => aut.Id == authorId))
                .ReturnsAsync((Author)null);
            _mockBookRepository
                .Setup(repo => repo.Create(It.IsAny<Book>(), true))
                .ReturnsAsync(new Book());
            _mockAuthorBookRepository
                .Setup(repo => repo.Create(It.IsAny<AuthorBook>(), true))
                .ReturnsAsync(new AuthorBook());
            var authorService = SetupService();

            // Act 
            AuthorNotFoundException exception = null;
            try
            {
                await authorService.PublishBook(authorId, request);
            }
            catch (AuthorNotFoundException ex)
            {
                exception = ex;
            }
            finally
            {
                Assert.NotNull(exception);
            }
        }

        [Fact]
        public async void ExistingAuthorPublishABook()
        {
            // Arrange
            var authorId = Guid.NewGuid();
            var request = new PublishBookRequestDto
            {
                Title = "New Title",
                Summary = "Summary",
                Genre = "Action"
            };
            var expected = new BookResponseDto
            {
                Title = "New Title",
                Summary = "Summary",
                Genre = "Action",
                Id = Guid.NewGuid()
            };

            _mockAuthorRepository
                .Setup(repo => repo.GetFirstOrDefault(aut => aut.Id == authorId))
                .ReturnsAsync(new Author());
            _mockBookRepository
                .Setup(repo => repo.Create(It.IsAny<Book>(), true))
                .ReturnsAsync(new Book { Title = expected.Title, Summary = expected.Summary, Genre = expected.Genre, Id = expected.Id });
            _mockAuthorBookRepository
                .Setup(repo => repo.Create(It.IsAny<AuthorBook>(), true))
                .ReturnsAsync(new AuthorBook());
            var authorService = SetupService();

            // Act
            var actual = await authorService.PublishBook(authorId, request);

            // Assert
            Assert.True(BookResponseEquals(expected, actual));
        } 

        private IAuthorService SetupService() 
        {
            return new AuthorService(_unitOfWork.Object);
        }

        private bool BookResponseEquals(BookResponseDto leftBook, BookResponseDto rightBook) => Equals(leftBook.GetType()
            .GetProperties()
            .FirstOrDefault(prop => 
            {
                var leftValue = prop.GetValue(leftBook, null);
                var rightValue = prop.GetValue(rightBook, null);
               
                return prop.Name == "Id" ? (Guid)leftValue != (Guid)rightValue : leftValue != rightValue;
            }), null);
    }
}
