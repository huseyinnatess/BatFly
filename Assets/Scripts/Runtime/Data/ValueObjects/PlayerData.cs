﻿using System;
using UnityEngine;

namespace Runtime.Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
    }
    
    [Serializable]
    public struct PlayerMovementData
    {
        public float JumpForce;
        public float JumpHeight;
        public float JumpDuration;
    }
}