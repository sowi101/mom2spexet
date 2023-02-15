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
            // Save title to ViewData
            ViewData["Title"] = "Lägg till grupp";

            return View();
        }

        [HttpPost("/lagg-till-grupp")]
        public IActionResult GroupForm(GroupModel model)
        {
            // If statement to check that all required field isn't empty
            if (ModelState.IsValid)
            {
                // Read data from JSON file
                var GroupStr = System.IO.File.ReadAllText("groups.json");
                // Deserialize JSON string to objects
                var GroupObj = JsonConvert.DeserializeObject<List<GroupModel>>(GroupStr);

                // If statement to check the variable isn't empty
                if (GroupObj != null)
                {
                    // Add object from form to array
                    GroupObj.Add(model);

                    // Serialize objects to JSON string and write to JSON file
                    System.IO.File.WriteAllText("groups.json", JsonConvert.SerializeObject(GroupObj, Formatting.Indented));

                    // Redirection to Groups View
                    return RedirectToAction("Groups", "Group");
                }
            }

            return View();
        }

        [Route("/grupper")]
        public IActionResult Groups()
        {
            // Save title to ViewData
            ViewData["Title"] = "Grupper";

            // Read data from JSON file
            var GroupStr = System.IO.File.ReadAllText("groups.json");
            // Deserialize JSON string to objects
            var GroupObj = JsonConvert.DeserializeObject<List<GroupModel>>(GroupStr);

            // Send objects to view
            return View(GroupObj);
        }
    }
}
