using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrifindoToys.Models;
using Microsoft.EntityFrameworkCore;

namespace GrifindoToys.Repositories
{
    public class SettingsRepository
    {
        private readonly AppDbContext _context;

        public SettingsRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Settings> GetAllSettings()
        {
            return _context.Settings.ToList();
        }

        public Settings GetById(int id)
        {
            return _context.Settings.Find(id);
        }

        public Settings GetSettingByOption(string option)
        {
            return _context.Settings.FirstOrDefault(s => s.option == option);
        }

        public void UpdateSetting(string option, string newValue)
        {
            var setting = GetSettingByOption(option);
            if (setting != null)
            {
                setting.value = newValue;
                _context.Settings.Update(setting);
                _context.SaveChanges();
            }
        }
    }
}
