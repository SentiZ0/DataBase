using DataBase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using DataBase.Data;
using DataBase.Services.Interfaces;

namespace DataBase.Pages
{
    public class IndexModel : PageModel
    {

        private readonly IPersonService _personService;

        public IQueryable<Person> a { get; set; }

        public IList<Person> People { get; set; }

        public string AlertMessage { get; set; }

        [BindProperty]
        public Person Person { get; set; }

        public IndexModel(IPersonService personService)
        {
            _personService = personService;
        }

        public IActionResult OnPost()
        {
            Person.CheckLeapYear();
            Person.DataUpdateTime = DateTime.Now;

            _personService.AddEntry(Person);

            if (!ModelState.IsValid)
            {
                if(Person.LastName == null)
                {
                    AlertMessage = $"Poprawnie przyjęto dane. {Person.DataUpdateTime}";
                }
                else
                {
                    AlertMessage = $"Wprowadzono niepoprawne dane. {Person.DataUpdateTime}";
                }              
                return Page();
            }
            else
            {
                AlertMessage = $"Poprawnie przyjęto dane. {Person.DataUpdateTime}";
                return Page();
            }

        }
        public void OnGet()
        {            
            People = _personService.GetAllEntries();
        }
    }
}