using UnityEngine;

public class Helice : MonoBehaviour
{
    // Velocidad de rotación de la hélice
    public float velocidadRotacion = 10f;

    // Fuerza de empuje al chocar con el personaje
    public float fuerzaEmpuje = 10f;

    // Update is called once per frame
    void Update()
    {
        // Rotar la hélice alrededor del eje Y en sentido contrario a la plataforma
        transform.Rotate(-Vector3.up, velocidadRotacion * Time.deltaTime);
    }

    // Se llama cuando ocurre una colisión
    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto ha chocado con el personaje
        if (collision.gameObject.CompareTag("Player"))
        {
            // Calcula la dirección del empuje
            Vector3 direccionEmpuje = collision.contacts[0].point - transform.position;
            direccionEmpuje = -direccionEmpuje.normalized; // Invierte la dirección

            // Agrega un componente lateral al empuje 
            direccionEmpuje += Vector3.right * 0.5f; // Ajusta la magnitud y dirección según sea necesario

            // Aplica el empuje al personaje usando un impulso
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode.Impulse);
        }
    }
}

