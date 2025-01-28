using UnityEngine;

public class RespiratorManager : MonoBehaviour
{
    [Header("Cantidad de burbujas")]
    public int bubblesPerClick = 1;

    //
    public int numRespirator = 0;
    public int[] costoRespirator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] respiratorSprites;
    
    [SerializeField] private Sprite[] respiratorSpritesClick1;
    [SerializeField] private Sprite[] respiratorSpritesClick2;
    [SerializeField] private Sprite[] respiratorSpritesClick3;

    public void BuyRespirator()
    {
        if (numRespirator < respiratorSprites.Length - 1)
        {
            numRespirator++;
            UpdateRespiratorSprite();
            AumentarClick();
            Debug.Log("Respirador actualizado.");
        }
        else
        {
            Debug.Log("Ya tenes el ultimo respirador.");
        }
    }

    private void UpdateRespiratorSprite()
    {
        if (respiratorSprites.Length > 0 && numRespirator < respiratorSprites.Length)
        {
            spriteRenderer.sprite = respiratorSprites[numRespirator];
        }
    }

    public void AumentarClick()
    {
        // Usa una fórmula para determinar
        bubblesPerClick++;
        // las burbujas por clic en cada nivel
        bubblesPerClick = (bubblesPerClick * (bubblesPerClick + 5) / 2);
    }

    public void ClickSprite()
    {
        switch (numRespirator)
        {
            case 0:
                spriteRenderer.sprite = respiratorSpritesClick1[1];
                break;
            case 1:
                spriteRenderer.sprite = respiratorSpritesClick2[1];
                break;
            case 2:
                spriteRenderer.sprite = respiratorSpritesClick3[1];
                break;
        }
    }
    public void NoClickSprite()
    {
        switch (numRespirator)
        {
            case 0:
                spriteRenderer.sprite = respiratorSpritesClick1[0];
                break;
            case 1:
                spriteRenderer.sprite = respiratorSpritesClick2[0];
                break;
            case 2:
                spriteRenderer.sprite = respiratorSpritesClick3[0];
                break;
        }
    }

}
