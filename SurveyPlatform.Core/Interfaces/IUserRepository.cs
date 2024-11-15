﻿using SurveyPlatform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPlatform.Core.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}