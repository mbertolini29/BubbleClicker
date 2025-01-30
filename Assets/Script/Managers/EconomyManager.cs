using UnityEngine;
using System;

namespace BubbleClicker
{
    public class EconomyManager : MonoBehaviour
    {
        public static EconomyManager Instance;

        public static event Action<int> OnBubblesChanged;

        public int TotalBubbles { get; private set; }

        [SerializeField] private GameEventSO onBubbleGenerated;

        private void OnEnable()
        {
            onBubbleGenerated.OnEventRaised += AddBubbles;            
        }

        private void OnDisable()
        {
            onBubbleGenerated.OnEventRaised -= AddBubbles;
        }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void AddBubbles(int amount)
        {
            TotalBubbles += amount;
            OnBubblesChanged?.Invoke(TotalBubbles);
            //UIManager.Instance.UpdateBubbleCount(bubbles);
        }

        public bool SpendBubbles(int amount)
        {
            if(TotalBubbles >= amount)
            {
                TotalBubbles -= amount;
                //UIManager.Instance.UpdateBubbleCount(bubbles);
                return true;
            }
            return false;
        }

    }
}
