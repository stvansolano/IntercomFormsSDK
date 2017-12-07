using System;
using System.Collections.Generic;

namespace Intercom.Forms
{
	public interface IIntercom : IDisposable
	{
		void Initialize(string apiKey, string intercomID);
		void Reset();
		void ShowMessenger();
		void LogEvent(string eventName);
		void RegisterUser(string id, string email);
		void UpdateUser(IDictionary<string, object> customAttributes);
#if __IOS__
		void SetDeviceToken (Foundation.NSData deviceToken);
#endif
	}
}
