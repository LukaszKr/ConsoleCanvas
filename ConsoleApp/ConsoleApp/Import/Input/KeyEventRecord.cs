﻿using System.Runtime.InteropServices;

namespace ProceduralLevel.ConsoleApp
{
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct KeyEventRecord
	{
		[FieldOffset(0), MarshalAs(UnmanagedType.Bool)]
		public bool KeyDown;
		[FieldOffset(4), MarshalAs(UnmanagedType.U2)]
		public ushort RepeatCount;
		[FieldOffset(6), MarshalAs(UnmanagedType.U2)]
		public ushort VirtualKeyCode;
		[FieldOffset(8), MarshalAs(UnmanagedType.U2)]
		public ushort VirtualScanCode;
		[FieldOffset(10)]
		public char UnicodeChar;
		[FieldOffset(12), MarshalAs(UnmanagedType.U4)]
		public uint ControlKeyState;
	}
}
