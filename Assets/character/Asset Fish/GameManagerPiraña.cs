using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerPirana : MonoBehaviour
{
    public TMP_Text PiranhaText;

    private int PiranhaCounts = 0;
    private bool recompensadada = false;

    private void Start()
    {
        // Inicializa el texto en pantalla al empezar
        if (PiranhaText != null)
        {
            PiranhaText.text = "Pirañas\n0/9";
        }
    }

    public void Addcollectible()
    {
        PiranhaCounts++;
        Debug.Log("Pirañas recogidas: " + PiranhaCounts);

        if (PiranhaText != null)
        {
            PiranhaText.text = "Pirañas\n" + PiranhaCounts + "/9";
        }

        if (PiranhaCounts >= 9 && !recompensadada)
        {
            Debug.Log("ENTRO AL IF DE RECOMPENSA");
            recompensadada = true;
            Invoke(nameof(CargarSiguienteNivel), 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Addcollectible();
            // Destruye ESTE objeto (la piraña coleccionable), no al Player
            Destroy(gameObject);
        }
    }

    void CargarSiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}