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
            if (gameEvent != null)
            {
                gameEvent.OnBubblesGenerated += UpdateBubbleText;
                gameEvent.OnFishCountUpdated += UpdateFishText;
            }
        }

        private void OnDisable()
        {
            if (gameEvent != null)
            {
                gameEvent.OnBubblesGenerated -= UpdateBubbleText;
                gameEvent.OnFishCountUpdated -= UpdateFishText;
            }
        }

        private void UpdateBubbleText(double total)
        {
            bubbleText.text = FormatNumber(total);
        }

        private void UpdateFishText(int fishCount, int maxFish)
        {
            fishText.text = $"{fishCount}/{maxFish}";
        }

        private string FormatNumber(double n)
        {
            if (n >= 1_000_000_000) return (n / 1_000_000_000d).ToString("0.##") + "B";
            if (n >= 1_000_000) return (n / 1_000_000d).ToString("0.##") + "M";
            if (n >= 1_000) return (n / 1_000d).ToString("0.##") + "K";
            return n.ToString("0.##");
        }
    }
}
