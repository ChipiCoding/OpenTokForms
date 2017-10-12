using Android.Content;
using OpenTokForms.Droid.Services;
using OpenTokForms.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenTokConnector))]
namespace OpenTokForms.Droid.Services
{
    public class OpenTokConnector : IOpenTokConnector
    {
        public void StartConversationActivity()
        {
            var intent = new Intent(Forms.Context, typeof(ConversationActivity));
            Forms.Context.StartActivity(intent);
        }
    }
}