using RegistrationService.Abstract.Interfaces;
using RegistrationService.Code.Models;
using RegistrationService.DAL;

namespace RegistrationService.Abstract.Infrastructure;

public class UserStore : IUserStore
{
    private readonly RegistrationBoundedContext _context;

    public UserStore(RegistrationBoundedContext context) => _context = context;

    public User Get(Int32 userId)
    {
        using (_context)
        {
            return _context.Users.First(u => u.Id == userId);
        }
    }

    public void Save(User user)
    {
        using (_context)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
