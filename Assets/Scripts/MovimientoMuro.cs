using UnityEngine;

public class MovimientoMuro : MonoBehaviour
{
    // Velocidad de movimiento del muro
    public float velocidad = 3f;

    // Distancia total que recorrer� el muro
    public float distancia = 5f;

    // Variable que indica la direcci�n actual del movimiento del muro
    private bool haciaDerecha = true;

    // Posici�n inicial del muro
    private Vector3 posicionInicial;

    void Start()
    {
        // Guarda la posici�n inicial del muro al inicio
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en la direcci�n adecuada
        float desplazamiento = haciaDerecha ? velocidad : -velocidad;

        // Mueve el muro en la direcci�n calculada, ajustado por el tiempo
        transform.Translate(new Vector3(desplazamiento, 0, 0) * Time.deltaTime);

        // Verifica si el muro ha alcanzado el l�mite y cambia la direcci�n si es necesario
        if (Mathf.Abs(transform.position.x - posicionInicial.x) >= distancia / 2)
        {
            haciaDerecha = !haciaDerecha;
        }
    }
}
