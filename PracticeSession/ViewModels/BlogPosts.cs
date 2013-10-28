using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeSession.Models;

namespace PracticeSession.ViewModels
{
    public class BlogPosts
    {
        public IEnumerable<Blog> blog { get; set; }
        public Post posts { get; set; }
    }
}