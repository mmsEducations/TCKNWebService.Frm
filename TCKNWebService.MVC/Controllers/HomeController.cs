using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TcknServiceReference;
using TCKNWebService.MVC.Models;

namespace TCKNWebService.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CheckTckn(131373213, "", "", 1990);
            return View();
        }

        public bool CheckTckn(long tCKimlikNo, string name, string lastName, int birthYear)
        {

            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            Task<TCKimlikNoDogrulaResponse> response = client.TCKimlikNoDogrulaAsync(tCKimlikNo, name, lastName, birthYear);
            var result = response.Result.Body.TCKimlikNoDogrulaResult;
            return result;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}