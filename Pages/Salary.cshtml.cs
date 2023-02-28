using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrifindoToys.Models;
using GrifindoToys.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace GrifindoToys.Pages
{
    public class SalaryModel : PageModel
    {
        private readonly SalaryRepository _salaryRepository;
        private readonly EmployeeRepository _employeeRepository;

        public SalaryModel( SalaryRepository salaryRepository, EmployeeRepository employeeRepository)
        {
            _salaryRepository = salaryRepository;
            _employeeRepository = employeeRepository;
        }

        public IList<Salary> Salaries { get; set; }
        public IList<Employee> Employees { get; set; }
        public IList<DateTime> CycleStartDates { get; set; }

        [BindProperty]
        public int? EmployeeId { get; set; }

        [BindProperty]
        public DateTime CycleStartDate { get; set; }

        public void OnGet(string employeeId, string cycleStartDate)
        {
            Salaries = _salaryRepository.GetAll();
            Employees = _employeeRepository.GetAll();
            CycleStartDates = Salaries.Select(s => s.CycleStartDate).Distinct().ToList();

            if (!String.IsNullOrEmpty(employeeId))
            {
                int eId = int.Parse(employeeId);
                Salaries = Salaries.Where(s => s.EmpId == eId).ToList();
                EmployeeId = eId;
            }

            if (!String.IsNullOrEmpty(cycleStartDate))
            {
                DateTime date = DateTime.Parse(cycleStartDate);
                Salaries = Salaries.Where(s => s.CycleStartDate == date).ToList();
                CycleStartDate = date;
            }
        }

        public IActionResult OnPostExportReport(string employeeId, string startDate)
        {
            var salaries = _salaryRepository.GetAll();
            string fileTitle = "";

            if (employeeId != "-1")
            {
                int eId = int.Parse(employeeId);
                var employee = _employeeRepository.GetById(eId);
                fileTitle = employee.FirstName + " " + employee.LastName + "\n";
                salaries = salaries.Where(s => s.EmpId == eId).ToList();
            }

            if (startDate != "0001-01-01")
            {
                DateTime date = DateTime.Parse(startDate);
                fileTitle = fileTitle + "Salary cycle start from: " + startDate + "\n";
                salaries = salaries.Where(s => s.CycleStartDate == date).ToList();
            }

            fileTitle = fileTitle + "Salary Report";

            var doc = new Document();
            var memoryStream = new MemoryStream();
            var writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();

            var titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
            var title = new Paragraph(fileTitle, titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);
            
            doc.Add(new Paragraph("\n"));

            var table = new PdfPTable(8);
            table.HorizontalAlignment = Element.ALIGN_LEFT;
            table.WidthPercentage = 100;
            table.SpacingBefore = 10;
            table.SpacingAfter = 10;

            var headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);

            var headerCell = new PdfPCell(new Phrase("Employee ID", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Cycle Start Date", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Cycle End Date", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Absent Days", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Overtime Hours", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("No Pay Value", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Base Pay Value", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);

            headerCell = new PdfPCell(new Phrase("Gross Pay Value", headerFont));
            headerCell.BackgroundColor = BaseColor.GRAY;
            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(headerCell);


            var dataFont = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
            foreach (var salary in salaries)
            {
                table.AddCell(new Phrase(salary.EmpId.ToString(), dataFont));
                table.AddCell(new Phrase(salary.CycleStartDate.ToString("yyyy-MM-dd"), dataFont));
                table.AddCell(new Phrase(salary.CycleEndDate.ToString("yyyy-MM-dd"), dataFont));
                table.AddCell(new Phrase(salary.AbsentDays.ToString(), dataFont));
                table.AddCell(new Phrase(salary.OTHours.ToString(), dataFont));
                table.AddCell(new Phrase(salary.NoPayValue.ToString(), dataFont));
                table.AddCell(new Phrase(salary.BasePayValue.ToString(), dataFont));
                table.AddCell(new Phrase(salary.GrossPayValue.ToString(), dataFont));
            }

            doc.Add(table);

            doc.Close();

            return File(memoryStream.ToArray(), "application/pdf", $"{DateTime.Now.ToString()}-salary-report.pdf");
        }
    }
}
