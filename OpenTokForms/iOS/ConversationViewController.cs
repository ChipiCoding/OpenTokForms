using System;

using OpenTok;
using UIKit;
using CoreGraphics;
using System.Diagnostics;

namespace OpenTokForms.iOS
{
    //public partial class ConversationViewController : UIViewController
    //{
    //    string API_KEY = "45967692";
    //    string SESSION_ID = "2_MX40NTk2NzY5Mn5-MTUwNjUxODgzNTQ0NX5aNWRHcFB0Mk1YU29vYitVbXcralFNRkN-fg";
    //    string TOKEN = "T1==cGFydG5lcl9pZD00NTk2NzY5MiZzaWc9Y2E3MGMzYTZhMGE1YWZlNTI4ZWVmZjJmNTY1YjM0OGI0YzYzZDAxYzpzZXNzaW9uX2lkPTJfTVg0ME5UazJOelk1TW41LU1UVXdOalV4T0Rnek5UUTBOWDVhTldSSGNGQjBNazFZVTI5dllpdFZiWGNyYWxGTlJrTi1mZyZjcmVhdGVfdGltZT0xNTA2NTE4ODkwJm5vbmNlPTAuNjIyOTE1MjAyMjk4MzI1MSZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNTA5MTEwODg4JmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9";

    //    public OTSession Session;
    //    public OTPublisher Publisher;
    //    public OTSubscriber Subscriber;

    //    public ConversationViewController() : base("ConversationViewController", null)
    //    {
    //    }

    //    public override void DidReceiveMemoryWarning()
    //    {
    //        base.DidReceiveMemoryWarning();
    //        // Release any cached data, images, etc that aren't in use.
    //    }

    //    private void ConnectToAnOpenTokSession()
    //    {
    //        //TODO
    //        Session = new OTSession(API_KEY, SESSION_ID, null);
    //        OTError error;

    //        Session.ConnectWithToken(TOKEN, out error);            
    //    }



    //private void OnDidConnect(object sender, EventArgs e)
    //{
    //    OTPublisherSettings Settings = new OTPublisherSettings();
    //    Settings.Name = UIDevice.CurrentDevice.Name;

    //    //TODO
    //    //Publisher = new OTPublisher(null, Settings);
    //    Publisher = new OTPublisher(null, Settings);
    //    OTError error;
    //    Session.Publish(Publisher, out error);
    //    if (error != null)           
    //        return;

    //    UIView publisherView = Publisher.View;
    //    CGRect screenBounds = UIScreen.MainScreen.Bounds;
    //    publisherView.Frame = new CGRect(x: screenBounds.Width - 150 - 20, y: screenBounds.Height - 150 - 20, width: 150, height: 150);
    //    View.AddSubview(publisherView);            
    //}







    //    public override void ViewDidLoad()
    //    {
    //        base.ViewDidLoad();
    //        ConnectToAnOpenTokSession();
    //        // Perform any additional setup after loading the view, typically from a nib.
    //    }
    //}



    public partial class ConversationViewController : UIViewController
    {
        VideoChatView _videoChatView;

        string API_KEY = "45967692";
        string SESSION_ID = "2_MX40NTk2NzY5Mn5-MTUwNjUxODgzNTQ0NX5aNWRHcFB0Mk1YU29vYitVbXcralFNRkN-fg";
        string TOKEN = "T1==cGFydG5lcl9pZD00NTk2NzY5MiZzaWc9Y2E3MGMzYTZhMGE1YWZlNTI4ZWVmZjJmNTY1YjM0OGI0YzYzZDAxYzpzZXNzaW9uX2lkPTJfTVg0ME5UazJOelk1TW41LU1UVXdOalV4T0Rnek5UUTBOWDVhTldSSGNGQjBNazFZVTI5dllpdFZiWGNyYWxGTlJrTi1mZyZjcmVhdGVfdGltZT0xNTA2NTE4ODkwJm5vbmNlPTAuNjIyOTE1MjAyMjk4MzI1MSZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNTA5MTEwODg4JmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9";

        public ConversationViewController() : base("ConversationViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Hide top Nav bar
            this.NavigationController.SetNavigationBarHidden(true, false);

            // Configure the Video Chat View
            _videoChatView = new VideoChatView()
            {
                Frame = View.Frame,
                ApiKey = API_KEY,
                SessionId = SESSION_ID,
                Token = TOKEN,
                SubscribeToSelf = true
            };

            // Add The View
            View.AddSubview(_videoChatView);

            // Subscribe to Events
            _videoChatView.OnHangup += (sender, e) =>
            {
                Debug.WriteLine("OnHangup: User tapped the hangup button.");
            };

            _videoChatView.OnError += (sender, e) =>
            {
                Debug.WriteLine(e.Message);

                this.ShowAlert(e.Message);
            };

            // Connect to Session
            _videoChatView.Connect();
        }

        private void ShowAlert(string message)
        {
            UIAlertView alert = new UIAlertView("Alert", message, null, "Ok");

            alert.Show();
        }
    }
    public class SessionDelegate : OTSessionDelegate
    {
        public override void DidConnect(OTSession session)
        {
            base.DidConnect(session);
        }
    }
}