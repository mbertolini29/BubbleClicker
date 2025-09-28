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

        [SerializeField] private List<Fish> fishesInAquarium = new();

        public AquariumSO Data => data;

        //para un futuro, la produccion de burbujas.
        private float bubbleProduction = 0f;

        //tamaño de pecera (Límites accesibles por los peces)
        public Vector2 GetBoundsWidth() => data.sizeX;
        public Vector2 GetBoundsHeight() => data.sizeY;

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

        private void GenerateBubbles()
        {
            Debug.Log($"La pecera generó {bubbleProduction} burbujas.");
        }
        
        //public int GetTotalBubbleProduction()
        //{
        //    return fishesInAquarium.Sum(FishSO => FishSO.BubblesPerSecond) * (int)data.bubbleMultiplier;
        //}

    }
}
