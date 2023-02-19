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
            // Save title to ViewData
            ViewData["Title"] = "Lägg till medlem";

            return View();
        }

        [HttpPost("/lagg-till-medlem")]
        public IActionResult MemberForm(MemberModel model)
        {
            // Save title to ViewData
            ViewData["Title"] = "Lägg till medlem";

            // If statement to check that all required field isn't empty
            if (ModelState.IsValid)
            {
                // Calculate and save value to age property
                model.Age = DateTime.Now.Year - model.YOB;

                // Read data from JSON file
                var MemberStr = System.IO.File.ReadAllText("members.json");
                // Deserialize JSON string to objects
                var MemberObj = JsonConvert.DeserializeObject<List<MemberModel>>(MemberStr);

                // If statement to check the variable isn't empty
                if (MemberObj != null)
                {
                    // Add object from form to array
                    MemberObj.Add(model);

                    // Serialize objects to JSON string and write to JSON file
                    System.IO.File.WriteAllText("members.json", JsonConvert.SerializeObject(MemberObj, Formatting.Indented));

                    // Redirection to Members View
                    return RedirectToAction("Members", "Member");
                }
            }

            return View();
        }

        [Route("/medlemmar")]
        public IActionResult Members()
        {
            // Save title to ViewData
            ViewData["Title"] = "Medlemmar";

            // Read data from JSON file
            var MemberStr = System.IO.File.ReadAllText("members.json");

            // Deserialize JSON string to objects
            var MemberObj = JsonConvert.DeserializeObject<List<MemberModel>>(MemberStr);

            // Save total number of members to ViewBag
            ViewBag.TotalMembers = MemberObj.Count();

            // Send objects to view
            return View(MemberObj);
        }
    }
}
