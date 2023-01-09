using HappyInventory.Shared;
namespace HappyInventory.Server.Service.User
{
    public interface IUserService
    {
        Task<UserModel> AddUser(UserModel user);
    }
}
