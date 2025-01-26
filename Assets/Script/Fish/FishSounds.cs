using UnityEngine;
using System.Collections;
public class FishSounds: MonoBehaviour
{
    public AudioSource audioSource; // Referencia al AudioSource
    public AudioClip soundA; // Sonido A
    public float minTime = 1f; // Tiempo mínimo aleatorio
    public float maxTime = 5f; // Tiempo máximo aleatorio
    public int conditionVariable = 0; // Variable que determinará qué sonido reproducir
    //public ShopItem shop;
    public PeceraManager peceraManager;
    public int cantpeces;

    private void Start()
    {
        //shop = GetComponent<ShopItem>();
        
        StartCoroutine(PlaySoundAtRandomTime());
    }

    // Corutina que elige un tiempo aleatorio y reproduce un sonido
    private IEnumerator PlaySoundAtRandomTime()
    {
        while (true)
        {
            cantpeces = peceraManager.fishCount;
            // Elegir un tiempo aleatorio entre minTime y maxTime
            float randomTime = Random.Range(minTime, maxTime);

            // Esperar el tiempo aleatorio
            yield return new WaitForSeconds(randomTime);

            // Verificar la variable para decidir qué sonido reproducir
            if (cantpeces >0)
            {
                audioSource.PlayOneShot(soundA); // Reproduce el sonido A
            }
        }
    }
}
