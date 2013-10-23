using PracticeSession.DAL;
using PracticeSession.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PracticeSession.Controllers
{
    public class EntityFrameworkMVCController : Controller
    {
        private BloggingContext db = new BloggingContext();
 
        [HttpGet]
        public ActionResult AddBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBlog(Blog blog)
        {
            db.Blogs.Add(blog);
            db.SaveChanges();
            return View();
        }

        public ActionResult ListBlogs()
        {
            var listBlogsByName = from blog in db.Blogs
                                  orderby blog.Name
                                  select blog;

            return View(listBlogsByName);
        }

        public ActionResult Delete(Int32? id)
        {
            var blog = db.Blogs.Where(d => d.BlogId == id).FirstOrDefault<Blog>();
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Int32? id)
        {
            var blog = db.Blogs.Where(e => e.BlogId == id).FirstOrDefault<Blog>();

            return View(blog);
        }

        [HttpPost]
        public ActionResult Edit(Blog blog)
        {
            db.Entry(blog).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult CreatePosts()
        {
            var blog= from blog in db.Blogs
                       select blog;

            var post = new Post()
            {
                Blog = blog
            };
            return View();
        }

        [HttpPost]
        public ActionResult CreatePosts(Post post)
        {
            db.Posts.Add(post);
            db.SaveChanges();

            return View();
        }

    }
}
