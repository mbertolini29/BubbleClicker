using UnityEngine;
using TMPro;

namespace BubbleClicker
{
    public class GameUI : MonoBehaviour
    {
        [Header("Referencias UI")]
        [SerializeField] private TMP_Text bubbleText;
        [SerializeField] private TMP_Text fishText;

        [Header("Eventos")] 
        [SerializeField] private GameEventSO gameEvent;

        private void OnEnable()
        {
            gameEvent.OnBubblesGenerated += UpdateBubbleText;
            gameEvent.OnFishCountUpdated += UpdateFishText;
        }

        private void OnDisable()
        {
            gameEvent.OnBubblesGenerated -= UpdateBubbleText;
            gameEvent.OnFishCountUpdated -= UpdateFishText;
        }

        private void UpdateBubbleText(int newBubbleCount)
        {
            bubbleText.text = $"{newBubbleCount}";
        }

        private void UpdateFishText(int fishCount, int maxFish)
        {
            fishText.text = $"{fishCount}/{maxFish}";
        }
    }
}
