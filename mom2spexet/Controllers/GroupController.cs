using Microsoft.AspNetCore.Mvc;
using mom2spexet.Models;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace mom2spexet.Controllers
{
    public class GroupController : Controller
    {
        [Route("/lagg-till-grupp")]
        public IActionResult GroupForm()
        {
            ViewData["Title"] = "Lägg till grupp";
            return View();
        }

        [Route("/grupper")]
        public IActionResult Groups()
        {
            ViewData["Title"] = "Grupper";
            var JsonStr = System.IO.File.ReadAllText("groups.json");
            var JsonObj = JsonConvert.DeserializeObject<List<GroupModel>>(JsonStr);
            return View(JsonObj);
        }

        [HttpPost("/lagg-till-grupp")]
        public IActionResult GroupForm(GroupModel model)
        {
            if (ModelState.IsValid)
            {
                var JsonStr = System.IO.File.ReadAllText("groups.json");
                var JsonObj = JsonConvert.DeserializeObject<List<GroupModel>>(JsonStr);

                if (JsonObj != null)
                {
                    JsonObj.Add(model);
                    System.IO.File.WriteAllText("groups.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));

                    return RedirectToAction("Groups", "Group");
                }
            }
            return View();
        }
    }
}
