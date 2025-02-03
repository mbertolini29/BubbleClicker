using UnityEngine;

namespace BubbleClicker
{
    public class ClickManager : MonoBehaviour
    {
        [SerializeField] private ClickConfigSO clickConfig;
        [SerializeField] private EconomyManager economyManager;

        private void Awake()
        {
            //economyManager = FindFirstObjectByType<EconomyManager>();
        }

        private void OnMouseDown()
        {
            economyManager.AddBubbles(clickConfig.bubblesPerClick);
        }
    }
}
