using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TcknServiceReference;

namespace TCKNWebService.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCKNWebServiceController : ControllerBase
    {

        [HttpGet(Name = "CheckTckn")]
        public bool CheckTckn(long tCKimlikNo,string name , string lastName, int birthYear)
        {

            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            Task<TCKimlikNoDogrulaResponse> response = client.TCKimlikNoDogrulaAsync(tCKimlikNo, name, lastName, birthYear);
            var result = response.Result.Body.TCKimlikNoDogrulaResult;
            return result;
        }
    }
}
