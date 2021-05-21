using Autos_Bewertung_App.Models;
using Autos_Bewertung_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autos_Bewertung_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //Ein Instanz der Service
        public JsonDateiAutoService AutoService { get; set; }

        //Eine Enumerable Autos-Kette, um sie zu zeigen.
        public IEnumerable<Auto> Autos { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, 
            JsonDateiAutoService jsonDateiAutoService)
        {
            _logger = logger;
            AutoService = jsonDateiAutoService;
        }
        public void OnGet()
        {
            Autos = AutoService.GetAutos();
        }
    }
}
