using MongoDB.Driver;
using StudentHub.Models;

namespace StudentHub.Services
{
    public static class DB
    {
        public static MongoClient Client = new MongoClient("mongodb+srv://vscoop_root:FWNnC8Bzwbyvg5SG@cluster.6ppflzc.mongodb.net/");
        public static IMongoCollection<User> Users = Client.GetDatabase("test").GetCollection<User>("users");
    }

    public static class UserActions
    {
        public static void AddUser(User user)
        {
            DB.Users.InsertOne(user);
        }

        public async static Task AddUserAsync(User user)
        {
            await DB.Users.InsertOneAsync(user);
        }

        public async static Task<bool> IsUserExistsAsync(User user)
        {
            return await IsUserExistsAsync(user.Email);
        }

        public async static Task<bool> IsUserExistsAsync(string email)
        {
            var user = await DB.Users.Find(a => a.Email == email).FirstOrDefaultAsync();
            return user != null;
        }
    }
}
