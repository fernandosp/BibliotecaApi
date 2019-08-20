using Library.Domain;
using Library.Infra.Repository;
using System.Collections.Generic;

namespace Library.Business
{
    public class AuthorBusiness : IBusiness<Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorBusiness(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public void Delete(Author entity)
        {
            _authorRepository.Delete(entity);
        }

        public void Insert(Author entity)
        {
            _authorRepository.Insert(entity);
        }

        public IEnumerable<Author> Query(string where = null)
        {
           return _authorRepository.Query(where);
        }

        public void Update(Author entity)
        {
            _authorRepository.Update(entity);
        }
    }
}
