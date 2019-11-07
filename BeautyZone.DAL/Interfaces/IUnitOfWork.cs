using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyZone.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUsers { get; }

        void Save();
    }
}
