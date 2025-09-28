using UnityEngine;
using UnityEngine.Events;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "BubbleClicker/GameEvent")]
    public class GameEventSO : ScriptableObject
    {
        // UI: total de burbujas cambia
        public UnityAction<double> OnBubblesGenerated;

        // UI: cantidad de peces cambió (actual / max)
        public UnityAction<int, int> OnFishCountUpdated;

        //raise = aumentar.
        public void RaiseBubblesChanged(double total) => OnBubblesGenerated?.Invoke(total);

        //raise = aumentar peces.
        public void RaiseFishCount(int current, int max) => OnFishCountUpdated?.Invoke(current, max);
    }
}
