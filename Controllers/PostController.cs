using Forum_App.Contracts;
using Forum_App.Models;
using Forum_App.Service;
using Microsoft.AspNetCore.Mvc;

namespace Forum_App.Controllers
{
    public class PostController : Controller
    {
       private readonly IForumService forumService;
       public PostController(IForumService _forumService)
       {
           forumService = _forumService;
       }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
           var model = await forumService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new PostFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await forumService
           .AddPostAsync(model);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await forumService.
            DeletePostAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await forumService.GetByIdAsync(id); 
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

        
            await forumService.UpdatePostAsync(model);

            return RedirectToAction(nameof(Index));
        }
        

    }
}
