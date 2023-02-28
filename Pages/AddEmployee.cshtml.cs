using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrifindoToys.Models;
using GrifindoToys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GrifindoToys.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private readonly EmployeeRepository _employeeRepository;

        [BindProperty]
        public Employee Employee { get; set; }

        public AddEmployeeModel(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _employeeRepository.Add(Employee);

            return RedirectToPage("./Index");
        }
    }
}
