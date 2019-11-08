using BeautyZone.DAL.Interfaces;
using BeautyZone.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeautyZone.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DatabaseContext db;

        public UserRepository(DatabaseContext context)
        {
            db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Users.Update(user);
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
