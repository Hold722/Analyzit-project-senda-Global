using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatManager : MonoBehaviour
{
    [Header("Botones")]
    public Button botonReintentar;
    public Button botonMenu;

    [Header("Nombres de Escenas")]
    public string nombreEscenaNivel = "Level1";
    public string nombreEscenaMenu = "Menu";

    private bool cargandoEscena = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (botonReintentar != null)
        {
            botonReintentar.onClick.RemoveAllListeners();
            botonReintentar.onClick.AddListener(ReiniciarNivel);
        }

        if (botonMenu != null)
        {
            botonMenu.onClick.RemoveAllListeners();
            botonMenu.onClick.AddListener(IrAlMenu);
        }
    }

    public void ReiniciarNivel()
    {
        if (cargandoEscena) return;
        cargandoEscena = true;

        Time.timeScale = 1f;
        DesactivarBotones();

        if (!string.IsNullOrEmpty(nombreEscenaNivel))
        {
            SceneManager.LoadScene(nombreEscenaNivel);
        }
    }

    public void IrAlMenu()
    {
        if (cargandoEscena) return;
        cargandoEscena = true;

        Time.timeScale = 1f;
        DesactivarBotones();

        if (!string.IsNullOrEmpty(nombreEscenaMenu))
        {
            SceneManager.LoadScene(nombreEscenaMenu);
        }
    }

    void DesactivarBotones()
    {
        if (botonReintentar != null) botonReintentar.interactable = false;
        if (botonMenu != null) botonMenu.interactable = false;
    }
}