using UnityEngine;
using System;
using System.Collections.Generic;

namespace BubbleClicker
{
    public class FishesManager : MonoBehaviour
    {
        [SerializeField] private EconomyManager economy;
        [SerializeField] private FishTankManager fishTankManager;

        private readonly List<Fish> activeFishes = new();

        private Aquarium aquarium;

        private void Start()
        {
            aquarium = FindFirstObjectByType<Aquarium>();
        }

        private void Update()
        {
            // Producción pasiva total
            double bps = 0;
            foreach (var f in activeFishes)
            {
                if (f != null && f.Data != null)
                    bps += f.Data.bubblesPerSecond;
            }

            if (bps > 0 && economy != null)
                economy.AddBubbles(bps * Time.deltaTime);
        }


        public void SpawnFish(FishSO fishSO, Aquarium aquarium)
        {
            //var aquarium = fishTankManager.CurrentAquarium;

            if(aquarium == null || fishSO == null || fishSO.fishPrefab == null)
            {
                Debug.LogWarning("SparmFish: faltan referencias");
                return;
            }

            if(!aquarium.CanAddFish())
            {
                Debug.Log("Pecera llena.");
                return;
            }

            var go = Instantiate(fishSO.fishPrefab,
                                 fishSO.fishPrefab.transform.position,
                                 Quaternion.identity,
                                 aquarium.transform);
            //go.transform.localPosition = Vector3.zero;

            var fish = go.GetComponent<Fish>();
            if (fish == null)
                fish = go.AddComponent<Fish>();

            // Inyectar SO y límites
            var soField = typeof(Fish).GetField("data", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            soField?.SetValue(fish, fishSO);

            fish.Init(aquarium);

            if (aquarium.AddFish(fish))
                activeFishes.Add(fish);
            else
                Destroy(go);

            //    if (aquarium.CanAddFish())
            //    {
            //        GameObject newFish = Instantiate(fishSO.fishPrefab,
            //                                         fishSO.fishPrefab.transform.position,
            //                                         Quaternion.identity);

            //        Fish fishComponent = newFish.GetComponent<Fish>();

            //        fishComponent.Init(fishSO);

            //        aquarium.AddFish(fishComponent);
            //    }
        }
    }
}