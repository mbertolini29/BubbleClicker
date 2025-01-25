using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] FishesManager fishesManager;
    [SerializeField] RespiratorManager respiratorManager;

    public int fishCount = 0;

    private void Start()
    {
        
    }

    public void PezItem(int num)
    {
        Fish fish = fishesManager.GetFish(num);

        if (!resourceManager.SpendBubbles(fish.cost))
        {
            Debug.Log("no tienes suficiente dinero.");
            return;
        }

        Instantiate(fish.gameObject,
                    fish.gameObject.transform.position,
                    Quaternion.identity);

    }

    public void RespiradorItem()
    {
        int numRespirador = respiratorManager.numRespirator;
        int costo = respiratorManager.costoRespirator[numRespirador];

        if (!resourceManager.SpendBubbles(costo))
        {
            Debug.Log("no tienes suficiente dinero.");
            return;
        }

        respiratorManager.BuyRespirator();
       


    }

}
