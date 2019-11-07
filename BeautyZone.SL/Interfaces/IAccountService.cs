using BeautyZone.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyZone.SL.Interfaces
{
    public interface IAccountService
    {
        ApplicationUser GetByEmail(string email);

        ApplicationUser GetByUserName(string name);

        ApplicationUser GetById(string id);
    }
}
