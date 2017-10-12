// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace OpenTokForms.iOS
{
    partial class VideoChatView
	{
		[Outlet]
		UIKit.UIBarButtonItem HangupButton { get; set; }

		[Outlet]
		UIKit.UIView PublisherView { get; set; }

		[Outlet]
		UIKit.UILabel StatusLabel { get; set; }

		[Outlet]
		UIKit.UIView SubscriberView { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem SwitchButton { get; set; }

		[Outlet]
		UIKit.UIToolbar ToolBar { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (HangupButton != null) {
				HangupButton.Dispose ();
				HangupButton = null;
			}

			if (PublisherView != null) {
				PublisherView.Dispose ();
				PublisherView = null;
			}

			if (SubscriberView != null) {
				SubscriberView.Dispose ();
				SubscriberView = null;
			}

			if (SwitchButton != null) {
				SwitchButton.Dispose ();
				SwitchButton = null;
			}

			if (ToolBar != null) {
				ToolBar.Dispose ();
				ToolBar = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}
		}
	}
}
