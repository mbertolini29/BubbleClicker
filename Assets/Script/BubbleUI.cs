using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubbleUI : MonoBehaviour
{
    //[SerializeField] private ResourceManager bubble;

    public TMP_Text bubbleText;

    private void Start()
    {
        bubbleText.text = "0";
    }

    private void Update()
    {         
        //actualizar cantidad de burbujas. 
        bubbleText.text = $"{ResourceManager.Instance.bubbles}";
    }
}
