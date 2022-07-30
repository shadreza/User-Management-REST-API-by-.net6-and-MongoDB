using UserManagement.Models;
using MongoDB.Driver;

namespace UserManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService( IUserStoreDatabaseSettings settings, IMongoClient mongoClient )
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserProfileCollectionName);

        }

        public User CreateUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public User GetById(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        //public List<User> GetByName(string name)
        //{
        //    return _users.Find(user => user.Name == name).ToList();
        //}

        public void RemoveUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void UpdateUser(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }
    }
}
