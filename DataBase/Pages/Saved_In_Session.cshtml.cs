using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DataBase.Pages
{
    public class Saved_In_SessionModel : PageModel
    {
        public List<Person> Persons { get; set; }
        public void OnGet()
        {
            var data = HttpContext.Session.GetString("Data");
            if(!string.IsNullOrEmpty(data))
            {
                Persons = JsonConvert.DeserializeObject<List<Person>>(data);
            }
        }
    }
}
