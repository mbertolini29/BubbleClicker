using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "FishSO", menuName = "BubbleClicker/Fish")]
    public class FishSO : ScriptableObject
    {
        [Header("Info")]
        public string fishName;
        public GameObject fishPrefab;
        public double cost; 
        public double bubblesPerSecond; //cuanto tarda en generar una burbuja

        [Header("Movement")]
        public float speed = 1.0f;

        [Header("Sprite")]
        public Sprite icon;

        [Header("Audio")]
        public AudioClip buySound; //no se si va aca el sonido de compra...
    }
}