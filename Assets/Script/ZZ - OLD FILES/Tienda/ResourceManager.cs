using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    //recursos
    public int bubbles = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddBubbles(int amount)
    {
        bubbles += amount;
        Debug.Log(("Bubbles: " + bubbles));
    }

    public bool SpendBubbles(int cost)
    {
        if (bubbles >= cost)
        {
            bubbles -= cost;
            Debug.Log($"Purchased! remaning bublles! { bubbles }");
            return true;
        }

        Debug.Log("Not enough bubbles!");
        return false;
    }


}
