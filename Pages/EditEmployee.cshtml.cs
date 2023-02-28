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
    public class EditEmployeeModel : PageModel
    {
        private readonly EmployeeRepository _employeeRepository;

        [BindProperty]
        public Employee Employee { get; set; }

        public EditEmployeeModel(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void OnGet(int id)
        {
            Employee = _employeeRepository.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.Update(Employee);
                return RedirectToPage("EmployeeDetail", new { id = Employee.Id });
            }
            return Page();
        }
    }
}
