namespace HealthEase.Models.Repositories
{
    public class DbDepartmentRepository:IRepository<Department>
    {
        public AppDbContext Db { get; }

        public DbDepartmentRepository(AppDbContext _db)
        {
            Db = _db;
        }


        public void Active(int id, Department entity)
        {
            var data = Find(id);
            data.IsActive = !data.IsActive;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public void Add(Department entity)
        {
            Db.Department.Add(entity);
            Db.SaveChanges();
        }

        public void Delete(int id, Department entity)
        {
            var data = Find(id);
            data.IsDelete = true;
            data.EditUser = entity.EditUser;
            data.EditDate = entity.EditDate;
            Update(id, data);
        }

        public Department Find(int id)
        {
            return Db.Department.SingleOrDefault(x => x.DepartmentId == id);
        }

        public void Update(int id, Department entity)
        {
            Db.Department.Update(entity);
            Db.SaveChanges();
        }

        public IList<Department> View()
        {
            return Db.Department.Where(x => x.IsDelete == false).ToList();
        }

        public IList<Department> ViewFormClient()
        {
            return Db.Department.Where(x => x.IsActive == true && x.IsDelete == false).ToList();
        }
    }
}
