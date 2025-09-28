using UnityEngine;
using System;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "FishStore", menuName = "BubbleClicker/Fish Store")]
    public class FishStoreSO : ScriptableObject
    {
        [Serializable]
        public class LevelEntry
        {
            public string levelName;
            public FishSO[] fishes; // 3 por nivel
        }

        public LevelEntry[] levels;

        public FishSO[] GetFishesForLevel(int level)
        {
            if (level >= 0 && level < levels.Length && levels[level] != null && levels[level].fishes != null)
                return levels[level].fishes;

            return Array.Empty<FishSO>(); // Retorna vacío si el nivel no existe
        }
    }
}