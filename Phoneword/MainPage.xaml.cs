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

        private void OnCall(object sender, EventArgs e)
        {

        }
    }

}
