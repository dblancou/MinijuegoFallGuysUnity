using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPalas : MonoBehaviour
{
    // Velocidad de rotaci�n de las palas
    public float velocidadRotacion = 50f;

    void Start()
    {
        // Inicia la rutina para cambiar la direcci�n de rotaci�n peri�dicamente
        StartCoroutine(CambiarDireccionRotacion());
    }

    void Update()
    {
        // Rotar las palas en el eje Y (puedes ajustar el eje seg�n tu dise�o)
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    // Rutina para cambiar la direcci�n de rotaci�n peri�dicamente
    IEnumerator CambiarDireccionRotacion()
    {
        while (true)
        {
            // Espera un tiempo aleatorio entre 3 y 5 segundos antes de cambiar la direcci�n
            yield return new WaitForSeconds(Random.Range(3f, 5f));

            // Cambia la direcci�n de rotaci�n invirtiendo la velocidad
            velocidadRotacion *= -1;
        }
    }
}
