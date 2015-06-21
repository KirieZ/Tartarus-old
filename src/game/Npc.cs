// Copyright (c) Tartarus Dev Team, licensed under GNU GPL.
// See the LICENSE file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
	class Npc : GameObject
	{
		public Npc(uint pHandle) : base(pHandle, GameObjectType.Player) {
			
		}
	}
}
