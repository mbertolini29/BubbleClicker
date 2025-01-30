using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BotonPeces : MonoBehaviour
{
    public Button[] botonPecera;  // El botón de la tienda
    public Image[] imagenBoton;  // La imagen que quieres cambiar en el botón
    public TMP_Text[] textoBoton;  // El texto que quieres cambiar en el botón

    public Sprite nuevaImagen;  // La nueva imagen para el botón
    public string nuevoTexto;  // El nuevo texto para el botón

    void Start()
    {
        // Asegúrate de que el botón esté asignado
        //if (botonPecera != null)
        //{
        //    botonPecera.onClick.AddListener(CambiarPecera);  // Cambiar pecera al hacer clic
        //}
    }

    public void CambiarPecera()
    {
        //// Cambiar la imagen del botón
        //if (imagenBoton != null)
        //{
        //    imagenBoton.sprite = nuevaImagen;
        //}

        //// Cambiar el texto del botón
        //if (textoBoton != null)
        //{
        //    textoBoton.text = nuevoTexto;
        //}

        // También puedes cambiar otros parámetros si lo necesitas
    }

    //
    //textoBoton = TIENE QUE SE IGUAL AL COSTO.




}
