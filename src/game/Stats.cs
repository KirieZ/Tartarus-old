// Copyright (c) Tartarus Dev Team, licensed under GNU GPL.
// See the LICENSE file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
	public class Stats
	{
		public enum BaseType : byte
		{
			PAtk = 11,
			MAtk = 12,
			Acc = 13,
			AtkSpd = 14,
			PDef = 15,
			MDef = 16,
			Evasion = 17,
			MovSpd = 18,
			BlockPer = 19,
			MaxWeight = 20,
			BlockDef = 21,
			CastSpd = 22,
			MAcc = 23,
			MRes = 24,
			ReCastSpd = 25,
			MPRecov = 33,
			Range = 34
		}

		public short JobID;
		public short Strength;
		public short Vitality;
		public short Dexterity;
		public short Agility;
		public short Intelligence;
		public short Wisdom;
		public short Luck;
		public short CritRate;
		public short CritPower;
		public short PAtkRight;
		public short PAtkLeft;
		public short PDef;
		public short BlockDef;
		public short MAtk;
		public short MDef;
		public short AccuracyRight;
		public short AccuracyLeft;
		public short MAccuracy;
		public short Evasion;
		public short MRes;
		public short BlockPer;
		public short MovSpd;
		public short AtkSpd;
		//public short Unknown;
		public short MaxWeight;
		//public short Unknown;
		public short CastSpd;
		public short ReCastSpd;
		//public short Unknown;
		public short HPRegen;
		public short HPRecov;
		public short MPRegen;
		public short MPRecov;
		public short PerfBlock;
		public short MIgnore;
		public short MIgnorePer;
		public short PIgnore;
		public short PIgnorePer;
		public short MPierce;
		public short MPiercePer;
		public short PPierce;
		public short PPiercePer;

		/// <summary>
		/// Recalculate the stats (this must not be used by SC)
		/// </summary>
		/// <param name="level">entity level</param>
		public static bool PCCalculate(Player player)
		{
			// Formulas from: http://rappelz.wikia.com/wiki/Stats_%26_Ability
			Stats stats = player.BaseStats;
			Player.JobDBEntry jobData = Player.JobDB[player.Job];
			int level = player.Level;

			// Load Job stats
			stats.Strength = (short) (StatsDb.DB[player.Job].Str + jobData.StrMult * player.JobLevel);
			stats.Vitality = (short)(StatsDb.DB[player.Job].Vit + jobData.VitMult * player.JobLevel);
			stats.Dexterity = (short)(StatsDb.DB[player.Job].Dex + jobData.DexMult * player.JobLevel);
			stats.Agility = (short)(StatsDb.DB[player.Job].Agi + jobData.AgiMult * player.JobLevel);
			stats.Intelligence = (short)(StatsDb.DB[player.Job].Int + jobData.IntMult * player.JobLevel);
			stats.Wisdom = (short)(StatsDb.DB[player.Job].Wis + jobData.WisMult * player.JobLevel);
			stats.Luck = (short)(StatsDb.DB[player.Job].Luk + jobData.LuckMult * player.JobLevel);

			// Meelee
			stats.PAtkRight = (short)Math.Ceiling((decimal)(14 / 5f * stats.Strength + level + 9));
			// Ranged
			//stats.PAtkRight = (short)Math.Ceiling((decimal)(6 / 5f * stats.Agility + (11/5f)*stats.Dexterity + level));

			stats.AccuracyLeft = (short)Math.Ceiling((decimal)(1 / 2f) * stats.Dexterity + level);
			//TODO : Accuracy Right
			stats.MAtk = (short)(2 * stats.Intelligence + level);
			stats.PDef = (short)Math.Ceiling((decimal)(5 / 3f) * stats.Vitality + level);
			stats.Evasion = (short)Math.Ceiling((decimal)(stats.Vitality / 2f + level));
			stats.AtkSpd = (short)Math.Ceiling((decimal)(100 + stats.Agility / 10f));

			stats.MAccuracy = (short)Math.Ceiling((decimal)((4 / 10f) * stats.Wisdom + (1 / 10f) * stats.Dexterity + level));
			stats.MDef = (short) (2 * stats.Wisdom + level);
			stats.MRes = (short)Math.Ceiling((decimal)((1 / 2f) * stats.Wisdom + level));
			stats.MovSpd = 120;

			stats.HPRegen = 5;
			stats.MPRegen = 5;
			stats.BlockPer = 0;
			stats.CritRate = (short)Math.Ceiling(stats.Luck / 5f + 3);
			stats.CastSpd = 100;

			stats.HPRecov = (short)(2 * level + 48);
			stats.MPRecov = (short)(4.1f * stats.Wisdom + 2 * level + 48);
			stats.BlockDef = 0;
			stats.CritPower = 80;
			stats.ReCastSpd = 100;
			stats.MaxWeight = (short)(10 * stats.Strength + 10 * level);

			// Equipment Stats
			for (int i = 0; i < player.Equip.Length; i++)
			{
				if (player.Equip[i] != 0)
				{
					Item item = player.Inventory[player.Equip[i]];
					ItemDb.ItemEntry dbItem = ItemDb.DB[item.Code];

					for (int j = 0; j < Item.MaxBaseTypes; j++)
					{
						switch (dbItem.BaseTypes[j])
						{
							case BaseType.PAtk:
								if (player.IsEquipped(Item.WearType.LeftHand))
									stats.PAtkLeft += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								else
									stats.PAtkLeft = 0;

								if (player.IsEquipped(Item.WearType.RightHand))
									stats.PAtkRight += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								else
									stats.PAtkRight = 0;
								break;
							case BaseType.MAtk:
								stats.MAtk += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.Acc:
								stats.AccuracyLeft += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								stats.AccuracyRight += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.AtkSpd:
								stats.AtkSpd += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.PDef:
								stats.PDef += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.MDef:
								stats.MDef += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.Evasion:
								stats.Evasion += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.MovSpd:
								stats.MovSpd += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.BlockPer:
								stats.BlockPer += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.MaxWeight:
								stats.MaxWeight += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.BlockDef:
								stats.BlockDef += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.CastSpd:
								stats.CastSpd += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.MAcc:
								stats.MAccuracy += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.MRes:
								stats.MRes += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.ReCastSpd:
								stats.ReCastSpd += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.MPRecov:
								stats.MPRecov += (short)(dbItem.BaseVar1[j] + dbItem.BaseVar2[j] * (item.Level - 1));
								break;
							case BaseType.Range:
								// TODO : Range stats
								break;
							default:
								break;
						}
					}
				}
			}

			player.BaseStats = stats;
			
			// TODO : Check if any stat has changed
			// or not
			return true;
		}

		/// <summary>
		/// Recalculate SC stats
		/// </summary>
		public static bool PCCalculateSC(Player player)
		{
			// Formulas from: http://rappelz.wikia.com/wiki/Stats_%26_Ability
			Stats stats = player.SCStats;

			player.SCStats = stats;

			// TODO : Check if any stat has changed
			// or not
			return true;
		}
	}
}
