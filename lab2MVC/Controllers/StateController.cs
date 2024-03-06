using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;

namespace lab2MVC.Controllers
{
    public class StateController : Controller
    {
        //State mangement using session (server side)
        public IActionResult SetSession()
        {
            //logic
            //save info server
            HttpContext.Session.SetString("Name", "Khloud Hisham");
            HttpContext.Session.SetString("Track", "Professional web");
            HttpContext.Session.SetInt32("AgeOfTrainee", 22);

            //Logic
            return Content("Data Saved successfully");

        }
        //Get Info From server
        //read session
        public IActionResult GetSession()
        {
            //to  retrieve string value
            string n = HttpContext.Session.GetString("Name");

            string m = HttpContext.Session.GetString("Track");

            //ToString retrieve The Number Value
            // int? count = HttpContext.Session.GetInt32("NumberOfTrainee");
            int d = HttpContext.Session.GetInt32("AgeOfTrainee").Value;
            return Content($"Get Data name={n}\t track={m}\t Age={d}");
        }

        //State mangement using Cookie (Client side)

        public IActionResult SetCookie()
        {
            int Number = 01234566;
            CookieOptions cookieOption = new CookieOptions();
            cookieOption.Expires = DateTime.Now.AddDays(1); //add 1 day to end cookie
            //Store cookie from Server to client  (response)
            HttpContext.Response.Cookies.Append("Name", "Khokha");//session Cookie

            HttpContext.Response.Cookies.Append("Phone_Number", Number.ToString(), cookieOption); //presistent cookie
            return Content("Cookie Saved successfully");
        }
        public IActionResult GetCookie()
        {
            int Number = 01234566;
            //Server Read cookie from client  (request)
            string? n = HttpContext.Request.Cookies["Name"];
            string? c = HttpContext.Request.Cookies["Phone_Number"];


            return Content($"Get Data From Cookie Name={n}\t Phone_Number={c} ");
        }

    }
}
