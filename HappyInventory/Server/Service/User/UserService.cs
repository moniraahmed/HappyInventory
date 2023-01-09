using HappyInventory.Shared;
namespace HappyInventory.Server.Service.User
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context) 
        {
            _context = context;
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
