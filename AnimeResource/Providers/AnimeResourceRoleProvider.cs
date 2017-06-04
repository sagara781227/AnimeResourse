﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Helpers;
using System.Web.WebPages;
using Microsoft.Internal.Web.Utils;
using AnimeResource.Models;

namespace AnimeResource.Providers
{
    public class AnimeResourceRoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string login)
        {
            string[] role = new string[] { };
            using (AnimeContext _db = new AnimeContext())
            {
                try
                {
                    // Получаем пользователя
                    user user = (from u in _db.users
                                 where u.login == login
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        role userRole = _db.roles.Find(user.id_role);

                        if (userRole != null)
                        {
                            role = new string[] { userRole.name };
                        }
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            }
            return role;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            // Находим пользователя
            using (AnimeContext _db = new AnimeContext())
            {
                try
                {
                    // Получаем пользователя
                    user user = (from u in _db.users
                                 where u.login == username
                                 select u).FirstOrDefault();
                    if (user != null)
                    {
                        // получаем роль
                        role userRole = _db.roles.Find(user.id_role);

                        //сравниваем
                        if (userRole != null && userRole.name == roleName)
                        {
                            outputResult = true;
                        }
                    }
                }
                catch
                {
                    outputResult = false;
                }
            }
            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
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

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
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