// Copyright (c) Tartarus Dev Team, licensed under GNU GPL.
// See the LICENSE file
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using common;

namespace game
{
	public class Packets
	{
		public delegate void PacketAction(Player player, ref PacketStream stream, short[] pos);
		public delegate void ServerPacketAction(AuthServer server, ref PacketStream stream, short[] pos);

		public struct Packet
		{
			public PacketAction func;
			public short[] pos;
		}

		public struct SPacket
		{
			public ServerPacketAction func;
			public short[] pos;
		}

		public static Dictionary<short, Packet> LoadClientPackets()
		{
			Dictionary<short, Packet> packets_db = new Dictionary<short, Packet>();
			// [0x0001] 0001 -> Join Game
			packets_db.Add(0x0001, new Packet() { func = ClientPacketHandler.parse_JoinGame, pos = new short[] { 0 } });
			// [0x0002] 0002 -> Unknown
			//packets_db.Add(0x0001, new Packet() { func = ClientPacketHandler.parse_JoinGame, pos = new short[] { 0 });

			// [0x0005] 0005 -> PC Move Request
			packets_db.Add(0x0005, new Packet() { func = ClientPacketHandler.parse_PCMoveRequest, pos = new short[] { 0, 4, 8, 12, 19, 23 }});
			// [0x0007] 0007 -> PC Move Update
			packets_db.Add(0x0007, new Packet() { func = ClientPacketHandler.parse_PCMoveUpdate, pos = new short[] { 0, 4, 8, 12, 16 }});

			// [0x07D1] 2001 -> Character List Request
			packets_db.Add(0x07D1, new Packet() { func = ClientPacketHandler.parse_CharListRequest, pos = new short[] { 0 }});
			// [0x07D2] 2002 -> Create Character
			packets_db.Add(0x07D2, new Packet() { func = ClientPacketHandler.parse_CreateCharacter, pos = new short[] { 0, 4, 8, 12, 16, 20, 24, 28, 40, 52, 169, 188 } });
			// [0x07D3] 2003 -> Delete Character
			packets_db.Add(0x07D3, new Packet() { func = ClientPacketHandler.parse_DeleteCharacter, pos = new short[] { 0 } });
			// [0x07D5] 2005 -> User Join Game Server
			packets_db.Add(0x07D5, new Packet() { func = ClientPacketHandler.parse_UserJoinServer, pos = new short[] { 0, 61 } });
			// [0x07D6] 2006 -> Character Name Check
			packets_db.Add(0x07D6, new Packet() { func = ClientPacketHandler.parse_CharNameCheck, pos = new short[] { 0 } });

			return packets_db;
		}

		public static Dictionary<short, SPacket> LoadServerPackets()
		{
			Dictionary<short, SPacket> packets_db = new Dictionary<short, SPacket>();

			// [0x4E22] 20002 -> Response to Game Server Connect
			packets_db.Add(0x4E22, new SPacket() { func = ServerPacketHandler.parse_ListServerResult, pos = new short[] { 0 } });
			// [0x4E2B] 20011 -> User Join
			packets_db.Add(0x4E2B, new SPacket() { func = ServerPacketHandler.parse_UserJoinNotice, pos = new short[] { 0, 60, 64, 65 } });

			return packets_db;
		}
	}
}
