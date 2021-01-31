using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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





}