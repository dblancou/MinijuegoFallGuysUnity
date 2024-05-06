using UnityEngine;

public class Camara : MonoBehaviour
{
    // Referencia al objeto del jugador en la escena
    public GameObject jugador;

    // Referencia a la clase 'logicaPersonaje' para acceder a sus m�todos
    public logicaPersonaje personaje;

    // Vector que almacena la distancia entre la c�mara y el jugador
    Vector3 distancia;

    // Altura inicial de la c�mara con respecto al suelo
    float alturaInicial;

    // Factor de suavidad para el movimiento de la c�mara
    public float suavidad = 10f;

    void Start()
    {
        // Calcula la distancia inicial entre la c�mara y el jugador
        distancia = transform.position - jugador.transform.position;

        // Almacena la altura inicial de la c�mara
        alturaInicial = transform.position.y;
    }

    void LateUpdate()
    {
        // Vector que representa la posici�n objetivo de la c�mara
        Vector3 targetPosition;

        // Verifica si el jugador est� en el suelo
        if (personaje.suelo())
        {
            // Actualiza la posici�n objetivo de la c�mara manteniendo la altura del suelo
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                jugador.transform.position.y + distancia.y,
                jugador.transform.position.z + distancia.z
            );

            // Actualiza la altura inicial de la c�mara a la altura actual
            alturaInicial = transform.position.y;
        }
        else
        {
            // Si el jugador est� en el aire, mantiene la altura inicial de la c�mara
            targetPosition = new Vector3(
                jugador.transform.position.x + distancia.x,
                alturaInicial, // Mant�n la altura inicial de la c�mara
                jugador.transform.position.z + distancia.z
            );
        }

        // Aplica un movimiento suavizado a la posici�n de la c�mara
        transform.position = Vector3.Lerp(transform.position, targetPosition, suavidad * Time.deltaTime);
    }
}
