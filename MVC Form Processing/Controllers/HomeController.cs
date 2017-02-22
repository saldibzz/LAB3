using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Form_Processing.Models;

namespace MVC_Form_Processing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
			var greeting = "";
			var time = DateTime.Now;
			if (time.Hour < 12)
			{
				greeting = "Good morning!";
			}
			else if (time.Hour >= 12 && time.Hour < 18)
			{
				greeting = "Good Afternoon!";
			}
			else
			{
				greeting = "Good Evening!";
			}

			var shortTime = time.ToString("hh:mm tt");
			var day = time.DayOfWeek.ToString();
			var month = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(time.Month);

			int daysInYear = DateTime.IsLeapYear(time.Year) ? 366 : 365;
			var daysleft = daysInYear - time.DayOfYear;

			
			ViewData["greeting"] = greeting;
			ViewData["shortTime"] = shortTime;
			ViewData["day"] = day;
			ViewData["dayofmonth"] = time.Day;
			ViewData["month"] = month;
			ViewData["year"] = time.Year;
			ViewData["daysleft"] = daysleft;

			return View();
        }

        public IActionResult ShowPerson()
        {
			Person person = new Person();
			person.firstName = "Michael";
			person.lastName = "Holder";
			person.birthDate = DateTime.ParseExact("24/01/2000", "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
			person.age = 17;

			ViewBag.Message = "Showing Person Details.";
			ViewBag.Person = person;

			return View(); 
        }
				
		
        public IActionResult Error()
        {
            return View();
        }

		
		
		[HttpGet]
		public IActionResult AddPerson()		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult AddPerson(Person person)
		{
			if (ModelState.IsValid)
			{
				ViewBag.Message = "Showing details of " + person.firstName;
				ViewBag.Person = person;
				return View("ShowPerson");
			}
			return View();
		}
	}
}
