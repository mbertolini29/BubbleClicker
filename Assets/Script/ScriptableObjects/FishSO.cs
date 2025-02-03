using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "NewFish", menuName = "Fish/Create New Fish")]
    public class FishSO : ScriptableObject
    {
        [Header("Info")]
        public string fishName;
        public GameObject fishPrefab;
        public int cost;
        public float bubblesPerSecond;

        [Header("Movement")]
        public float speed = 1.0f;

        [Header("Audio")]
        public AudioClip buySound; //no se si va aca el sonido de compra...
    }
}