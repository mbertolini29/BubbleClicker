using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleClicker
{
    public class Aquarium : MonoBehaviour
    {
        [SerializeField] private AquariumSO data;        
        [SerializeField] private GameEventSO gameEvent;
        [SerializeField] private EconomyManager economy;

        [SerializeField] private List<Fish> fishesInAquarium = new();

        public AquariumSO Data => data;

        //Produccion de burbujas..
        //private float bubbleProduction = 0f;
        private float passiveTimer;

        //tamaño de pecera (Límites accesibles por los peces)
        public Vector2 GetBoundsWidth() => data.sizeX;
        public Vector2 GetBoundsHeight() => data.sizeY;

        public void Init(EconomyManager economyManager)
        {
            economy = economyManager;
        }

        private void Update()
        {
            passiveTimer += Time.deltaTime;

            if (passiveTimer >= 1f)
            {
                GeneratePassiveBubbles();
                passiveTimer = 0f;
            }
        }

        //cant de peces.
        public int FishCount => fishesInAquarium.Count;
        public int MaxFish => data.maxFishCount;

        public bool CanAddFish() => FishCount < MaxFish;

        public bool AddFish(Fish fish)
        {
            if(!CanAddFish())
            {
                //sonidito a pecera llena./error.
                Debug.Log("Pecera llena, no se pueden agregar más peces.");
                return false;
            }

            fishesInAquarium.Add(fish);
            gameEvent?.RaiseFishCount(FishCount, MaxFish);
            return true;
        }

        public void RemoveFish(Fish fish)
        {
            if (fishesInAquarium.Remove(fish))
            {
                gameEvent?.RaiseFishCount(FishCount, MaxFish);
            }
        }

        public IEnumerable<Fish> GetAllFish() => fishesInAquarium;


        private void UpdateBubbleProduction()
        {
            //bubbleProduction *= data.bubbleProduction;
        }

        private void GeneratePassiveBubbles()
        {
            if (economy == null || data == null) return;

            economy.AddBubbles(data.bubbleProduction);
        }
    }
}
