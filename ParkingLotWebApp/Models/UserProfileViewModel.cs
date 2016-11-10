using My.Core.Infrastructures.Implementations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingLotWebApp.Models
{
    public class UserProfileViewModel : ApplicationUser
    {

        private IApplicationRoleRepository roleRepo;

        public UserProfileViewModel() : base()
        {
            roleRepo = My.Core.Infrastructures.Implementations.Models.RepositoryHelper.GetApplicationRoleRepository();
        }

        public void SetUnitOfWork(My.Core.Infrastructures.Implementations.Models.IUnitOfWork unitofwork)
        {
            roleRepo.UnitOfWork = unitofwork;
        }
        public UserProfileViewModel(My.Core.Infrastructures.Implementations.Models.IUnitOfWork unitofwork):base()
        {
            roleRepo = My.Core.Infrastructures.Implementations.Models.RepositoryHelper.GetApplicationRoleRepository(unitofwork);
        }

        private int getRoleId()
        {
            if (ApplicationRole.Any())
            {
                return ApplicationRole.First().Id;
            }

            return 0;
        }

        private void setRoleId(int value)
        {
            int currentroleid = getRoleId();
            if (currentroleid != value)
            {
                //先移除現在的
                ApplicationRole.Clear();

                //再加入新增的
                ApplicationRole.Add(roleRepo.FindById(value));
            }
        }

        public int RoleId { get { return getRoleId(); } set { setRoleId(value); } }

    }
}