using BeautyZone.DAL.Interfaces;
using BeautyZone.DAL.Model;
using BeautyZone.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BeautyZone.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext db;
        private readonly DbContextOptionsBuilder context;

        private UserRepository userRepository;

        public UnitOfWork(DatabaseContext connectionString)
        {
            db = connectionString;
        }
        public UnitOfWork(DbContextOptionsBuilder connectionString)
        {
            context = connectionString;
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
