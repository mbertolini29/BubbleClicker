using UnityEngine;
using System;

namespace BubbleClicker
{
    public class EconomyManager : MonoBehaviour
    {
        [SerializeField] private GameEventSO onBubbleGenerated;

        public double TotalBubbles { get; private set; }

        public void AddBubbles(double amount)
        {
            TotalBubbles += amount;
            onBubbleGenerated.RaiseBubblesChanged(TotalBubbles);
        }

        public bool SpendBubbles(double amount)
        {
            if(TotalBubbles >= amount)
            {
                TotalBubbles -= amount;
                onBubbleGenerated.RaiseBubblesChanged(TotalBubbles);
                return true;
            }
            return false;
        }
    }
}
