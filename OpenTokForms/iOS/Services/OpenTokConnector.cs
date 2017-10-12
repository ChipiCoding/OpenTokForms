using OpenTokForms.Interfaces;
using OpenTokForms.iOS.Services;
using System;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenTokConnector))]
namespace OpenTokForms.iOS.Services
{
    public class OpenTokConnector : IOpenTokConnector
    {
        public void StartConversationActivity()
        {
            var Storyboard = UIStoryboard.FromName("LaunchScreen", null);
            UIViewController uiview = Storyboard.InstantiateViewController("LaunchScreen");
            uiview.Init();
            //NavigationController.PushViewController(uiview, true);
        }
    }
}
