using Model;

namespace Domain.Repository;

public class WoundRepository : IRepository<Wound, string>
{
    private readonly VMContext _context;

    public WoundRepository(VMContext context)
    {
        _context = context;
    }

    public Wound GetById(string id)
    {
        return _context.Wounds.Find(id);
    }

    public void Add(Wound wound)
    {
        _context.Wounds.Add(wound);
        _context.SaveChanges();
    }

    public void Update(Wound wound)
    {
        _context.Wounds.Update(wound);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var wound = _context.Wounds.Find(id);
        if (wound != null)
        {
            _context.Wounds.Remove(wound);
            _context.SaveChanges();
        }
    }
}
