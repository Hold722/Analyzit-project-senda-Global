using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text Sandwichtext;
    public TMP_Text CoinsText;


    private int SandwichCounts = 0;
    private int monedas = 0;

    public GameObject Redwarpanel;

    private bool recompensaDada = false;

    public void AddCollectible()
    {
        SandwichCounts++;

        Debug.Log("Sándwiches recogidos: " + SandwichCounts);

        Sandwichtext.text = "Sándwiches\n" + SandwichCounts + "/8";
        if (SandwichCounts >= 8 && !recompensaDada)
        {
            Debug.Log("ENTRO AL IF DE RECOMPENSA");

            monedas += 50;
            CoinsText.text = monedas.ToString();

            recompensaDada = true;

            Invoke("CargarSiguienteNivel", 3f);
        }
    }

    void Start()
    {
        Redwarpanel.SetActive(false);
        recompensaDada = false;
    }
    void CargarSiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
