using Autos_Bewertung_App.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Autos_Bewertung_App.Services
{
    public class JsonDateiAutoService
    {
        public JsonDateiAutoService(IWebHostEnvironment webHostEnvironment)
        {
            //IWebHostEnvironment Schnittstelle Enthält Informationen über die Webhostingumgebung, 
            //in der eine Anwendung ausgeführt wird.

            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFile
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "autos.json"); }
        }
        //WebRootPath: Ruft den absoluten Pfad zum Verzeichnis ab, 
        //das die webservable-Inhalts Dateien der Anwendung enthält, oder legt diesen fest.
        public IEnumerable<Auto> GetAutos()
        {
            //Lies die Json-Datei aus und gib eine Auto-Array zurück
            using (var jsonFileReader = File.OpenText(JsonFile))
            {
                return JsonSerializer.Deserialize<Auto[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        public void AddRating(int id, int rating)
        {
            var autos = GetAutos();
            var query = autos.First(x => x.Id == id);
            if (query.Bewertung == null)
            {
                query.Bewertung = new int[] { rating };
            }
            else
            {
                var ratings = query.Bewertung.ToList();
                ratings.Add(rating);
                query.Bewertung = ratings.ToArray();
            }

            //Schreib neue Bewertung in der Json-Datei
            using var outputStream = File.OpenWrite(JsonFile);
            JsonSerializer.Serialize<IEnumerable<Auto>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                autos
                );
        }
    }
}
