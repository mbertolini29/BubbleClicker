using UnityEngine;
using System;

namespace BubbleClicker
{
    public class StoreManager : MonoBehaviour
    {
        [SerializeField] private FishStoreSO fishStoreSO;
        [SerializeField] private FishesManager fishesManager;
        [SerializeField] private EconomyManager economyManager;
        [SerializeField] private FishTankManager fishTankManager; // Para saber el nivel actual de la pecera

        private FishSO[] currentAvailableFishes = Array.Empty<FishSO>();

        private void OnEnable()
        {
            if (fishTankManager != null)
                fishTankManager.OnTankLevelChanged += RefreshForLevel;
        } 
        
        private void OnDisable()
        {
            if (fishTankManager != null)
                fishTankManager.OnTankLevelChanged -= RefreshForLevel;
        }

        private void Start()
        {
            RefreshForLevel(fishTankManager.CurrentLevel);
        }

        private void RefreshForLevel(int level)
        {
            currentAvailableFishes = fishStoreSO != null
                ? fishStoreSO.GetFishesForLevel(level)
                : Array.Empty<FishSO>();

            // TODO: acá refrescás sprites y costos de los 3 botones
            // shopButtons[i].Set(currentAvailableFishes[i].icon, currentAvailableFishes[i].cost);
        }

        public void BuyFish(int index)
        {
            if (index < 0 || index >= currentAvailableFishes.Length)
            {
                Debug.LogError("Índice de pez no valido.");
                return;
            }

            var fishToBuy = currentAvailableFishes[index];

            if(!economyManager.SpendBubbles(fishToBuy.cost))
            {
                Debug.Log("No tienes suficientes burbujas.");
                // TODO: sonido de error
                return;
            }

            //instanciar pez
            fishesManager.SpawnFish(fishToBuy, fishTankManager.CurrentAquarium);
            
            //TODO: reproducir sonido de compra
            //AudioSource.PlayClipAtPoint(fishToBuy.buySound, Camera.main.transform.position);
        }

        public void BuyTankUpgrade()
        {
            if (!fishTankManager.UpgradeTank(economyManager))
            {
                Debug.Log("No tienes suficientes burbujas o ya está al máximo.");
                return;
            }

            Debug.Log($"Tanque mejorado al nivel {fishTankManager.CurrentLevel}");

            // refrescar tienda con los nuevos peces disponible
            RefreshForLevel(fishTankManager.CurrentLevel);
        }
    }
}
