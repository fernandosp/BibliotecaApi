using Library.Domain;
using Library.Infra.Repository;
using System.Collections.Generic;

namespace Library.Business
{
    public class PublisherBusiness : IBusiness<Publisher>
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherBusiness(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }
        public void Delete(Publisher entity)
        {
            _publisherRepository.Delete(entity);
        }

        public void Insert(Publisher entity)
        {
            _publisherRepository.Insert(entity);
        }

        public IEnumerable<Publisher> Query(string where = null)
        {
            return _publisherRepository.Query(where);
        }

        public void Update(Publisher entity)
        {
            _publisherRepository.Update(entity);
        }
    }
}
