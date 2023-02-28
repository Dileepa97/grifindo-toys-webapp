using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrifindoToys.Models;
using GrifindoToys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;

namespace GrifindoToys.Pages
{
    public class SalaryCalculationModel : PageModel
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly SettingsRepository _settingsRepository;
        private readonly SalaryRepository _salaryRepository;

        public SalaryCalculationModel ( EmployeeRepository employeeRepository, SettingsRepository settingsRepository, SalaryRepository salaryRepository)
        {
            _employeeRepository = employeeRepository;
            _settingsRepository = settingsRepository;
            _salaryRepository = salaryRepository;
            
        }

        [BindProperty]
        public IList<Employee> Employees { get; set; }
        public bool ShowSalarySection { get; set; } = false;
        public Employee SelectedEmployee { get; set; } = null;
        public decimal NoPayValue { get; set; } = 0;
        public decimal BasePayValue { get; set; } = 0;
        public decimal GrossPayValue { get; set; } = 0;
        public int AbsentDays { get; set; } = 0;
        public int OvertimeHours { get; set; } = 0;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public DateTime SalaryCycleStart { get; set; } = DateTime.Now;
        public DateTime SalaryCycleEnd { get; set; } = DateTime.Now;

        public void OnGet()
        {
            Employees = _employeeRepository.GetAll();
            SalaryCycleStart = DateTime.Parse(_settingsRepository.GetSettingByOption("Salary Cycle Start Date").value);
            SalaryCycleEnd = DateTime.Parse(_settingsRepository.GetSettingByOption("Salary Cycle End Date").value);
            StartDate = SalaryCycleStart;
            EndDate = SalaryCycleEnd;
        }


        public void OnPost(int employeeId, DateTime startDate, DateTime endDate, int absentDays, int overtimeHours)
        {
            AbsentDays = absentDays;
            OvertimeHours = overtimeHours;

            SalaryCycleStart = DateTime.Parse(_settingsRepository.GetSettingByOption("Salary Cycle Start Date").value);
            SalaryCycleEnd = DateTime.Parse(_settingsRepository.GetSettingByOption("Salary Cycle End Date").value);
            var salaryCycleDateRange = int.Parse(_settingsRepository.GetSettingByOption("Salary Cycle Date Range").value);
            var governmentTaxRate = decimal.Parse(_settingsRepository.GetSettingByOption("Government Tax Rate").value);

            SelectedEmployee =  _employeeRepository.GetById(employeeId);

            if (SelectedEmployee == null)
            {
                TempData["ErrorMessage"] = "Invalid employee selected.";
                Employees = _employeeRepository.GetAll();
                StartDate = SalaryCycleStart;
                EndDate = SalaryCycleEnd;
                return;
            }

            if (startDate != SalaryCycleStart)
            {
                TempData["ErrorMessage"] = "Invalid Salary Cycle Start Date.";
                Employees = _employeeRepository.GetAll();
                StartDate = SalaryCycleStart;
                EndDate = SalaryCycleEnd;
                return;
            }
            else if ( endDate != SalaryCycleEnd)
            {
                TempData["ErrorMessage"] = "Invalid Salary Cycle End Date.";
                Employees = _employeeRepository.GetAll();
                StartDate = SalaryCycleStart;
                EndDate = SalaryCycleEnd;
                return;
            }

            
            NoPayValue = (SelectedEmployee.MonthlySalary / salaryCycleDateRange) * absentDays;
            BasePayValue = SelectedEmployee.MonthlySalary + SelectedEmployee.Allowances + (overtimeHours * SelectedEmployee.OTPerHour);
            GrossPayValue = BasePayValue - (NoPayValue + BasePayValue * governmentTaxRate);

            Employees = _employeeRepository.GetAll();
            ShowSalarySection = true;
        }

        public IActionResult OnPostSaveSalary(int employeeId, DateTime startDate, DateTime endDate, int absentDays, int overtimeHours, decimal noPayValue, decimal basePayValue, decimal grossPayValue)
        {
            Salary salary = new Salary
            {
                EmpId = employeeId,
                CycleStartDate = startDate,
                CycleEndDate = endDate,
                AbsentDays = absentDays,
                OTHours = overtimeHours,
                NoPayValue = noPayValue,
                BasePayValue = basePayValue,
                GrossPayValue = grossPayValue
            };

            _salaryRepository.Add(salary);

            ShowSalarySection = false;
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostCanacelSave()
        {
            Employees = _employeeRepository.GetAll();
            ShowSalarySection = false;
            return RedirectToPage();
        }
    }
}
