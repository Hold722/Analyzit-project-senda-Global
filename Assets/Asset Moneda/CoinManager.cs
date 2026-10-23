using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinManager : MonoBehaviour
{
    public TMP_Text monedasText;
    public GameObject rewardPanel;

    private int monedasRecogidas = 0;
    private bool recompensaDada = false;

    public int monedasObjetivo = 10; // Cambia este valor según necesites

    void Start()
    {
        monedasText.text = "Monedas\n0/" + monedasObjetivo;

        if (rewardPanel != null)
            rewardPanel.SetActive(false);
    }

    public void AddCoin()
    {
        monedasRecogidas++;

        monedasText.text = "Monedas\n" + monedasRecogidas + "/" + monedasObjetivo;

        Debug.Log("Monedas: " + monedasRecogidas);

        if (monedasRecogidas >= monedasObjetivo && !recompensaDada)
        {
            recompensaDada = true;

            if (rewardPanel != null)
                rewardPanel.SetActive(true);

            Debug.Log("Nivel completado");

            Invoke(nameof(CargarSiguienteNivel), 3f);
        }
    }

    void CargarSiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}