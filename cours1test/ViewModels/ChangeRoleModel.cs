﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace cours1test.ViewModels
{
    public class ChangeRoleModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }

        public ChangeRoleModel()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }

    }
}
