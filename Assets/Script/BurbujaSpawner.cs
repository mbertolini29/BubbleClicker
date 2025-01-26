using UnityEngine;
using System.Collections;

public class BurbujaSpawner : MonoBehaviour
{
    public GameObject[] burbujasPrefab;
    public float spawRate = 1f;
    public float numPosMin = -1f;
    public float numPosMax = -7f;
    public float posPeceraY = -3f;

    public float destroyTime = 3f; 

    float timeLastSpawn = 0f;
    int currentPrefabIndex = 0;

    private void Update()
    {
        //timeLastSpawn += Time.deltaTime;

        //// Si ha pasado el tiempo para crear una nueva burbuja
        //if (timeLastSpawn >= spawRate)
        //{
        //    // Llamar a la función para generar la burbuja
        //    SpawnBurbuja();
        //    timeLastSpawn = 0f;
        //}
    }

    public void SpawnBurbuja()
    {
        // Generar una posición aleatoria dentro del ancho de la pecera
        float randomX = Random.Range(numPosMin, numPosMax);
        float randomY = posPeceraY; // Colocamos las burbujas al fondo de la pecera

        // Instanciar la burbuja en la posición aleatoria y usar el prefab correspondiente
        GameObject burbuja = Instantiate(burbujasPrefab[currentPrefabIndex], 
                                         new Vector3(randomX, randomY, 0), 
                                         Quaternion.identity);

        // Cambiar el índice para la próxima burbuja
        currentPrefabIndex++;

        // Si llegamos al final de la lista, reiniciamos el índice para comenzar desde el principio
        if (currentPrefabIndex >= burbujasPrefab.Length)
        {
            currentPrefabIndex = 0;
        }

        // Iniciar la animación o movimiento de la burbuja (como en el ejemplo anterior)
        StartCoroutine(MoverBurbuja(burbuja));

        // Destruir la burbuja después de un tiempo (destroyTime)
        StartCoroutine(DestroyBurbujaAfterTime(burbuja, destroyTime));
    }

    IEnumerator MoverBurbuja(GameObject burbuja)
    {
        if (burbuja == null) yield break;

        Vector3 startPos = burbuja.transform.position;
        Vector3 endPos = new Vector3(startPos.x, 2f, startPos.z);  
        // Moverla hacia la parte superior de la pecera

        float time = 0f;
        float duration = Random.Range(2f, 5f); // Tiempo aleatorio para la animación

        while (time < duration)
        {
            //
            if (burbuja == null) yield break;

            burbuja.transform.position = Vector3.Lerp(startPos, endPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        if (burbuja == null)
        {
            burbuja.transform.position = endPos;  // Asegurarse de que la burbuja termine en la posición final
        }
    }

    IEnumerator DestroyBurbujaAfterTime(GameObject burbuja, float time)
    {
        yield return new WaitForSeconds(time);

        // Destruir la burbuja si sigue existiendo
        if (burbuja != null)
        {
            Destroy(burbuja);
        }
    }
}
