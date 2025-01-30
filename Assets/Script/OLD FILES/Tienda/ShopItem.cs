using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ShopItem : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] FishesManager fishesManager;
    [SerializeField] RespiratorManager respiratorManager;
    [SerializeField] PeceraManager peceraManager;
    [SerializeField] BotonPeces botonPeces;

    public AudioSource audioSource; // Referencia al AudioSource
    public AudioClip soundA; // Sonido A

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

            audioSource.PlayOneShot(soundA); // Reproduce el sonido A
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

            //   
            peceraManager.numPecera++;

            ///nueva pecera... cambio la imagen
            ActualizarBotones(peceraManager.numPecera);
        }    
    }

    void ActualizarBotones(int numPecera)
    {
        // Obtener la lista de peces según el tipo de pecera
        List<Fish> pecesDisponibles = fishesManager.GetFishListByType(numPecera);

        if (pecesDisponibles == null || pecesDisponibles.Count < 3)
        {
            Debug.LogError("No hay suficientes peces para esta pecera.");
            return;
        }

        // Actualizar los botones de la tienda
        for (int i = 0; i < botonPeces.botonPecera.Length; i++) // Asegúrate de que tengas un array de botones
        {
            //Button boton = botonPeces.botonPecera[i];
            //Image imagenBoton = boton.GetComponent<Image>();
            //Text textoBoton = boton.GetComponentInChildren<Text>();            

            if (botonPeces.imagenBoton[i] != null && botonPeces.textoBoton[i] != null && i < pecesDisponibles.Count)
            {
                Fish pez = pecesDisponibles[i];
                botonPeces.imagenBoton[i].sprite = pez.gameObject.GetComponent<SpriteRenderer>().sprite; // Cambiar la imagen del botón
                botonPeces.textoBoton[i].text = $"{pez.cost} B"; // Cambiar el texto del botón
            }
        }
    }
}

