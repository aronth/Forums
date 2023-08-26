using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly DatabaseContext _context;
    public UserService(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<User?> Get(String username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
    public async Task<User> Create(String username, String password)
    {
        User user = new User
        {
            Username = username,
            Password = password
        };
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}