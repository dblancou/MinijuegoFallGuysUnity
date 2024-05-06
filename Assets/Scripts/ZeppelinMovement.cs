using System.Collections;
using UnityEngine;

public class ZeppelinMovement : MonoBehaviour
{
    public float velocidad = 9f;  // Velocidad de movimiento del zeppelin

    void Start()
    {
        // Inicia el movimiento del zeppelin
        StartCoroutine(MoveZeppelin());
    }

    IEnumerator MoveZeppelin()
    {
        while (true)
        {
            // Mueve el zeppelin en la dirección adecuada 
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime);

            // Espera un fotograma antes de repetir el bucle
            yield return null;
        }
    }
}
