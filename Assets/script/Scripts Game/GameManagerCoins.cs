using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCoins : MonoBehaviour
{
    public TMP_Text CoinsText;

    private int monedas = 0;
    private int monedasTotales = 8;

    public GameObject Redwarpanel;

    private bool recompensaDada = false;

    // Ahora este método acepta la cantidad que le mande la moneda (por defecto 1)
    public void AddCollectible(int cantidad = 1)
    {
        monedas += cantidad;

        Debug.Log("Monedas recogidas: " + monedas);

        // Actualiza el texto en pantalla reflejando cuántas llevas y cuántas faltan
        if (CoinsText != null)
        {
            CoinsText.text = "Monedas\n" + monedas + "/" + monedasTotales;
        }

        // Si ya juntaste las 8 monedas y no se ha dado la recompensa
        if (monedas >= monedasTotales && !recompensaDada)
        {
            Debug.Log("ENTRO AL IF DE RECOMPENSA - ¡Ganaste!");

            recompensaDada = true;

            // Activa el panel de victoria o recompensa si está asignado
            if (Redwarpanel != null)
            {
                Redwarpanel.SetActive(true);
            }

            Invoke("CargarSiguienteNivel", 3f);
        }
    }

    void Start()
    {
        if (Redwarpanel != null) Redwarpanel.SetActive(false);
        recompensaDada = false;

        // Inicializar texto al comenzar la escena para que se vea "0/8" desde el inicio
        if (CoinsText != null)
        {
            CoinsText.text = "Monedas\n" + monedas + "/" + monedasTotales;
        }
    }

    void CargarSiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
