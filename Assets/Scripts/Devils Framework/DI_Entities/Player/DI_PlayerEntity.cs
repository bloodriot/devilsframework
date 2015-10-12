// Devils Inc Studios
// Copyright DEVILS INC. STUDIOS LIMITED 2015
//
// TODO: Include a description of the file here.
//

using DI.Entities.Core;
using DI.Entities.Properties;

namespace DI.Entities.Player
{
	public class DI_PlayerEntity : DI_Entity
	{
		private int playerId;

		public void setPlayerId(int id)
		{
			playerId = id;
		}

		public int getPlayerId()
		{
			return playerId;
		}
	}
}