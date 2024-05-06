using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;

    void Update()
    {
        // Verifica si la tecla Esc es presionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Muestra u oculta el Canvas seg�n su estado actual
            if (menuPausa != null)
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        if (Time.timeScale == 0f)
        {
            // Si el juego ya est� pausado, reanuda el tiempo
            Time.timeScale = 1f;
            menuPausa.SetActive(false);
        }
        else
        {
            // Si el juego no est� pausado, pausa el tiempo y muestra el men� de pausa
            Time.timeScale = 0f;
            menuPausa.SetActive(true);
        }
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        Application.Quit();
        Debug.Log("Programa Cerrado");
    }

}
