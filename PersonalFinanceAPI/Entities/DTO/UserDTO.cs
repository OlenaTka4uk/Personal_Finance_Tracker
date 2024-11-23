using PersonalFinance.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.DTO
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;        
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Role Role { get; set; } = Role.User;
    }
}
