namespace HealthEase.Models.Repositories
{
    public class DbDoctorRepository:IRepository<Doctor>
    {
        public AppDbContext Db { get; }

        public DbDoctorRepository(AppDbContext _db)
        {
            Db = _db;
        }


        public void Active(int id, Doctor entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(Doctor entity)
        {
            Db.Doctor.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Doctor entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public Doctor Find(int id)
        {
            return Db.Doctor.SingleOrDefault(x => x.DoctorId == id);
        }

        public void Update(int id, Doctor entity)
        {
            Db.Doctor.Update(entity);
            Db.SaveChanges();
        }

        public IList<Doctor> View()
        {
            return Db.Doctor.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Doctor> ViewFormClient()
        {
            return Db.Doctor.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
