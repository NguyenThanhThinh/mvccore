using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Controllers
{
    using Models;

    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(categoryRepository.Categories);
        }

        public IActionResult AddCategory(Category category)
        {
            categoryRepository.AddCategogy(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditCategory(long id)
        {
            ViewBag.EditId = id;
            return View("Index", categoryRepository.Categories);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            categoryRepository.UpdateCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            categoryRepository.DeleteCategory(category);
            return RedirectToAction(nameof(Index));
        }
    }
}