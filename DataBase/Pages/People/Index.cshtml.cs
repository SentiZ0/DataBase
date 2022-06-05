#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBase.Data;
using DataBase.Models;
using DataBase.Services.Interfaces;

namespace DataBase.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly IPersonService _personService;

        public IndexModel(IPersonService personService)
        {
            _personService = personService;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = _personService.GetAllEntries();
        }
    }
}
