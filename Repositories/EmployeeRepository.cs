using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrifindoToys.Models;
using Microsoft.EntityFrameworkCore;

namespace GrifindoToys.Repositories
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<Employee> GetAll()
        {
            return _context.Employee.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employee.Find(id);
        }

        public void Add(Employee employee)
        {
            _context.Employee.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                _context.SaveChanges();

                return 1;
            }

            return 0;
        }
    }
}
