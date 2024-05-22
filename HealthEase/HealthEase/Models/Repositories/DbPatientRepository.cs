namespace HealthEase.Models.Repositories
{
    public class DbPatientRepository:IRepository<Patient>
    {
        public AppDbContext Db { get; }

        public DbPatientRepository(AppDbContext _db)
        {
            Db = _db;
        }


        public void Active(int id, Patient entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(Patient entity)
        {
            Db.Patient.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Patient entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public Patient Find(int id)
        {
            return Db.Patient.SingleOrDefault(x => x.PatientId == id);
        }

        public void Update(int id, Patient entity)
        {
            Db.Patient.Update(entity);
            Db.SaveChanges();
        }

        public IList<Patient> View()
        {
            return Db.Patient.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Patient> ViewFormClient()
        {
            return Db.Patient.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
