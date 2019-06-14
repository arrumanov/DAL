using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Garden.WebApp.Models;
using Garden.Core.DAL;
using System.Linq;
using Garden.Core.DAL.Specification;
using Garden.Core.DAL.Fetch.Articles;
using Garden.Core.DAL.Sort;
using Garden.Core.DAL.Sort.EntitySortingTypes;
using Garden.Core.Enums;
using Garden.Core.Entities;
using System;

namespace Garden.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IStorage storage;

        public HomeController(IStorage storage)
        {
            this.storage = storage;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Your main page.";

            return View();
        }

        public IActionResult Articles(CategoryTypes categoryType)
        {
            ViewBag.CategoryType = categoryType;

            var result = storage.Articles.Find(
                storage.GetSpecificationBuilder<IArticleBuilder>().ByCategoryType(categoryType).Build(),
                sort: storage.GetSort<ISortArticle>().AddSort(ArticleSortingType.DateDescNameAsc)
                ).ToList();
            return View(result);
        }

        [HttpPost]
        public void CreateArticle(Article article)
        {
            article.Date = DateTime.Today;
            article.Id = new Random().Next(1, 9999999);
            storage.Articles.Create(article);
            storage.Save();
        }

        public IActionResult Article(int Id)
        {
            ViewBag.ArticleId = Id;

            var result = storage.Articles.Read(
                storage.GetSpecificationBuilder<IArticleBuilder>().ById(Id).Build(),
                fetch: storage.GetFetch<IFetchArticleWithComments>()
                );
            return View(result);
        }

        [HttpPost]
        public void CreateComment(Comment comment)
        {
            comment.Date = DateTime.Today;
            comment.Id = new Random().Next(1, 9999999);
            storage.Comments.Create(comment);
            storage.Save();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
