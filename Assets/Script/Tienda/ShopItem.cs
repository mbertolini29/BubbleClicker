using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] FishesManager fishesManager;
    [SerializeField] RespiratorManager respiratorManager;
    [SerializeField] PeceraManager peceraManager;

    public GameObject maps;

    private void Start()
    {
        
    }

    public void PezItem(int num)
    {
        Fish fish = fishesManager.GetFish(num);

        if(peceraManager.fishCount >= peceraManager.maxFishCount)
        {
            Debug.Log("maximo peces");
            return;
        }

        if (!resourceManager.SpendBubbles(fish.cost))
        {
            Debug.Log("no tienes suficiente dinero.");
            return;
        }

        if (peceraManager.fishCount <= peceraManager.maxFishCount)
        {
            // Instancia el pez en una posición aleatoria dentro de la pecera
            float xPos = Random.Range(fish.leftBound, fish.rightBound);
            Vector3 spawnPosition = new Vector3(xPos, fish.gameObject.transform.position.y, 0);

            Instantiate(fish.gameObject,
                    spawnPosition,
                    Quaternion.identity);
        }

        //conocer cantidad de peces de manager pecera
        peceraManager.fishCount++;
        peceraManager.UpdateCantidadPeces(peceraManager.fishCount);
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

    public void PeceraItem()
    {
        //comprar nueva pecera... instanciarla, borrar la anterior. 
        //hacerla hijo del maps

        if(peceraManager.numPecera < peceraManager.maxPecera)
        {
            int numPecera = peceraManager.numPecera;
            Pecera pecera = peceraManager.GetPecera(numPecera);

            if (!resourceManager.SpendBubbles(pecera.cost))
            {
                Debug.Log("no tienes suficiente dinero.");
                return;
            }

            //borrar la anterior pecera. 
            GameObject peceraExistente = GameObject.FindWithTag("Aquarium");
            if (peceraExistente != null)
            {
                Destroy(peceraExistente);
            }

            // 
            GameObject newPecera = Instantiate(pecera.gameObject,
                                               pecera.gameObject.transform.position,
                                               Quaternion.identity);



            Transform parentTransform = maps.transform;
            newPecera.transform.SetParent(parentTransform);

            peceraManager.numPecera++;
        }    
    }
}

