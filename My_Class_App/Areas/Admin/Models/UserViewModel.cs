using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
//user view model
namespace My_Classes_App.Models
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
