using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.LogReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hearthstone_Deck_Tracker.Utility.Broadcast
{
	public class GameStateController : ApiController
	{
		private int _playerLife = 30;

		public GameStateController()
		{
			GameEvents.OnEntityWillTakeDamage.Add(x =>
			{
				if (x.Entity.IsCurrentPlayer)
				{
					_playerLife -= x.Value;
				}
			});
		}

		[HttpGet]
		[Route("player/life")]
		public string GetPlayerLife()
		{
			return _playerLife.ToString();
		}

		[HttpGet]
		[Route("player/board")]
		public string GetPlayerBoard()
		{

		}
	}
}
