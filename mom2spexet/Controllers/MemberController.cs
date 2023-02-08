using mom2spexet.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace mom2spexet.Controllers
{
    public class MemberController : Controller
    {
        [Route("/lagg-till-medlem")]
        public IActionResult MemberForm()
        {
            ViewData["Title"] = "Lägg till medlem";
            return View();
        }

        [Route("/medlemmar")]
        public IActionResult Members()
        {
            ViewData["Title"] = "Medlemmar";

            var JsonStr = System.IO.File.ReadAllText("members.json");
            var JsonObj = JsonConvert.DeserializeObject<List<MemberModel>>(JsonStr);

            ViewBag.TotalMembers = JsonObj.Count();
            return View(JsonObj);
        }

        [HttpPost("/lagg-till-medlem")]
        public IActionResult MemberForm(MemberModel model)
        {
            if (ModelState.IsValid)
            {
                model.Age = DateTime.Now.Year-model.YOB;

                var JsonStr = System.IO.File.ReadAllText("members.json");
                var JsonObj = JsonConvert.DeserializeObject<List<MemberModel>>(JsonStr);

                if(JsonObj != null)
                {
                    JsonObj.Add(model);
                    System.IO.File.WriteAllText("members.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                    return RedirectToAction("Members", "Member");
                }
            }
            return View();
        }
    }
}
