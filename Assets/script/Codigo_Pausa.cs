using UnityEngine;
using UnityEngine.SceneManagement; // <-- IMPORTANTE: Necesario para cambiar de escena

public class Codigo_Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                Pausar();
            }
            else
            {
                Resumir();
            }
        }
    }

    void Pausar()
    {
        ObjetoMenuPausa.SetActive(true);
        Pausa = true;

        Time.timeScale = 0; // Congela el tiempo del juego
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Libera el cursor para los botones
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        Pausa = false;

        Time.timeScale = 1; // Restaura el tiempo normal
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; // Vuelve a bloquear el cursor en el centro para jugar
    }

    // NUEVA FUNCIÓN: Conéctala al botón "Menú Principal" de tu UI
    public void IrAlMenuPrincipal(string nombreEscenaMenu)
    {
        Time.timeScale = 1; // ¡Obligatorio! Descongela el tiempo antes de cambiar de escena
       SceneManager.LoadScene(nombreEscenaMenu);
    }
}
