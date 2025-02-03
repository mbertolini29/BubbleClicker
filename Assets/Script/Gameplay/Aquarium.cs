using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BubbleClicker
{
    public class Aquarium : MonoBehaviour
    {
        [SerializeField] private GameEventSO gameEvent;  

        [SerializeField] private AquariumSO aquariumData;        

        [SerializeField] private List<Fish> fishesInAquarium = new List<Fish>();
        
        //para un futuro, la produccion de burbujas.
        private float bubbleProduction = 0f;

        //tamaño de pecera.
        public Vector2 GetBoundsWidth() => aquariumData.sizeX;
        public Vector2 GetBoundsHeight() => aquariumData.sizeY;

        //cant de peces.
        public int GetFishCount() => fishesInAquarium.Count;
        public int GetMaxFishCount() => aquariumData.maxFishCount;

        public bool CanAddFish() 
        {
            return fishesInAquarium.Count < aquariumData.maxFishCount;
        }

        public bool AddFish(Fish fish)
        {
            if(!CanAddFish())
            {
                //sonidito a pecera llena./error.
                Debug.Log("Pecera llena, no se pueden agregar más peces.");
                return false;
            }

            fishesInAquarium.Add(fish);
            gameEvent.RaiseCountFish(GetFishCount(), GetMaxFishCount());
            return true;
        }

        public void RemoveFish(Fish fish)
        {
            if (fishesInAquarium.Contains(fish))
            {
                fishesInAquarium.Remove(fish);
                gameEvent.RaiseCountFish(GetFishCount(), GetMaxFishCount());
            }
        }

        private void UpdateBubbleProduction()
        {
            //bubbleProduction *= aquariumData.bubbleProduction;
        }

        private void GenerateBubbles()
        {
            Debug.Log($"La pecera generó {bubbleProduction} burbujas.");
        }
        
        //public int GetTotalBubbleProduction()
        //{
        //    return fishesInAquarium.Sum(FishSO => FishSO.BubblesPerSecond) * (int)aquariumData.bubbleMultiplier;
        //}

    }
}
