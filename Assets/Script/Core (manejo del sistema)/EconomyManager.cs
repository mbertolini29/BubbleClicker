using UnityEngine;
using System;

namespace BubbleClicker
{
    public class EconomyManager : MonoBehaviour
    {
        [SerializeField] private GameEventSO onBubbleGenerated;

        public int TotalBubbles { get; private set; }

        public void AddBubbles(int amount)
        {
            TotalBubbles += amount;
            onBubbleGenerated.Raise(TotalBubbles);
        }

        public bool SpendBubbles(int amount)
        {
            if(TotalBubbles >= amount)
            {
                TotalBubbles -= amount;
                onBubbleGenerated.Raise(TotalBubbles);
                return true;
            }
            return false;
        }
    }
}
