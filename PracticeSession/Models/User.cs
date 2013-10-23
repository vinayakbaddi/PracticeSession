using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticeSession.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }
}