using UnityEngine;
using UnityEngine.Audio;

public class BubbleClicker : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] RespiratorManager respiratorManager;
    [SerializeField] BurbujaSpawner burbuja;

    //[Header("Costo")]
    //public int cost;
    int previousNum = -1; // Variable para almacenar el número anterior

    //[Header("Cantidad de burbujas")]
    //public int bubblesPerClick = 1;
    public AudioSource[] asdasf;

    private void Start()
    {
        //resourceManager = GetComponent<ResourceManager>();
        //respiratorManager = GetComponent<RespiratorManager>();
    }

    private void OnMouseDown()
    {
        resourceManager.AddBubbles(respiratorManager.bubblesPerClick);

        //llamar burbujas.
        burbuja.SpawnBurbuja();

        //
        respiratorManager.ClickSprite();

        int num;

        do
        {
            num = Random.Range(0, asdasf.Length); // Genera un número aleatorio
        } while (num == previousNum); // Repite si el número es igual al anterior

        asdasf[num].Play();

        //Debug.Log(num);
        previousNum = num;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            respiratorManager.NoClickSprite();
        }
    }


}
