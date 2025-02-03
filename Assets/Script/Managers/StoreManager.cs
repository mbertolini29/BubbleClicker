using UnityEngine;

namespace BubbleClicker
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private FishSO[] availableFishes;
        [SerializeField] private FishesManager fishesManager;
        [SerializeField] private EconomyManager economyManager;

        public void BuyFish(int index)
        {
            if (index < 0 || index >= availableFishes.Length)
            {
                Debug.LogError("Índice de pez valido.");
                return;
            }

            FishSO fishToBuy = availableFishes[index];

            if(!economyManager.SpendBubbles(fishToBuy.cost))
            {
                Debug.Log("No tienes suficientes burbujas.");
                return;
            }

            //instanciar pez
            fishesManager.SpawnFish(fishToBuy);

            //reproducir sonido de compra
            //AudioSource.PlayClipAtPoint(fishToBuy.buySound, Camera.main.transform.position);
        }
    }
}
