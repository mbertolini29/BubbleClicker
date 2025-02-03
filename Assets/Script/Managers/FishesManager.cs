using UnityEngine;
using System.Collections.Generic;

namespace BubbleClicker
{
    public class FishesManager : MonoBehaviour
    {
        private Aquarium aquarium;

        private void Start()
        {
            aquarium = FindFirstObjectByType<Aquarium>();
        }

        public void SpawnFish(FishSO fishData)
        {
            if(aquarium.CanAddFish())
            {
                GameObject newFish = Instantiate(fishData.fishPrefab,
                                               fishData.fishPrefab.transform.position,
                                               Quaternion.identity);

                Fish fishComponent = newFish.GetComponent<Fish>();

                fishComponent.Initialize(fishData);

                aquarium.AddFish(fishComponent);
            }
        }
    }
}