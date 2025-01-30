using UnityEngine;
using TMPro;

namespace BubbleClicker
{
    public class BubbleUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text bubbleText;

        private void OnEnable()
        {
            EconomyManager.OnBubblesChanged += UpdateBubbleText;
        }

        private void OnDisable()
        {
            EconomyManager.OnBubblesChanged -= UpdateBubbleText;            
        }

        private void UpdateBubbleText(int newBubbleCount)
        {
            bubbleText.text = $"{newBubbleCount}";
        }
    }
}