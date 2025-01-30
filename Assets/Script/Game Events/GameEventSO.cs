using UnityEngine;
using UnityEngine.Events;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Bubble Clicler/GameEvent")]
    public class GameEventSO : ScriptableObject
    {
        public UnityAction<int> OnEventRaised;

        //raise = aumentar.
        public void Raise(int amount)
        {
            if (OnEventRaised != null)
                OnEventRaised.Invoke(amount);
        }
    }
}
