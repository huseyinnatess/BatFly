using System;
using UnityEngine;

namespace Runtime.Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerSpriteData SpriteData;
    }

    [Serializable]
    public struct PlayerMovementData
    {
        public float JumpForce;
        public float JumpHeight;
        public float JumpDuration;
        public float RotationCount;
        public Vector2 DefaultPosition;
    }

    [Serializable]
    public struct PlayerSpriteData
    {
        public Sprite[] Sprites;
    }
}