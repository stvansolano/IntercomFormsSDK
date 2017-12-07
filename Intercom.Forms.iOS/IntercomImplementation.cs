using System;
using System.Collections.Generic;
using Foundation;

namespace Intercom.Forms
{
	[Foundation.Preserve(AllMembers = true)]
	public class IntercomImplementation : IntercomBase
	{
		public override void Initialize(string apiKey, string intercomID) {
			//TODO perform initialization
			IntercomSDK_iOS.Intercom.SetApiKey(apiKey, intercomID);
			IntercomSDK_iOS.Intercom.SetLauncherVisible(false);
		}

		public override void LogEvent(string eventName) {
			IntercomSDK_iOS.Intercom.LogEventWithName(eventName);
		}

		public override void RegisterUser(string id, string email) {
			IntercomSDK_iOS.Intercom.RegisterUserWithUserId(id, email);
		}

		public override void Reset() {
			IntercomSDK_iOS.Intercom.Reset();
		}

		public override void SetDeviceToken(NSData deviceToken) {
			IntercomSDK_iOS.Intercom.SetDeviceToken(deviceToken);
		}

		public override void ShowMessenger() {
			IntercomSDK_iOS.Intercom.PresentMessenger();
		}

		public override void UpdateUser(IDictionary<string, object> customAttributes) {
			var userAttributes = new IntercomSDK_iOS.ICMUserAttributes();
			var keys = new List<Foundation.NSString>();
			var values = new List<Foundation.NSObject>();
			foreach (var pair in customAttributes) {
				keys.Add(new Foundation.NSString(pair.Key));
				values.Add(Foundation.NSObject.FromObject(pair.Value));
			}
			userAttributes.CustomAttributes = new Foundation.NSDictionary<Foundation.NSString, Foundation.NSObject>(keys.ToArray(), values.ToArray());
			IntercomSDK_iOS.Intercom.UpdateUser(userAttributes);
		}
	}
}
