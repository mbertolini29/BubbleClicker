using UnityEngine;
using UnityEngine.UI;

public class BuyButtons : MonoBehaviour
{
    public Button buyButton;      // Cambié el nombre de la variable para evitar conflicto con la clase
    public AudioClip soundClip;
    private AudioSource audioSource; // Cambié a "audioSource" para consistencia

    void Start() // Corrigido el nombre del método a "Start"
    {
        // Obtener el componente AudioSource del mismo GameObject
        audioSource = GetComponent<AudioSource>();

        // Si no existe un AudioSource, añadir uno
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asignar el clip de audio
        audioSource.clip = soundClip;

        // Verificar si el botón está asignado y agregar un listener para el clic
        if (buyButton != null)
        {
            buyButton.onClick.AddListener(PlaySound);
        }
    }

    // Método que se ejecuta al hacer clic en el botón
    void PlaySound()
    {
        audioSource.Play();
    }
}
