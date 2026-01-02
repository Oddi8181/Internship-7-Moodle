using Domain.Entities;

namespace Domain.Persistance
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid userId);
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task UpdateAsync(User user);
    }
}
