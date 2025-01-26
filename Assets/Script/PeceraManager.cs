using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PeceraManager : MonoBehaviour
{
    public TMP_Text numPecesText;

    //
    public int fishCount = 0;
    public int minFishCount = 0;
    public int maxFishCount = 5;

    [Header("Prefeb")]
    //public Pecera[] peceraPrefab;
    public List<Pecera> AllPecera;
    public int numPecera = 0;
    public int maxPecera = 3;


    private void Start()
    {
        fishCount = Mathf.Clamp(fishCount, minFishCount, maxFishCount);
        numPecesText.text = $"{fishCount}/{maxFishCount}";
    }

    public void UpdateCantidadPeces(int numPecera)
    {
        numPecera = Mathf.Clamp(numPecera, minFishCount, maxFishCount);
        numPecesText.text = $"{numPecera}/{maxFishCount}";
    }

    //obtenes todas las peceras de la lista
    public Pecera GetPecera(int index)
    {
        if (index >= 0 && index < AllPecera.Count)
        {
            return AllPecera[index];
        }
        //Debug.LogError("indice fuera de rango.");
        return null;
    }

    //los peces se achican con el cambio de la pecera. 


    //los item de la tienda tmb. cambian-


    //
}
