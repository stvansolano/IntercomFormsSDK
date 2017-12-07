using System;
using System.Collections.Generic;

namespace Intercom.Forms
{
	public abstract class IntercomBase : IIntercom, IDisposable
	{
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing) {
			if (!disposed) {
				if (disposing) {
					//dispose only
				}

				disposed = true;
			}
		}

		public abstract void Initialize(string apiKey, string intercomID);

		public abstract void Reset();

		public abstract void ShowMessenger();

		public abstract void LogEvent(string eventName);

		public abstract void RegisterUser(string id, string email);

		public abstract void UpdateUser(IDictionary<string, object> customAttributes);
#if __IOS__
		public abstract void SetDeviceToken (Foundation.NSData deviceToken);
#endif
	}
}
