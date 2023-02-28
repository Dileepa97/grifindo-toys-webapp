using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrifindoToys.Models;

namespace GrifindoToys.Repositories
{
    public class SalaryRepository
    {
        private readonly AppDbContext _context;

        public SalaryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IList<Salary> GetAll()
        {
            return _context.Salary.ToList();
        }

        public Salary GetById(int id)
        {
            return _context.Salary.Find(id);
        }

        public void Add(Salary salary)
        {
            _context.Salary.Add(salary);
            _context.SaveChanges();
        }
    }
}
