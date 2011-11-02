using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Site.DAL;
using Site.Models;

namespace Site.Controllers
{
    [HandleError]
    public class BlogController : Controller
    {
        public BlogController()
        {
            ValidateRequest = false;
        }

        public ActionResult Index(int startFrom = 1)
        {
            using (var blogEntities = new BlogEntities())
            {
                List<Post> posts;

                var filteredPosts = blogEntities.Posts
                    .FilterDrafts();
                var count = filteredPosts.Count();
                var pageSize = 10;
                posts = filteredPosts
                    .OrderByDescending(post => post.Posted)
                    .Skip(startFrom - 1)
                    .Take(pageSize)
                    .ToList();
                var pager = new PagerModel {ShowFrom = startFrom, ItemCount = count, PageSize = pageSize};
                var blogModel = new BlogModel{Posts = posts, PagerModel = pager};
                return View(blogModel);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(Guid postID)
        {
            Post post = GetPostByID(postID);
            return View(post);
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Post modifiedPost)
        {

            var blogEntities = new BlogEntities();
            var postID = modifiedPost.ID;
            var originalPost = GetPostByID(postID);
            if (!ModelState.IsValid)
            {
                return View(originalPost);
            }

            blogEntities.Attach(originalPost);
            blogEntities.ApplyCurrentValues(originalPost.EntityKey.EntitySetName, modifiedPost);
            blogEntities.SaveChanges();

            return RedirectToRouteResult(postID);
        }

        private RedirectToRouteResult RedirectToRouteResult(Guid postID)
        {
            return RedirectToAction("Post", new { postID });
        }

        [ValidateInput(false)]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Post post)
        {
            if (String.IsNullOrEmpty(post.Title) || String.IsNullOrEmpty(post.Text))
            {
                return View();
            }
            post.ID = Guid.NewGuid();
            post.Posted = DateTime.Now;
            post.Index = post.Title;
            var blogEntities = new BlogEntities();
            blogEntities.AddToPosts(post);
            blogEntities.SaveChanges();

            return RedirectToRouteResult(post.ID);
        }

        public ActionResult Post(Guid postID)
        {
            Post post = GetPostByID(postID);
            return View(post);
        }

        private Post GetPostByID(Guid postID)
        {
            var blogEntities = new BlogEntities();
            var queryable = from post in blogEntities.Posts 
                            where post.ID == postID
                            select post;
            var result = queryable.Single();
            blogEntities.Detach(result);
            return result;
        }

        public ActionResult Delete(Guid postID)
        {
            var postByID = GetPostByID(postID);
            var blogEntities = new BlogEntities();
            blogEntities.Attach(postByID);
            blogEntities.DeleteObject(postByID);
            blogEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}