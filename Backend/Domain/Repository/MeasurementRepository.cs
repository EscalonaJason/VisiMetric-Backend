namespace Domain.Repository;

public class MeasurementRepository : IRepository<Measurement, int>
{
    private readonly VMContext _context;

    public MeasurementRepository(VMContext context)
    {
        _context = context;
    }

    public Measurement GetById(int id)
    {
        return _context.Measurements.Find(id);
    }

    public void Add(Measurement measurement)
    {
        _context.Measurements.Add(measurement);
        _context.SaveChanges();
    }

    public void Update(Measurement measurement)
    {
        _context.Measurements.Update(measurement);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var measurement = _context.Measurements.Find(id);
        if (measurement != null)
        {
            _context.Measurements.Remove(measurement);
            _context.SaveChanges();
        }
    }

    public List<Measurement> GetByWoundId(string woundId)
    {
        return _context.Measurements.Where(m => m.WoundId == woundId).ToList();
    }
}
