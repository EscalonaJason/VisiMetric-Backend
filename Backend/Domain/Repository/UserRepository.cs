using Model;

namespace Domain.Repository;

public class UserRepository : IRepository<User, int>
{
    private readonly VMContext _context;

    public UserRepository(VMContext context)
    {
        _context = context;
    }

    public User GetById(int id)
    {
        return _context.Users.Find(id);
    }

    public int GetIdByName(string firstName, string lastName)
    {
        var user = _context.Users.FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);
    
        // Auf null überprüfen, bevor dem zurückgeben.
        return user != null ? user.Id : -1; // Assuming -1 as a default or error value
    }

    
    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    
}
