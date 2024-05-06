using UnityEngine;

public class PlataformaCircular : MonoBehaviour
{
    // Velocidad de rotación de la plataforma
    public float velocidadRotacion = 5f;

    // Variable para almacenar la rotación original del personaje
    public Quaternion rotacionPersonaje;

    // Update se llama una vez por fotograma
    void Update()
    {
        // Rotar la plataforma alrededor del eje Y
        transform.Rotate(Vector3.forward, velocidadRotacion * Time.deltaTime);
    }

    // Método llamado cuando ocurre una colisión
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisionó es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Almacenar la rotación actual del personaje
            rotacionPersonaje = collision.transform.rotation;

            // Hacer que el personaje sea hijo de la plataforma (disco)
            collision.transform.parent = transform;
        }
    }

    // Método llamado cuando el jugador deja de colisionar con la plataforma
    private void OnCollisionExit(Collision collision)
    {
        // Verificar si el objeto que dejó de colisionar es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Dejar de hacer que el personaje sea hijo de la plataforma
            collision.transform.parent = null;

            // Restablecer la rotación original del personaje
            collision.transform.rotation = rotacionPersonaje;
        }
    }
}
