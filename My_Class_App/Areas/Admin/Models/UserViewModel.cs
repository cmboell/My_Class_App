using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
//user view model
namespace My_Classes_App.Models
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
