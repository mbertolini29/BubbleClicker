using UnityEngine;
using System;
using System.Collections.Generic;

namespace BubbleClicker
{
    public class FishTankManager : MonoBehaviour
    {
        // Datos de las peceras/tanques
        [SerializeField] private TankUpgradeSO tankUpgradeData;     
        [SerializeField] private Aquarium currentAquarium;
        [SerializeField] private Transform aquariumParent; // en donde instanciamos las peceras..
                
        //[SerializeField] private SpriteRenderer tankRenderer; //sprite de la pecera.

        public int CurrentLevel { get; private set; } = 0;
        public Aquarium CurrentAquarium => currentAquarium;        

        // Para actualizar
        public event Action<int> OnTankLevelChanged;
        //public int MaxFishCount => tankUpgradeData.GetUpgrade(CurrentLevel).maxFishCount;

        public bool UpgradeTank(EconomyManager economy)
        {
            if (!tankUpgradeData.HasNextLevel(CurrentLevel)) 
                return false;

            var next = tankUpgradeData.GetUpgrade(CurrentLevel + 1);
            
            if (!economy.SpendBubbles(next.cost)) 
                return false;

            // 1. Guardar peces actuales
            List<Fish> fishes = new List<Fish>(currentAquarium.GetAllFish());

            // 2. Instanciar nueva pecera
            var newAquariumGO = Instantiate(next.aquarium.prefab, next.aquarium.prefab.transform.position, Quaternion.identity, aquariumParent);
            var newAquarium = newAquariumGO.GetComponent<Aquarium>();

            // 3. Migrar peces
            foreach (var fish in fishes)
            {
                // reubicar como hijo del nuevo prefab
                fish.transform.SetParent(newAquarium.transform);
                // registrarlos en la nueva pecera
                newAquarium.AddFish(fish);

                // re inicializar los peces en su nueva pecera
                fish.Init(newAquarium);
            }

            // 4. Destruir la vieja
            Destroy(currentAquarium.gameObject);

            // 5. Actualizar referencia
            currentAquarium = newAquarium;
            CurrentLevel++;

            // avisar el cambio
            //OnTankLevelChanged?.Invoke(CurrentLevel);

            Debug.Log($"Pecera actualizada al nivel {CurrentLevel}");
            return true;
        }

        public int GetNextUpgradeCost()
        {
            if (!tankUpgradeData.HasNextLevel(CurrentLevel)) return -1;

            return tankUpgradeData.GetUpgrade(CurrentLevel + 1).cost;
        }



        //public void SetLevel(int level)
        //{
        //    level = Mathf.Max(0, level);
        //    if (level == currentLevel) return;
        //    currentLevel = level;
        //    OnTankLevelChanged?.Invoke(currentLevel);
        //}

        //public void SetCurrentAquarium(Aquarium aquarium)
        //{
        //    currentAquarium = aquarium;

        //    // Podrías recalcular límites si la nueva pecera cambia bounds dinámicamente
        //    // o esos limites no lo tiene la pecera? 
        //}


        // Método para intentar subir de nivel
        //public void LevelUp()
        //{
        //    if (currentLevel < maxLevel)
        //    {
        //        currentLevel++;
        //        Debug.Log($"FishTankManager: Nueva pecera nivel {currentLevel}");

        //        // Avisar a los suscriptores
        //        OnLevelUp?.Invoke(currentLevel);
        //    }
        //    else
        //    {
        //        Debug.Log("FishTankManager: Ya está en el nivel máximo");
        //    }
        //}
    }
}
