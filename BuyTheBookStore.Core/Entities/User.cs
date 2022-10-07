using BuyTheBookStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTheBookStore.BuyTheBookStore.Core.Entities
{
    public class User:BaseEntity
    {
        public enum ROLE
        {
            ADMIN, CUSTOMER
        }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public ROLE Role { get; set; }
        public string RoleText
        {
            get { return Role.ToString(); }
            set { Role = (ROLE)System.Enum.Parse(typeof(ROLE), value); }
        }

        public virtual ICollection<Order> Orders { get; set; }  
    }
}
