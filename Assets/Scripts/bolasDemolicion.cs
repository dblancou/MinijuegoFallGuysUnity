using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolasDemolicion : MonoBehaviour
{
    public float amplitud = 45f; // Amplitud del balanceo en grados
    public float velocidad = 2f; // Velocidad de balanceo
    public float fuerzaEmpuje = 10f; // Fuerza de empuje al chocar con el personaje

    private Quaternion rotacionInicial;

    void Start()
    {
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        // Calcula la rotaci�n sinusoidal
        float angulo = amplitud * Mathf.Sin(Time.time * velocidad);

        // Aplica la rotaci�n al objeto alrededor del eje global Y
        transform.rotation = rotacionInicial * Quaternion.Euler(0f, angulo, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto ha chocado con el personaje
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcula la direcci�n del empuje
            Vector3 direccionEmpuje = collision.contacts[0].point - transform.position;
            direccionEmpuje = -direccionEmpuje.normalized; // Invierte la direcci�n

            // Agrega un componente lateral al empuje (usando el eje X, por ejemplo)
            direccionEmpuje += Vector3.right * 0.5f; // Ajusta la magnitud y direcci�n seg�n sea necesario

            // Aplica el empuje al personaje
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}
