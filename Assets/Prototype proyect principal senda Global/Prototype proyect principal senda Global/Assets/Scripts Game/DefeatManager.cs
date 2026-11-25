using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatManager : MonoBehaviour
{
    [Header("Nombres de Escenas")]
    public string nombreEscenaNivel = "Level1";
    public string nombreEscenaMenu = "Menu";

    public void ReintentarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaNivel);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}