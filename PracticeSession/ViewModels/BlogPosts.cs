using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticeSession.Models;

namespace PracticeSession.ViewModels
{
    public class BlogPosts
    {
        public Blog blog { get; set; }
        public IEnumerable<Post> posts { get; set; }
    }
}