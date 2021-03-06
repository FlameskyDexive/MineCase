﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MineCase.Serialization;

namespace MineCase.Protocol.Play
{
#if !NET46
    [Orleans.Concurrency.Immutable]
#endif
    [Packet(0x2F)]
    public sealed class OpenWindow : ISerializablePacket
    {
        [SerializeAs(DataType.Byte)]
        public byte WindowId;

        [SerializeAs(DataType.String)]
        public string WindowType;

        [SerializeAs(DataType.Chat)]
        public Chat WindowTitle;

        [SerializeAs(DataType.Byte)]
        public byte NumberOfSlots;

        [SerializeAs(DataType.Byte)]
        public byte? EntityId;

        public void Serialize(BinaryWriter bw)
        {
            bw.WriteAsByte(WindowId);
            bw.WriteAsString(WindowType);
            bw.WriteAsChat(WindowTitle);
            bw.WriteAsByte(NumberOfSlots);
            if (EntityId.HasValue)
                bw.WriteAsByte(EntityId.Value);
        }
    }
}
