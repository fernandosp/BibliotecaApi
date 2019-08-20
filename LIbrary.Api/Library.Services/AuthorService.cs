using Library.Business;
using Library.Domain;
using Library.Services.Interfaces;
using System.Collections.Generic;

namespace Library.Services
{
    public class AuthorService : IService<Author>
    {
        private readonly IBusiness<Author> _authorBusiness;
        public AuthorService(IBusiness<Author> authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        public void Delete(Author entity)
        {
            _authorBusiness.Delete(entity);
        }

        public void Insert(Author entity)
        {
            _authorBusiness.Insert(entity);
        }

        public IEnumerable<Author> Query(string where = null)
        {
           return _authorBusiness.Query(where);
        }

        public void Update(Author entity)
        {
            _authorBusiness.Update(entity);
        }
    }
}
