using Library.Domain;
using Library.Infra.Repository;
using System.Collections.Generic;

namespace Library.Business
{
    public class UserBusiness : IBusiness<User>
    {
        private readonly IUserRepository _userRepository;

        public UserBusiness(IUserRepository UuserRepository)
        {
            _userRepository = UuserRepository;
        }
        public void Delete(User entity)
        {
            _userRepository.Delete(entity);
        }

        public void Insert(User entity)
        {
            _userRepository.Insert(entity);
        }

        public IEnumerable<User> Query(string where = null)
        {
            return _userRepository.Query(where);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }
    }
}
