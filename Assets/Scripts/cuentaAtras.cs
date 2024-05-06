using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cuentaAtras : MonoBehaviour
{
    // Tiempo inicial en segundos
    public float timer = 120f;

    // Referencia al objeto de texto que mostrar� el temporizador
    public TextMeshProUGUI textoTimer;

    // Variables para almacenar minutos y segundos del temporizador
    private int minutos, segundos;

    // Objeto que se activar� al llegar a cero el temporizador
    public GameObject objetoDerrota;

    // M�todo que se llama en cada frame
    private void Update()
    {
        // Verifica si el temporizador es mayor que cero
        if (timer > 0)
        {
            // Reduce el temporizador con el tiempo transcurrido desde el �ltimo frame
            timer -= Time.deltaTime;

            // Calcula los minutos y segundos a partir del tiempo restante en el temporizador
            minutos = (int)(timer / 60f);
            segundos = (int)(timer - minutos * 60f);

            // Actualiza el texto mostrando el tiempo formateado en minutos y segundos
            textoTimer.text = "Tiempo: " + string.Format("{0:00}:{1:00}", minutos, segundos);
        }
        else
        {
            // Si el temporizador llega a cero, activa el objeto de derrota

            objetoDerrota.SetActive(true);

            // Pausa el tiempo del juego
            Time.timeScale = 0f;

            // Muestra el cursor y desbloquea su posici�n
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
