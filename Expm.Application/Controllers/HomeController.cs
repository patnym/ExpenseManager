using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Expm.Application.Models;
using Expm.Core.Exepense.Commands;
using Expm.Core;
using Expm.Core.Exepense;

namespace Expm.Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly CreateExpenseCommandHandler _cHandler;
        // private readonly GetExpenseCommandHandler _rHandler;
        public HomeController(IUnitOfWork unitOfWork) 
        {
            _cHandler = new CreateExpenseCommandHandler(unitOfWork);
        }

        public async Task<IActionResult> Index()
        {
            var expense = await _cHandler.Handle(new CreateExpenseCommand {
                Name = Guid.NewGuid().ToString()
            });

            return View(new IndexModel {
                Expenses = new List<ExpenseDto> {
                    expense
                }
            });
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
