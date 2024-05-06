using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoPalas : MonoBehaviour
{
    // Velocidad de rotación de las palas
    public float velocidadRotacion = 50f;

    void Start()
    {
        // Inicia la rutina para cambiar la dirección de rotación periódicamente
        StartCoroutine(CambiarDireccionRotacion());
    }

    void Update()
    {
        // Rotar las palas en el eje Y (puedes ajustar el eje según tu diseño)
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    // Rutina para cambiar la dirección de rotación periódicamente
    IEnumerator CambiarDireccionRotacion()
    {
        while (true)
        {
            // Espera un tiempo aleatorio entre 3 y 5 segundos antes de cambiar la dirección
            yield return new WaitForSeconds(Random.Range(3f, 5f));

            // Cambia la dirección de rotación invirtiendo la velocidad
            velocidadRotacion *= -1;
        }
    }
}
