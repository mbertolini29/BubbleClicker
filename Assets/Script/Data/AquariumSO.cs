using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "AquariumSO", menuName = "BubbleClicker/Aquarium")]
    public class AquariumSO : ScriptableObject
    {
        // ancho y alto de la pecera? 
        // depende de cada pecera... 
        public Vector2 sizeX;
        public Vector2 sizeY;

        //  Guarda datos de la pecera (capacidad máxima, generación de burbujas, etc.).
        public int maxFishCount = 5;

        // produce burbujas?
        public double bubbleProduction = 1.04f; //4%

        // 
        public GameObject prefab; // Prefab visual de la pecera (opcional)

        //sonido de pecera llena.
        //sonido de compra??
    }
}
