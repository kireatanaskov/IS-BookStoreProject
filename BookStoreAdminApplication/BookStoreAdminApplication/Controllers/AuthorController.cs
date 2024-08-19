using DocumentFormat.OpenXml.Spreadsheet;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookStoreAdminApplication.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportAuthors(IFormFile file)
        {
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            List<Models.Author> authors = getAllAuthorsFromFile(file.FileName);
            HttpClient client = new HttpClient();
            string URL = "https://localhost:7128/api/Admin/ImportAuthors";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(authors), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<bool>().Result;

            return RedirectToAction("Index", "Order");
        }

        private List<Models.Author> getAllAuthorsFromFile(string fileName)
        {
            List<Models.Author> authors = new List<Models.Author>();
            string filePath = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        authors.Add(new Models.Author
                        {
                            FirstName = reader.GetValue(0).ToString(),
                            LastName = reader.GetValue(1).ToString(),
                            Age = Convert.ToInt32(reader.GetValue(2)),
                            Country = reader.GetValue(3).ToString(),
                            Image = reader.GetValue(4).ToString()
                        });
                    }

                }
            }
            return authors;

        }
    }
}
