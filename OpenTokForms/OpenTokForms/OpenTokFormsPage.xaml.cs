using OpenTokForms.Interfaces;
using Xamarin.Forms;

namespace OpenTokForms
{
    public partial class OpenTokFormsPage : ContentPage
    {
        public OpenTokFormsPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IOpenTokConnector>().StartConversationActivity();
        }
    }
}
