using CEPCounsult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CEPCounsult.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Data.CEPContext _context;

        public HomeController(ILogger<HomeController> logger, Data.CEPContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string cep)
        {
            while (cep.Length > 8 || cep.Length < 8)
            {
                Response.StatusCode = 404;
                return View();
            }

            string viaCEPUrl = "https://viacep.com.br/ws/" + cep + "/json/";
            string result = string.Empty;

            using (WebClient client = new WebClient())
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                client.Encoding = Encoding.UTF8;
                result = client.DownloadString(viaCEPUrl);
            }

            CEP cepObject = JsonConvert.DeserializeObject<CEP>(result);
            _context.CEPs.Add(cepObject);
            _context.SaveChanges();

            Response.StatusCode = 200;
            return View();
        }

        [HttpGet]
        public IActionResult ListCEPs()
        {
            var ceps = _context.CEPs;

            return View(ceps);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ViewResult View()
        {
            var ceps = _context.CEPs;

            return View(ceps);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
