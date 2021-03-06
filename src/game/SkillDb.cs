// Copyright (c) Tartarus Dev Team, licensed under GNU GPL.
// See the LICENSE file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;
using MySql.Data.MySqlClient;

namespace game
{
	public static class SkillDb
	{
		public class SkillEntry
		{
			public Byte MaxLevel { get; set; }
			public Int32[] RequiredJp { get; set; }
			public UInt32 CooldownTime { get; set; }
		}

		public static Dictionary<Int32, SkillEntry> DB { get; private set; }

		public static void Start()
		{
			ConsoleUtils.Write(ConsoleMsgType.Status, "Loading Skill Database...\n");

			DB = new Dictionary<int, SkillEntry>();
			Database db = new Database(Server.GameDbConString);
			MySqlDataReader reader = 
				db.ReaderQuery(
					"SELECT `skill_id`, `name`, `max_level` " +
					"FROM `skill_db`", null, null
				);

			while (reader.Read())
			{
				SkillEntry skill = new SkillEntry();

				int skillId = (int)reader["skill_id"];

				skill.MaxLevel = (byte)reader["max_level"];
				skill.RequiredJp = new int[skill.MaxLevel+1];
				skill.CooldownTime = 1000;

				Database db2 = new Database(Server.GameDbConString);
				MySqlDataReader reader2 =
					db2.ReaderQuery(
						"SELECT `skill_id`, `level`, `jp` " +
						"FROM `skill_jp_db` " +
						"WHERE `skill_id`=@sid",
						new string[] { "sid" },
						new object[] { skillId }
					);

				while (reader2.Read())
				{
					byte lv = (byte)reader2["level"];
					int jp = (int)reader2["jp"];

					if (lv > skill.MaxLevel)
					{
						ConsoleUtils.Write(
							ConsoleMsgType.Warning,
							"Defined JP cost for skill {1} level {2}, that's higher than the max level ({3})\r\n",
							skillId, lv, skill.MaxLevel
						);

						continue;
					}

					skill.RequiredJp[lv] = jp;
				}

				DB.Add(skillId, skill);
			}

			ConsoleUtils.Write(ConsoleMsgType.Status, "Skill Database Loaded.\n");
		}
	}
}
