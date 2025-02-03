using UnityEngine;

namespace BubbleClicker
{
    [CreateAssetMenu(fileName = "NewAquarium", menuName = "Aquarium/Create New Aquarium")]
    public class AquariumSO : ScriptableObject
    {
        // ancho y alto de la pecera? 
        // depende de cada pecera... 
        public Vector2 sizeX;
        public Vector2 sizeY;

        //  Guarda datos de la pecera (capacidad máxima, generación de burbujas, etc.).
        public int maxFishCount = 5;

        // produce burbujas?
        public float bubbleProduction = 1.04f; //4%

        //sonido de pecera llena.
        //sonido de compra??
    }
}
