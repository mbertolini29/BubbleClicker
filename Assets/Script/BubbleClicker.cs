using UnityEngine;

public class BubbleClicker : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] RespiratorManager respiratorManager;

    //[Header("Costo")]
    //public int cost;

    //[Header("Cantidad de burbujas")]
    //public int bubblesPerClick = 1;

    private void OnMouseDown()
    {
        resourceManager.AddBubbles(respiratorManager.bubblesPerClick);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            respiratorManager.ClickSprite();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            respiratorManager.NoClickSprite();
        }
    }


}
