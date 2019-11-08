using BeautyZone.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeautyZone.BLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserBLL user);
        UserBLL GetUser(int id);
        List<UserBLL> GetUsers();
        void UpdateUser(UserBLL user);
        void DeleteUser(int id);
    }
}
