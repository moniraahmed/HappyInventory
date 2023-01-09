using HappyInventory.Shared;

namespace HappyInventory.Server.Service.AuthorizeService
{
    public interface IAuthorizeService
    {
        public Task<ServiceResponse<string>> Login (string email, string password);
    }
}
