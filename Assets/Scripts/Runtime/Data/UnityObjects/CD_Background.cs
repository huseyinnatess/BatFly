using Runtime.Data.ValueObjects;
using UnityEngine;

namespace Runtime.Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Background", menuName = "FlappyBird/CD_Background", order = 1)]
    public class CD_Background : ScriptableObject
    {
        public LevelElementData Data;
    }
}