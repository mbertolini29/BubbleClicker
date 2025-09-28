using UnityEngine;
using UnityEngine.UI;

public class CreditPanel : MonoBehaviour
{

    public GameObject creditPanel;  // El panel de créditos que se activa/desactiva
    public Button closeButton;      // El botón de cerrar

    private bool isPaused = false;  // Para controlar el estado de pausa

    void Start()
    {
        // Asegúrate de que el panel está inicialmente desactivado
        creditPanel.SetActive(false);

        // Asignar la acción del botón de cerrar
        //closeButton.onClick.AddListener(CloseCredits);
    }

    // Método para abrir el panel de créditos y pausar el juego
    public void ShowCredits()
    {
        creditPanel.SetActive(true);  // Mostrar el panel de créditos
        Time.timeScale = 0f;          // Pausar el juego (detener el tiempo)
        isPaused = true;
    }

    // Método para cerrar el panel de créditos y reanudar el juego
    public void CloseCredits()
    {
        creditPanel.SetActive(false);  // Ocultar el panel de créditos
        Time.timeScale = 1f;           // Reanudar el juego
        isPaused = false;
    }
}
