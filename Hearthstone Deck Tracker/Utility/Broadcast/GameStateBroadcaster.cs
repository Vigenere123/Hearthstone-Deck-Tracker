using Microsoft.Owin.Hosting;
using Owin;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hearthstone_Deck_Tracker.Utility.Broadcast
{
	public class GameStateBroadcaster
	{
		public static void Run()
		{
			WebApp.Start($"http://*:12345/", app =>
			{
				var config = new HttpConfiguration();
				config.EnableSwagger(swag =>
				{
					swag.SingleApiVersion("v1", "Hearthstone Game State");
					swag.RootUrl(request => new Uri(request.RequestUri, request.GetRequestContext().VirtualPathRoot).ToString());
					swag.UseFullTypeNameInSchemaIds();
				}).EnableSwaggerUi(swag => swag.DisableValidator());

				config.MapHttpAttributeRoutes();

				app.UseWebApi(config);
			});
		}
	}
}
