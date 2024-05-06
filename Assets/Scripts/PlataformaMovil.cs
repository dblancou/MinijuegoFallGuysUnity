using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float velocidadMovimiento = 2.0f; // Velocidad de movimiento de la plataforma
    public float distanciaMovimiento = 1.0f; // Distancia total de movimiento en el eje Y
    public float amplitudMovimiento = 0.5f; // Amplitud máxima del movimiento en el eje Y

    private Vector3 posicionInicial; // Posición inicial de la plataforma

    void Start()
    {
        // Almacena la posición inicial
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Calcula el desplazamiento en el eje Y con una amplitud limitada
        float desplazamientoY = Mathf.Sin(Time.time * velocidadMovimiento) * amplitudMovimiento;

        // Aplica el desplazamiento a la posición de la plataforma con respecto a la distancia total
        transform.position = new Vector3(transform.position.x, posicionInicial.y + desplazamientoY * distanciaMovimiento, transform.position.z);
    }
}
