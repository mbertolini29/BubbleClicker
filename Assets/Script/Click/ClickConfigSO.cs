using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "ClickConfig", menuName = "Bubble Clicler/ClickConfig")]
    public class ClickConfigSO : ScriptableObject
    {
        public int bubblesPerClick = 1;
    }
}
