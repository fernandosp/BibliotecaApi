using Library.Domain;
using Library.Infra.Repository;
using System.Collections.Generic;

namespace Library.Business
{
    public class BookBusiness : IBusiness<Book>
    {
        private readonly IBookRepository _bookRepository;

        public BookBusiness(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Delete(Book entity)
        {
            _bookRepository.Delete(entity);
        }

        public void Insert(Book entity)
        {
            _bookRepository.Insert(entity);
        }

        public IEnumerable<Book> Query(string where = null)
        {
            return _bookRepository.Query(where);
        }

        public void Update(Book entity)
        {
            _bookRepository.Update(entity);
        }
    }
}