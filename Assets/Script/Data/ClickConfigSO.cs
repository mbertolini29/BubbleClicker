using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "ClickConfig", menuName = "BubbleClicker/ClickConfig")]
    public class ClickConfigSO : ScriptableObject
    {
        public double bubblesPerClick = 1.0;
    }
}