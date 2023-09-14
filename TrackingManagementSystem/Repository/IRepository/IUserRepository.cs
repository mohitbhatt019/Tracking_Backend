using TrackingManagementSystem.Models;

namespace TrackingManagementSystem.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> Authenticate(LoginModel loginDto);
        bool IsUniqueUser(string username);
        Task<bool> RegisterUser(RegisterModel registerModel);
        ICollection<ApplicationUser> GetUsers();
        public bool LockUnlockUser(string id);
    }
}
