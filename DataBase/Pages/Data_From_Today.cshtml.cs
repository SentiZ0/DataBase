using DataBase.Models;
using DataBase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DataBase.Pages
{
    public class Saved_In_SessionModel : PageModel
    {
        public List<Person> Persons { get; set; }

        private readonly IPersonService _personService;

        public Saved_In_SessionModel(IPersonService personService)
        {
            _personService = personService;
        }

        public void OnGet()
        {
            Persons = _personService.GetEntriesFromToday();
        }
    }
}
