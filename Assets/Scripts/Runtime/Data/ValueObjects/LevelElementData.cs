using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Data.ValueObjects
{
    [Serializable]
    public struct LevelElementData
    {
        public PipeSettings PipeDatas;
        public BackgroundSettings backgroundSettingses;
    }

    [Serializable]
    public struct BackgroundSettings
    {
        public float SpawnCount;
        public float ScrollSpeed;
    }

    [Serializable]
    public struct PipeSettings
    {
        public float MinHeight;
        public float MaxHeight;
        public float PipeGapHeight;
    }
}