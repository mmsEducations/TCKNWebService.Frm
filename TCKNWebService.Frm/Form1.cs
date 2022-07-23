using TcknServiceReference;

namespace TCKNWebService.Frm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
             KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
             var tckn = long.Parse(txtTc.Text);
             var name = txtName.Text;
             var lastName = txtLastName.Text;
             var birthYear = Convert.ToInt32(numericUpDownBirthYear.Value);

            Task<TCKimlikNoDogrulaResponse> response = client.TCKimlikNoDogrulaAsync(tckn, name, lastName, birthYear);
            var result = response.Result.Body.TCKimlikNoDogrulaResult;
            var message = result == true ? "Girdiðiniz bilgiler sistemde kayýtlý" : "Girdiðiniz bilgiler hatalý";
            MessageBox.Show(message);
        }
    }
}