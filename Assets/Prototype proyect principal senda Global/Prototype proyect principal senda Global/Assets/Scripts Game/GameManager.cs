using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text Bocadillos;
    public TMP_Text CoinsText;

    private int SandwichCounts = 0;
    private int monedas = 0;

    public GameObject Redwarpanel;

    private bool recompensaDada = false;

    void Start()
    {
        if (Redwarpanel != null)
            Redwarpanel.SetActive(false);

        recompensaDada = false;
        ActualizarUI(); // Para que muestre 0/8 desde el inicio
    }

    public void AddCollectible()
    {
        SandwichCounts++;

        Debug.Log("Bocadillos recogidos: " + SandwichCounts);

        ActualizarUI();

        if (SandwichCounts >= 8 && !recompensaDada)
        {
            Debug.Log("ENTRO AL IF DE RECOMPENSA");

            monedas += 50;
            if (CoinsText != null)
                CoinsText.text = monedas.ToString();

            recompensaDada = true;

            Invoke("CargarSiguienteNivel", 3f);
        }
    }

    void ActualizarUI()
    {
        if (Bocadillos != null)
        {
            // Espacios limpios y formato ordenado
            Bocadillos.text = SandwichCounts + " / 8";
        }
    }

    void CargarSiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}