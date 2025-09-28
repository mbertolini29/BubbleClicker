using UnityEngine;
using System;

public class BubbleGenerator : MonoBehaviour
{
    public static event Action<int> OnBubblesGenerated;

    [SerializeField] private int bubblesPerClick = 1;

    public void GenerateBubble()
    {
        Debug.Log("BubbleGenerator: genera burbujas");
        OnBubblesGenerated?.Invoke(bubblesPerClick);
    }
}
