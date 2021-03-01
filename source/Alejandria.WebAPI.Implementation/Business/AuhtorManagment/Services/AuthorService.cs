﻿using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Converters;
using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Dtos;
using Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Exceptions;
using Alejandria.WebAPI.Implementation.Data.Database;
using Alejandria.WebAPI.Implementation.Data.Entities;
using Alejandria.WebAPI.Implementation.Data.RepositoryInterfaces;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alejandria.WebAPI.Implementation.Business.AuhtorManagment.Services
{
    public class AuthorService : Service<AlejandriaContext>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AuthorService(IUnitOfWork<AlejandriaContext> unitOfWork): base(unitOfWork)
        {
            _authorRepository = UoW.Repository<IAuthorRepository>();
            _bookRepository = UoW.Repository<IBookRepository>();
        }

        public async Task<AuthorResponse> CreateAuthor(CreateAuthorRequest request)
        {
            Devon4NetLogger.Debug("Entering CreateAuthor book on AuhtorService");

            var author = await _authorRepository.Create(request.ToAuthor()).ConfigureAwait(false);
            return author.ToAuthorResponse();
        }

        public async Task<bool> DeleteAuthor(Guid authorId)
        {
            Devon4NetLogger.Debug("Entering DeleteAuthor book on AuhtorService");

            var author = await _authorRepository.GetFirstOrDefault(author => author.Id == authorId).ConfigureAwait(false);
            if (author == null) throw new AuthorNotFoundException();

            return await _authorRepository.Delete(author).ConfigureAwait(false);
        }

        public async Task<IEnumerable<AuthorResponse>> GetAuhtors()
        {
            Devon4NetLogger.Debug("Entering GetAuhtors book on AuhtorService");

            var authors = await _authorRepository.Get().ConfigureAwait(false);
            return authors.Select(author => author.ToAuthorResponse());
        }

        public async Task<BookResponse> PublishBook(Guid authorId, PublishBookRequest request)
        {
            Devon4NetLogger.Debug("Entering Publish book on AuhtorService");

            var author = await _authorRepository.GetAuthorAndBooksById(authorId).ConfigureAwait(false);
            if (author == null) throw new AuthorNotFoundException();

            Book book;
            using (var transaction = await UoW.BeginTransaction().ConfigureAwait(false))
            {
                book = await _bookRepository.Create(request.ToBook()).ConfigureAwait(false);
                
                var authorBook = new AuthorBook
                {
                    Author = author.Id,
                    Book = book.Id,
                    PublishDate = DateTime.Now,
                    ValidityDate = DateTime.Now.AddYears(1)
                };
                author.AuthorBook.Add(authorBook);
                await _authorRepository.Update(author).ConfigureAwait(false);

                await transaction.CommitAsync().ConfigureAwait(false);
            }

            return book.ToBookResponse();
        }
    }
}