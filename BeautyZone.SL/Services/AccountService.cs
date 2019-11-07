using BeautyZone.DAL.Interfaces;
using BeautyZone.DAL.Model;
using BeautyZone.SL.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace BeautyZone.SL.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUnitOfWork _unitOfWork;
        private UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ApplicationUser GetByEmail(string email)
        {
            ApplicationUser account = _unitOfWork.ApplicationUsers.GetByEmail(email);

            return new ApplicationUser { UserName = account.UserName, Email = account.Email, PhoneNumber = account.PhoneNumber };
        }

        public ApplicationUser GetById(string id)
        {
            ApplicationUser account = _userManager.FindByIdAsync(id).Result;

            return new ApplicationUser { Id = account.Id, UserName = account.UserName, Email = account.Email, PhoneNumber = account.PhoneNumber };
        }

        public ApplicationUser GetByUserName(string name)
        {
            ApplicationUser account = _userManager.FindByNameAsync(name).Result;

            return new ApplicationUser { Id = account.Id, UserName = account.UserName, Email = account.Email, PhoneNumber = account.PhoneNumber };
        }
    }
}
