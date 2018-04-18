using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLevel.Entities;
using Services.Interfaces;
using DatabaseLevel.Repositoty;

namespace Services.Services
{
    public class UserService : IUserService
    {
        protected IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User AddUser(User user)
        {
            var newUser = _userRepository.Add(user);
            _userRepository.Save();
            return newUser;
        }

        public Guid IdTransfer(string aspNetId)
        {

            Guid id = _userRepository.Find(u => u.AspNetId == aspNetId).Id;
            return id;
        }

        public User FindById(Guid id)
        {
            return _userRepository.Find(u => u.Id == id);
        }

        public User FindById(string id)
        {
            return _userRepository.Find(u => u.AspNetId == id);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            _userRepository.Save();
        }

    }
}
