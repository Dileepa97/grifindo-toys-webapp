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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EmployeeRepository _employeeRepository;
        public IndexModel(ILogger<IndexModel> logger, EmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public IList<Employee> Employees { get; set; }
        public string SearchString { get; set; }

        public void OnGet(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                SearchString = searchString.ToLower();
            }
            
            Employees = _employeeRepository.GetAll();

            if (!string.IsNullOrEmpty(SearchString))
            {
                Employees = Employees.Where(e => e.FirstName.ToLower().Contains(SearchString) || e.LastName.ToLower().Contains(SearchString)).ToList();
            }
        }


    }
}
