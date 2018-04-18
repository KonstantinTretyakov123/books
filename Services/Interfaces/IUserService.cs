using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLevel.Entities;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User AddUser(User user);
        Guid IdTransfer(string aspNetId);
        User FindById(Guid id);
        User FindById(string id);
        void UpdateUser(User user);
    }
}
