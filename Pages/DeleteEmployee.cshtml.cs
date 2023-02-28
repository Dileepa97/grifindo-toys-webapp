using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrifindoToys.Models;
using GrifindoToys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GrifindoToys.Pages
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly EmployeeRepository _employeeRepository;

        public DeleteEmployeeModel(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetById(id);

            if (Employee == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var employeeToDelete = _employeeRepository.GetById(id);

            if (employeeToDelete == null)
            {
                return RedirectToPage("/Index");
            }

            _employeeRepository.Delete(id);

            return RedirectToPage("/Index");
        }
    }
}
