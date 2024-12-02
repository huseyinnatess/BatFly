using System;
using UnityEngine;

namespace Runtime.Data.ValueObjects
{
    [Serializable]
    public struct EnvironmentElementsData
    {
        public Transform[] FirstBackgroundElements;
        public Transform[] SecondBackgroundElements;
    }
}