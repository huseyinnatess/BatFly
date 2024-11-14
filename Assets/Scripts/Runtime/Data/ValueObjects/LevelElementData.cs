using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Data.ValueObjects
{
    [Serializable]
    public struct LevelElementData
    {
        public PipeDatas PipeDatas;
        public BackgroundData[] BackgroundDatas;
    }

    [Serializable]
    public struct BackgroundData
    {
        public Transform ParentBackground;
        public Transform Background;
        public float SpawnCount;
        public float ScrollSpeed;
    }

    [Serializable]
    public struct PipeDatas
    {
        public PipeObjects[] PipeObjects;
        public PipeValues PipeValues;
    }

    [Serializable]
    public struct PipeValues
    {
        public float MinHeight;
        public float MaxHeight;
        public float PipeGapHeight;
    }

    [Serializable]
    public struct PipeObjects
    {
        public GameObject[] PipeUp;
        public GameObject[] PipeDown;
    }
}