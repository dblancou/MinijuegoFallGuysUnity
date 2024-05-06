using UnityEngine;

public class PlataformaCircular : MonoBehaviour
{
    // Velocidad de rotaci�n de la plataforma
    public float velocidadRotacion = 5f;

    // Variable para almacenar la rotaci�n original del personaje
    public Quaternion rotacionPersonaje;

    // Update se llama una vez por fotograma
    void Update()
    {
        // Rotar la plataforma alrededor del eje Y
        transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime);
    }

    // M�todo llamado cuando ocurre una colisi�n
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colision� es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Almacenar la rotaci�n actual del personaje
            rotacionPersonaje = collision.transform.rotation;

            // Hacer que el personaje sea hijo de la plataforma (disco)
            collision.transform.parent = transform;
        }
    }

    // M�todo llamado cuando el jugador deja de colisionar con la plataforma
    private void OnCollisionExit(Collision collision)
    {
        // Verificar si el objeto que dej� de colisionar es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Dejar de hacer que el personaje sea hijo de la plataforma
            collision.transform.parent = null;

            // Restablecer la rotaci�n original del personaje
            collision.transform.rotation = rotacionPersonaje;
        }
    }
}
