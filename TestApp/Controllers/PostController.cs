using Data.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TestApp.Data.Interfaces;
using TestApp.Models;
using TestApp.Repository;
using TestApp.ViewModels;

namespace TestApp.Controllers
{
	public class PostController : Controller
	{
        private readonly ILogger<PostController> _logger;
		private readonly IPostRepository _postRepository;



		private readonly UserManager<User> _userManager;
		private readonly DataContext _db;

		public PostController(UserManager<User> userManager,
			IPostRepository postRepository,
			DataContext db, ILogger<PostController> logger)
		{
			_db = db;
			_postRepository = postRepository;
			_userManager = userManager;
			_logger = logger;
		}



		public IActionResult Index()
		{
			return RedirectToAction("List");
		}


		public async Task<IActionResult> List()
		{
			var posts = await _postRepository.GetList();
			return View(posts);
		}

		public async Task<IActionResult> Details(Guid id)
		{
			Post post = await _postRepository.GetById(id);
			if (post == null)
			{
				return RedirectToAction("List");
			}
			return View(post);
		}

		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> CreateAsync(CreatePostViewModel createVM)
		{
			if (ModelState.IsValid)
			{
				var newPost = new Post
				{
					Title = createVM.Title,
					Text = createVM.Text,
					Photo = createVM.Photo,
					Category = createVM.Category,
					Date = DateTime.Now,
					User = await _userManager.FindByNameAsync(User.Identity.Name)

			};
				_postRepository.Add(newPost);
				return RedirectToAction("List");

			}

			return View(createVM);
		}

		[Authorize]
		public async Task<IActionResult> Edit(Guid id)
		{
			var post = await _postRepository.GetById(id);
			if (post == null || post.User.UserName != User.Identity.Name)
			{
				return RedirectToAction("List");

			}
			var EditPostVM = new EditPostViewModel
			{
				Title = post.Title,
				Text = post.Text,
				Photo = post.Photo,
				Category = post.Category,
			};
			return View(EditPostVM);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Delete(Guid id)
		{
			var post = await _postRepository.GetById(id);
			if (post != null || post.User.UserName!= User.Identity.Name)
			{
				return RedirectToAction("List");

			}
			_postRepository.Delete(post);
			return RedirectToAction("List");
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Edit(Guid id,EditPostViewModel EditPostVM)
		{
			if (ModelState.IsValid)
			{
				var post = await _postRepository.GetByIdNoTracking(id);
				if (post != null && post.User.UserName == User.Identity.Name)
				{
					var newPost = new Post
					{
						Id=id,
						Title = post.Title,
						Text = post.Text,
						Photo = post.Photo,
						Category = post.Category,
					};
					_postRepository.Update(newPost);
				}
				return RedirectToAction("List");
			}

			return View(EditPostVM);



		}


	}	
}
