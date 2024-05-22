
namespace HealthEase.Models.Repositories
{
    public class DbAdminnnRepository : IRepository<Adminn>
    {
        public AppDbContext Db { get; }

        public DbAdminnnRepository(AppDbContext _db)
        {
            Db = _db;
        }


        public void Active(int id, Adminn entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(Adminn entity)
        {
            Db.Adminn.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Adminn entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public Adminn Find(int id)
        {
            return Db.Adminn.SingleOrDefault(x => x.AdminnId == id);
        }

        public void Update(int id, Adminn entity)
        {
            Db.Adminn.Update(entity);
            Db.SaveChanges();
        }

        public IList<Adminn> View()
        {
            return Db.Adminn.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Adminn> ViewFormClient()
        {
            return Db.Adminn.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
