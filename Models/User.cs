using System;
using System.ComponentModel.DataAnnotations;

namespace UserDashboard {
    
    public class User {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public int UserLevel { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}