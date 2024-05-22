namespace HealthEase.Models.Repositories
{
    public class DbAppointmentRepository:IRepository<Appointment>
    {
        public AppDbContext Db { get; }

        public DbAppointmentRepository(AppDbContext _db)
        {
            Db = _db;
        }


        public void Active(int id, Appointment entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(Appointment entity)
        {
            Db.Appointment.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Appointment entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public Appointment Find(int id)
        {
            return Db.Appointment.SingleOrDefault(x => x.AppointmentId == id);
        }

        public void Update(int id, Appointment entity)
        {
            Db.Appointment.Update(entity);
            Db.SaveChanges();
        }

        public IList<Appointment> View()
        {
            return Db.Appointment.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Appointment> ViewFormClient()
        {
            return Db.Appointment.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
