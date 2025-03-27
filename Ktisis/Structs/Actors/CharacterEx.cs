﻿using System;
using System.Numerics;
using System.Runtime.InteropServices;

using FFXIVClientStructs.FFXIV.Client.Game.Character;

namespace Ktisis.Structs.Actors;

[Flags]
public enum CombatFlags : byte {
	None = 0,
	WeaponDrawn = 0x40
}

public enum EmoteModeEnum : uint {
	Normal = 0,
	SitGround = 1,
	SitChair = 2,
	Sleeping = 3
}

[StructLayout(LayoutKind.Explicit, Size = 0x22E0)]
public struct CharacterEx {
	public const int AnimationOffset = 0x9A0;
	
	[FieldOffset(0)] public Character Character;

	[FieldOffset(0xE0)] public Vector3 DrawObjectOffset;

	[FieldOffset(0x120)] public Vector3 CameraOffsetSmooth;
	[FieldOffset(0x170)] public Vector3 CameraOffset;

	[FieldOffset(0x610)] public unsafe nint* _emoteControllerVf;
	[FieldOffset(0x610)] public EmoteController EmoteController;
	
	[FieldOffset(0x0CE2)] public CombatFlags CombatFlags;
	
	[FieldOffset(AnimationOffset)] public AnimationContainer Animation;

	[FieldOffset(0x2258)] public float Opacity;

	[FieldOffset(0x22CC)] public byte Mode;
	[FieldOffset(0x22CD)] public EmoteModeEnum EmoteMode;

	public bool IsGPose => this.Character.ObjectIndex is >= 201 and <= 243;
}
