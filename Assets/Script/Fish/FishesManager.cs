using UnityEngine;
using System.Collections.Generic;

public class FishesManager : MonoBehaviour
{
    public List<Fish> allFish;

    //public int GetCost(int numPez)
    //{
    //    return fish[numPez].cost;
    //}

    public Fish GetFish(int index)
    {
        if(index >= 0 && index < allFish.Count)
        {
            return allFish[index];
        }
        Debug.LogError("indice fuera de rango.");
        return null;
    }
}
