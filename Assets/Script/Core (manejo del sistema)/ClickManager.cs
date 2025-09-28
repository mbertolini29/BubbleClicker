using UnityEngine;

namespace BubbleClicker
{
    public class ClickManager : MonoBehaviour
    {
        [SerializeField] private ClickConfigSO clickConfig;
        [SerializeField] private EconomyManager economy;

        private void Awake()
        {
            //economyManager = FindFirstObjectByType<EconomyManager>();
        }

        private void OnMouseDown()
        {
            if(economy != null && clickConfig != null)
                economy.AddBubbles(clickConfig.bubblesPerClick);
        }
    }
}
