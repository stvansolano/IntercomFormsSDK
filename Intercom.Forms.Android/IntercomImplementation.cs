using System;
using System.Collections.Generic;
using IntercomSdk = IO.Intercom.Android.Sdk.Intercom;
using IO.Intercom.Android.Sdk.Identity;
using IO.Intercom.Android.Sdk;

namespace Intercom.Forms
{
	[Android.Runtime.Preserve(AllMembers = true)]
	public class IntercomImplementation : IntercomBase
	{
		public override void Initialize(string apiKey, string intercomID) {
			//TODO initialize intercom with the bindings library
			//IO.Intercom.Android.Sdk.Intercom.Initialize()
			var app = Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity.Application;
			IntercomSdk.Initialize(app, apiKey, intercomID);
		}

		public override void LogEvent(string eventName) {
			IntercomSdk.Client().LogEvent(eventName);
		}

		public override void RegisterUser(string id, string email) {
			IntercomSdk.Client().RegisterIdentifiedUser(Registration.Create().WithUserId(id).WithEmail(email));
		}

		public override void Reset() {
			IntercomSdk.Client().Reset();
		}

		public override void ShowMessenger() {
			IntercomSdk.Client().DisplayMessenger();
		}

		public override void UpdateUser(IDictionary<string, object> customAttributes) {
			var userAttributes = new UserAttributes.Builder().WithCustomAttributes(customAttributes).Build();
			IntercomSdk.Client().UpdateUser(userAttributes);
		}
	}
}
