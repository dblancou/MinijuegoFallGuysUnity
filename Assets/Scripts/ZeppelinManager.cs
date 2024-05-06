using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinManager : MonoBehaviour
{
    public GameObject zeppelinPrefab;  // prefab del zeppelin en el Inspector
    public Transform spawnPoint;       // El punto donde se instancia el zeppelin
    public float recorridoDuration = 10f;  // Duración del recorrido en segundos

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

            // Espera la duración del recorrido
            yield return new WaitForSeconds(recorridoDuration);

            // Destruye el zeppelin después del recorrido
            Destroy(zeppelin);
        }
    }
}
