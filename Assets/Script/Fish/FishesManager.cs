using UnityEngine;
using System.Collections.Generic;

public class FishesManager : MonoBehaviour
{
    public List<Fish> allFishT1;
    public List<Fish> allFishT2;
    public List<Fish> allFishT3;

    //

    //public int GetCost(int numPez)
    //{
    //    return fish[numPez].cost;
    //}

    public Fish GetFish(int index)
    {
        if(index >= 0 && index < allFishT1.Count)
        {
            return allFishT1[index];
        }
        Debug.LogError("indice fuera de rango.");
        return null;
    }

    public List<Fish> GetFishListByType(int peceraType)
    {
        switch (peceraType)
        {
            case 1:
                return allFishT1;
            case 2:
                return allFishT2;
            case 3:
                return allFishT3;
            default:
                Debug.LogError("Tipo de pecera inválido: " + peceraType);
                return null;
        }
    }

    public Fish GetFishByTypeAndIndex(int peceraType, int index)
    {
        List<Fish> fishList = GetFishListByType(peceraType);
        if (fishList != null && index >= 0 && index < fishList.Count)
        {
            return fishList[index];
        }

        Debug.LogError("Índice fuera de rango o tipo de pecera inválido: PeceraType = " + peceraType + ", Index = " + index);
        return null;
    }

}
