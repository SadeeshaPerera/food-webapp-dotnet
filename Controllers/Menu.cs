using Microsoft.AspNetCore.Mvc;
using food_webapp_dotnet.Data;
using food_webapp_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace food_webapp_dotnet.Controllers
{
	public class Menu : Controller
	{
	    private readonly MenuContext _context;
		public Menu(MenuContext context)
		{
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			return View( await _context.Dishes.ToListAsync());
		}
	}
}
