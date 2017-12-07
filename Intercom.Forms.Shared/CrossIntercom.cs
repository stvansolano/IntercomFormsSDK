using System;
namespace Intercom.Forms
{
	public class CrossIntercom
	{
		static Lazy<IIntercom> implementation = new Lazy<IIntercom>(CreateIntercom, System.Threading.LazyThreadSafetyMode.PublicationOnly);

		private static IIntercom CreateIntercom() {
			return new IntercomImplementation();
			//return null;
		}

		public static IIntercom Current {
			get {
				var ret = implementation.Value;
				if (ret == null) {
					throw new NotImplementedException("Implementation does not exist in the current assembly");
				}
				return ret;
			}
		}

		public static void Dispose() {
			if (implementation?.IsValueCreated ?? false) {
				implementation.Value.Dispose();
				implementation = new Lazy<IIntercom>(CreateIntercom, System.Threading.LazyThreadSafetyMode.PublicationOnly);
			}
		}
	}
}
