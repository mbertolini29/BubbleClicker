using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "New Producer", menuName = "Bubble Clicler/Producer")]
    public class ProducerSO : ScriptableObject
    {
        public string producerName;

        public Sprite icon;

        public float baseProduction;
        public float cost;
        public float costMultiplier = 1.05f;
    }
}
