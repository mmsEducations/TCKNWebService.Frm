using TcknServiceReference;

Console.WriteLine("Tckn Service ");


KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);

Console.WriteLine("Lütfen Tckn Giriniz");
var tckn = long.Parse(Console.ReadLine());
Console.WriteLine("Lütfen Ad Giriniz");
var name = Console.ReadLine();
Console.WriteLine("Lütfen Soyad Giriniz");
var lastName = Console.ReadLine();
Console.WriteLine("Lütfen Dogum Giriniz");
var birthYear = Convert.ToInt32(Console.ReadLine());
Task<TCKimlikNoDogrulaResponse> response = client.TCKimlikNoDogrulaAsync(tckn, name, lastName, birthYear);
var message = response.Result.Body.TCKimlikNoDogrulaResult == true ? "Girdiğiniz bilgiler sistemde kayıtlı" : "Girdiğiniz bilgiler hatalı";
Console.WriteLine($"İşlem Sonucu : {message}");