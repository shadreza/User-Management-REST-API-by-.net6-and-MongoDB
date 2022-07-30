using UserManagement.Models;

namespace UserManagement.Services
{
    public interface IUserService
    {
        List<User> Get();
        User GetById(string id);
        //List<User> GetByName(string name);
        User CreateUser (User user);
        void UpdateUser (string id, User user);
        void RemoveUser (string id);

    }
}
