using Android.App;
using Android.Widget;
using Android.OS;
using Com.Opentok.Android;
using System;

namespace OpenTokForms.Droid
{
    [Activity(Label = "OpenTok", Icon = "@drawable/icon", ParentActivity = typeof(MainActivity))]
    public class ConversationActivity : Activity, Session.ISessionListener, PublisherKit.IPublisherListener
    {
        string API_KEY = "45967692";
        string SESSION_ID = "2_MX40NTk2NzY5Mn5-MTUwNjUxODgzNTQ0NX5aNWRHcFB0Mk1YU29vYitVbXcralFNRkN-fg";
        string TOKEN = "T1==cGFydG5lcl9pZD00NTk2NzY5MiZzaWc9Y2E3MGMzYTZhMGE1YWZlNTI4ZWVmZjJmNTY1YjM0OGI0YzYzZDAxYzpzZXNzaW9uX2lkPTJfTVg0ME5UazJOelk1TW41LU1UVXdOalV4T0Rnek5UUTBOWDVhTldSSGNGQjBNazFZVTI5dllpdFZiWGNyYWxGTlJrTi1mZyZjcmVhdGVfdGltZT0xNTA2NTE4ODkwJm5vbmNlPTAuNjIyOTE1MjAyMjk4MzI1MSZyb2xlPXB1Ymxpc2hlciZleHBpcmVfdGltZT0xNTA5MTEwODg4JmluaXRpYWxfbGF5b3V0X2NsYXNzX2xpc3Q9";

        private FrameLayout mPublisherViewContainer;
        private FrameLayout mSubscriberViewContainer;

        private Session mSession;
        private PublisherKit mPublisher;
        private SubscriberKit mSubscriber;

        public void OnConnected(Session p0)
        {
            mPublisher = new Publisher.Builder(this).Build();
            mPublisher.SetPublisherListener(this);

            mPublisherViewContainer.AddView(mPublisher.View);            
            mSession.Publish(mPublisher);
        }

        public void OnDisconnected(Session p0)
        {
            //throw new NotImplementedException();
        }

        public void OnError(Session p0, OpentokError p1)
        {
            //throw new NotImplementedException();
        }

        public void OnError(PublisherKit p0, OpentokError p1)
        {
            //throw new NotImplementedException();
        }

        public void OnStreamCreated(PublisherKit p0, Stream p1)
        {
            //throw new NotImplementedException();
        }

        public void OnStreamDestroyed(PublisherKit p0, Stream p1)
        {
            //throw new NotImplementedException();
        }

        public void OnStreamDropped(Session p0, Stream p1)
        {
            if (mSubscriber != null)
            {
                mSubscriber = null;
                mSubscriberViewContainer.RemoveAllViews();
            }
        }

        public void OnStreamReceived(Session p0, Stream p1)
        {
            if (mSubscriber == null)
            {
                mSubscriber = new Subscriber.Builder(this, p1).Build();
                mSession.Subscribe(mSubscriber);
                mSubscriberViewContainer.AddView(mSubscriber.View);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_conversation);

            mPublisherViewContainer = (FrameLayout)FindViewById(Resource.Id.publisher_container);
            mSubscriberViewContainer = (FrameLayout)FindViewById(Resource.Id.subscriber_container);

            IniciarSession();
        }

        private void IniciarSession()
        {
            mSession = new Session.Builder(this, API_KEY, SESSION_ID).Build();
            mSession.SetSessionListener(this);
            mSession.Connect(TOKEN);
        }
    }
}

