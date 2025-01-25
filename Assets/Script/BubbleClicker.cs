using UnityEngine;
using UnityEngine.Audio;

public class BubbleClicker : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    [SerializeField] RespiratorManager respiratorManager;

    //[Header("Costo")]
    //public int cost;

    //[Header("Cantidad de burbujas")]
    //public int bubblesPerClick = 1;
    public AudioSource[] asdasf; 


    private void OnMouseDown()
    {
        resourceManager.AddBubbles(respiratorManager.bubblesPerClick);


        respiratorManager.ClickSprite();

        int num = Random.Range(0, asdasf.Length);
        asdasf[num].Play();

        //if (Input.GetMouseButtonDown(0))
        //{
        //}
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            respiratorManager.NoClickSprite();
        }
    }


}
