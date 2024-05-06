using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinManager : MonoBehaviour
{
    public GameObject zeppelinPrefab;  // prefab del zeppelin en el Inspector
    public Transform spawnPoint;       // El punto donde se instancia el zeppelin
    public float recorridoDuration = 10f;  // Duraci�n del recorrido en segundos

    void Start()
    {
        StartCoroutine(SpawnZeppelins());
    }

    IEnumerator SpawnZeppelins()
    {
        while (true)  
        {
            // Instancia un nuevo zeppelin en el punto de spawn
            GameObject zeppelin = Instantiate(zeppelinPrefab, spawnPoint.position, Quaternion.identity);
            zeppelin.transform.Rotate(0, 90, 90);  // Ajusto los valores para que no se instancie torcido

            // Espera la duraci�n del recorrido
            yield return new WaitForSeconds(recorridoDuration);

            // Destruye el zeppelin despu�s del recorrido
            Destroy(zeppelin);
        }
    }
}
