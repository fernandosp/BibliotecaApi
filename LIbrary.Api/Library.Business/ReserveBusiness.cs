using Library.Domain;
using Library.Infra.Repository;
using System.Collections.Generic;


namespace Library.Business
{
    public class ReserveBusiness : IBusiness<Reserve>
    {
        private readonly IReserveRepository _reserveRepository;

        public ReserveBusiness(IReserveRepository reserveRepository)
        {
            _reserveRepository = reserveRepository;
        }
        public void Delete(Reserve entity)
        {
            _reserveRepository.Delete(entity);
        }

        public void Insert(Reserve entity)
        {
            _reserveRepository.Insert(entity);
        }

        public IEnumerable<Reserve> Query(string where = null)
        {
            return _reserveRepository.Query(where);
        }

        public void Update(Reserve entity)
        {
            _reserveRepository.Update(entity);
        }
    }
}
