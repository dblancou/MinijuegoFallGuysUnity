using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoTambores : MonoBehaviour
{
    // Velocidad de rotación de los tambores
    public float velocidadRotacion = 50f;

    // Fuerza de empuje al chocar con el personaje
    public float fuerzaEmpuje = 10f;

    void Start()
    {
        // Inicia la rutina para cambiar la dirección de rotación periódicamente
        StartCoroutine(CambiarDireccionRotacion());
    }

    void Update()
    {
        // Rotar los tambores en el eje Y (ajustar según el diseño)
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    // Rutina para cambiar la dirección de rotación periódicamente
    IEnumerator CambiarDireccionRotacion()
    {
        while (true)
        {
            // Espera minimo tres segundos antes de cambiar la dirección
            yield return new WaitForSeconds(4f);

            // Cambia la dirección de rotación invirtiendo la velocidad
            velocidadRotacion *= -1;
        }
    }

    // Método llamado cuando ocurre una colisión
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto ha chocado con el personaje
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcula la dirección del empuje desde el punto de contacto hasta el centro del tambor
            Vector3 direccionEmpuje = collision.contacts[0].point - transform.position;
            direccionEmpuje = -direccionEmpuje.normalized; // Invierte la dirección

            // Agrega un componente lateral al empuje (usando el eje X, por ejemplo)
            direccionEmpuje += Vector3.right * 0.5f; // Ajusta la magnitud y dirección según sea necesario

            // Aplica el empuje al personaje usando un impulso
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}
