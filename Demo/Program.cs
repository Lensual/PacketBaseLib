﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacketBaseLib;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            LoginPacket loginPkt = new LoginPacket();
            loginPkt.AutoResize = true;
            (loginPkt as dynamic).Data = new byte[3] { 0xff, 0x11, 0x22 };
            Console.WriteLine("LoginPkt\n{0}",loginPkt);
            Console.WriteLine(BitConverter.ToString(loginPkt.Raw));
            Console.ReadKey();
        }
    }
    class LoginPacket : PacketBase
    {
        public LoginPacket():base(9)
        {
            base.AddField<UInt32>("PkgLen",(uint)base.Length);
            base.AddField<Byte>("Version", 0);
            base.AddField<Command>("Command", Command.Login);
            base.AddField<Byte[]>("Data", null);
        }



    }

    enum Command
    {
        Login = 0,
        Logout = 1,
        Message = 2,
    }
}
