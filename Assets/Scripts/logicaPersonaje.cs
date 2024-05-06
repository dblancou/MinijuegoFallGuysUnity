using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaPersonaje : MonoBehaviour
{
    // Velocidad de movimiento del personaje
    public float velocidadMovimiento = 5.0f;

    // Velocidad de rotaci�n del personaje
    public float velocidadRotacion = 200.0f;

    private Animator anim;
    public float x, y;

    // Rigidbody del personaje para controlar la f�sica del movimiento
    public Rigidbody rb;

    // Fuerza aplicada al saltar
    public float fuerzaDeSalto = 8f;

    // Variable que indica si el personaje puede saltar
    public bool puedoSaltar;

    // Posici�n inicial del personaje
    public Vector3 posicionInicial;

    // N�mero de vidas del personaje
    public int vidas = 3;

    // Variable que evita perder m�ltiples vidas al mismo tiempo en ciertos eventos
    private bool yaPerdioVida = false;

    // Componente AudioSource para el sonido de salto
    public AudioSource audioSource;

    // Clip de sonido para el salto
    public AudioClip sonidoSalto;

    // GameObjects para la interfaz de usuario
    public GameObject victoria;
    public GameObject derrota;
    public GameObject vida2;
    public GameObject vida1;
    public GameObject vida0;

    void Start()
    {
        // Inicializaci�n de variables y obtenci�n de componentes
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Obtener la entrada del teclado para el movimiento
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Calcular el movimiento en base a la entrada del teclado
        Vector3 movimiento = new Vector3(x, 0.0f, y) * velocidadMovimiento * Time.deltaTime;

        // Aplicar el movimiento al personaje
        transform.Translate(movimiento);

        // Actualizar las animaciones del personaje
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        // Manejar el salto si el personaje puede saltar
        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Activar animaci�n de salto
                anim.SetBool("salto", true);

                // Aplicar fuerza hacia arriba para simular el salto
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);

                // Reproducir el sonido de salto
                GetComponent<AudioSource>().Play();
            }
            anim.SetBool("contactoSuelo", true);
        }
        else
        {
            // L�gica cuando el personaje est� en el aire
            EstoyCayendo();
        }
    }

    // M�todo que se llama cuando el personaje est� en el aire
    public void EstoyCayendo()
    {
        anim.SetBool("contactoSuelo", false);
        anim.SetBool("salto", false);

        // Reiniciar la variable yaPerdioVida cuando el personaje vuelve a tocar el suelo
        yaPerdioVida = false;
    }

    // M�todo llamado cuando el personaje colisiona con un objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verificar las etiquetas de los objetos con los que colisiona el personaje

        if (other.gameObject.CompareTag("checkpoint"))
        {
            // Actualizar la posici�n inicial al alcanzar un checkpoint
            posicionInicial = transform.position;
        }
        if (other.gameObject.CompareTag("checkpoint 2"))
        {
            posicionInicial = transform.position;
        }
        if (other.gameObject.CompareTag("checkpoint 3"))
        {
            posicionInicial = transform.position;
        }

        if (other.gameObject.CompareTag("vacio"))
        {
            // Restaurar posici�n inicial y reducir una vida al caer al vac�o
            rb.MovePosition(posicionInicial);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            if (!yaPerdioVida)
            {
                PerderVida();
                yaPerdioVida = true;
            }
        }

        if (other.gameObject.CompareTag("trampaBarras"))
        {
            // Reiniciar posici�n al tocar una trampa y reducir una vida
            transform.position = posicionInicial;

            if (!yaPerdioVida)
            {
                PerderVida();
                yaPerdioVida = true;
            }
        }

        if (other.gameObject.CompareTag("meta"))
        {
            // Mostrar el objeto de victoria al alcanzar la meta
            victoria.SetActive(true);
        }
    }

    // M�todo para manejar la p�rdida de vidas
    void PerderVida()
    {
        // Decrementar el contador de vidas y actualizar la interfaz
        vidas--;

        if (vidas == 2)
        {
            vida2.SetActive(false);
        }
        if (vidas == 1)
        {
            vida1.SetActive(false);
        }
        if (vidas == 0)
        {
            vida0.SetActive(false);
        }

        // Verificar si el personaje ha perdido todas las vidas
        if (vidas <= 0)
        {
            // L�gica de derrota (en este caso, mostrar un mensaje y reiniciar el nivel)
            Debug.Log("Has perdido todas las vidas. Fin del juego.");
            derrota.SetActive(true);
        }
        else
        {
            // Si a�n quedan vidas, reiniciar desde el �ltimo punto de guardado
            rb.MovePosition(posicionInicial);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Te quedan " + vidas + " vidas.");
        }
    }

    // M�todo para verificar si el personaje est� en el suelo
    public bool suelo()
    {
        // Raycast hacia abajo para detectar el suelo
        bool suelo = Physics.Raycast(transform.position, Vector3.down, 0.1f);

        // Devolver true si est� en el suelo, false si est� en el aire
        if (suelo)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
