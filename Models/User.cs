using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


//NOTE https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx 
namespace TrivitalTracker.Models
{
    public class User
    {
        public int ID;
        public string Username;
        public string Email;
        public string Password; 
    }
    public class AccountDetails{
        public int AccountID;
        public int UserID;
        public string name;
        
    }

    public class UserSetting{
        public int SettingID;
        public int UserID;
        
    }



}