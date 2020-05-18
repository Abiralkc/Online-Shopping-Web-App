using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using FinalProject.Models;

namespace FinalProject
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            using (MorningBroadway1Entities db = new MorningBroadway1Entities())
            {
                var objUser = db.tblUsers.FirstOrDefault(x => x.Username == username);
                if (objUser == null)
                {
                    return null;
                }
                else
                {
                    string[] ret = db.tblUserRoles.Select(x => x.tblRole.RoleName).ToArray();
                    return ret;
                }
            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string RoleName)
        {
            var userRoles = GetRolesForUser(username);
            return userRoles.Contains(RoleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}