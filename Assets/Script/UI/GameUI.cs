using UnityEngine;
using TMPro;
using System.Globalization;

namespace BubbleClicker
{
    public static class NumberFormatter
    {
        public static string Format(double value, int decimals = 1)
        {
            return value.ToString($"F{decimals}", CultureInfo.InvariantCulture);
        }
    }


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
            bubbleText.text = NumberFormatter.Format(total);
            //bubbleText.text =
            //    NumberFormatter.Format(total) + " / sec";

            //bubbleText.text = FormatNumber(total);
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
