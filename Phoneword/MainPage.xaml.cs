using System.Threading.Tasks;

namespace Phoneword
{
    public partial class MainPage : ContentPage
    {

        string? translatedNumber;
        readonly string callPrefix = "Call ";

        public MainPage()
        {
            InitializeComponent();
        }

        public void OnTranslate(object sender, EventArgs e)
        {
            string enteredNumber = PhoneNumberText.Text;
            translatedNumber = PhonewordTranslator.ToNumber(enteredNumber);

            if (!string.IsNullOrEmpty(translatedNumber))
            {
                CallButton.IsEnabled = true;
                CallButton.Text = callPrefix + translatedNumber;
            }
            else
            {
                CallButton.IsEnabled = false;
                CallButton.Text = callPrefix.TrimEnd();
            }
        }

        public async void OnCall(object sender, EventArgs e)
        {
            if (await DisplayAlert(
                "Dial a number",
                "Would you like  to call " + translatedNumber,
                "Yes",
                "No"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported && !string.IsNullOrWhiteSpace(translatedNumber)) 
                        PhoneDialer.Open(translatedNumber);
                }
                catch (ArgumentException)
                {
                    await DisplayAlert("Unable to dial", "Phone number is not valid", "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert("Unable to dial", "Phone dial failed", "OK");
                }
            }
        }
    }

}
