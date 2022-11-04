using RegistrationService.Code.Models;

namespace RegistrationService.Abstract.Interfaces;

public interface IUserStore
{
    public User Get(Int32 userId);
    public void Save(User user);
}
