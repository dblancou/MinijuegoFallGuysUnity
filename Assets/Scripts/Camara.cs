using UnityEngine;

public class Camara : MonoBehaviour
{
    // Referencia al objeto del jugador en la escena
    public GameObject jugador;

    // Referencia a la clase 'logicaPersonaje' para acceder a sus métodos
    public logicaPersonaje personaje;

    // Vector que almacena la distancia entre la cámara y el jugador
    Vector3 distancia;

    // Altura inicial de la cámara con respecto al suelo
    float alturaInicial;

    // Factor de suavidad para el movimiento de la cámara
    public float suavidad = 10f;

    void Start()
    {
        // Calcula la distancia inicial entre la cámara y el jugador
        distancia = transform.position - jugador.transform.position;

        // Almacena la altura inicial de la cámara
        alturaInicial = transform.position.y;
    }

    void LateUpdate()
    {
        // Vector que representa la posición objetivo de la cámara
        Vector3 targetPosition;

        // Verifica si el jugador está en el suelo
        if (personaje.suelo())
        {
            // Actualiza la posición objetivo de la cámara manteniendo la altura del suelo
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                jugador.transform.position.y + distancia.y,
                jugador.transform.position.z + distancia.z
            );

            // Actualiza la altura inicial de la cámara a la altura actual
            alturaInicial = transform.position.y;
        }
        else
        {
            // Si el jugador está en el aire, mantiene la altura inicial de la cámara
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                alturaInicial, // Mantén la altura inicial de la cámara
                jugador.transform.position.z + distancia.z
            );
        }

        // Aplica un movimiento suavizado a la posición de la cámara
        transform.position = Vector3.Lerp(transform.position, targetPosition, suavidad * Time.deltaTime);
    }
}
