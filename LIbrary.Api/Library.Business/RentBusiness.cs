using Library.Domain;
using Library.Infra.Repository;
using System.Collections.Generic;

namespace Library.Business
{
    public class RentBusiness : IBusiness<Rent>
    {
        private readonly IRentRepository _rentRepository;

        public RentBusiness(IRentRepository rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public void Delete(Rent entity)
        {
            _rentRepository.Delete(entity);
        }

        public void Insert(Rent entity)
        {
            _rentRepository.Insert(entity);
        }

        public IEnumerable<Rent> Query(string where = null)
        {
            return _rentRepository.Query(where);
        }

        public void Update(Rent entity)
        {
            _rentRepository.Update(entity);
        }
    }
}