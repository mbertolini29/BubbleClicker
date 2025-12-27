using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "TankUpgradeData", menuName = "BubbleClicker/Tank Upgrade Data")]
    public class TankUpgradeSO : ScriptableObject
    {
        [System.Serializable]
        public class TankUpgrade
        {
            public int cost;            // Costo de mejorar a este nivel
            public AquariumSO aquarium; // Pecera asociada a este nivel.
            public AudioClip upgradeSound;
        }

        public TankUpgrade[] upgrades;

        public TankUpgrade GetUpgrade(int level)
        {
            if (level < 0 || level >= upgrades.Length) return null;

            return upgrades[level];
        }

        public bool HasNextLevel(int currentLevel) => currentLevel + 1 < upgrades.Length;        
    }
}
