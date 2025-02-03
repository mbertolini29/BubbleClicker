using UnityEngine;
using UnityEngine.Events;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Bubble Clicler/GameEvent")]
    public class GameEventSO : ScriptableObject
    {
        public UnityAction<int> OnBubblesGenerated;
        public UnityAction<int, int> OnFishCountUpdated;

        //raise = aumentar.
        public void Raise(int amount)
        {
            OnBubblesGenerated?.Invoke(amount);
        }

        //raise = aumentar peces.
        public void RaiseCountFish(int currentFish, int maxFish)
        {
            OnFishCountUpdated?.Invoke(currentFish, maxFish);
        }
    }
}
