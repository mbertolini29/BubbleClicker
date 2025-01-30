using UnityEngine;

namespace BubbleClicker
{
    public class ClickManager : MonoBehaviour
    {
        [SerializeField] private ClickConfigSO clickConfig;
        [SerializeField] private GameEventSO onBubbleGenerated;

        private void OnMouseDown()
        {
            onBubbleGenerated.Raise(clickConfig.bubblesPerClick);
        }
    }
}
