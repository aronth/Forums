public interface IUserService
{
    Task<User?> Get(String username);
    Task<User> Create(String username, String password);
    Task<User> Update(User user);
    Task<User> Delete(User user);

}