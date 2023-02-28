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
    public class EmployeeDetailModel : PageModel
    {
        private readonly EmployeeRepository _employeeRepository;

        public Employee Employee { get; private set; }

        public EmployeeDetailModel(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetById(id);

            if (Employee == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
