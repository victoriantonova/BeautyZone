using BeautyZone.DAL.Interfaces;
using BeautyZone.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyZone.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext db;

        private ApplicationUserRepository userRepository;

        public UnitOfWork(DbContextOptions<DatabaseContext> options)
        {
            db = new DatabaseContext(options);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        IApplicationUserRepository IUnitOfWork.ApplicationUsers
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new ApplicationUserRepository(db);
                }

                return userRepository;
            }
        }
    }
}
