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
    public class SettingsModel : PageModel
    {
        private readonly SettingsRepository _settingsRepository;

        public SettingsModel(SettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public List<Settings> Settings { get; set; }

        public void OnGet()
        {
            Settings = _settingsRepository.GetAllSettings();
        }
       
        public IActionResult OnPost(string option, Dictionary<string, string> settings)
        {
            
            if (option != null && settings.ContainsKey(option))
            { 
                var value = settings[option];

                _settingsRepository.UpdateSetting(option, value);
            }

            return RedirectToPage("/Index");

        }

            
    }
}
