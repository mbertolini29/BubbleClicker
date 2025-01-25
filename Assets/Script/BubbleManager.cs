using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public static BubbleManager Instance { get; private set; }

    public int bubblesPerClick = 1;
    public int totalBubles = 0;

    int level = 1;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void OnMouseDown()
    {
        ////incrementador
        //totalBubles += bubblesPerClick;
        //Debug.Log($"Nivel {level} - bubble: {totalBubles}");
                
        //CheckForLevelUp();
    }

    void CheckForLevelUp()
    {
        if(totalBubles >= 50 && level == 1)
        {
            LevelUp();
        }
        else if (totalBubles >= 150 && level == 2)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        bubblesPerClick = CalculateBubblesPerClick(level);
    }

    private int CalculateBubblesPerClick(int currentLevel)
    {        
        // Usa una fórmula para determinar
        // las burbujas por clic en cada nivel
        return (currentLevel * (currentLevel + 1) / 2);
    }
}
