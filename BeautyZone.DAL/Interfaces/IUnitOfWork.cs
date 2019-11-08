using BeautyZone.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyZone.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        void Save();
    }
}
