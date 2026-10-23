using UnityEngine;

public class GameManagerPiraña : MonoBehaviour
{
    public TMPro.TMP_Text PiranhaText;

    private int PiranhaCounts = 0;

    private bool recompensadada = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
  public void Addcollectible()
    {
        PiranhaCounts++;
        Debug.Log("Piranhas recogidas: " + PiranhaCounts);
        PiranhaText.text = "Piranhas\n" + PiranhaCounts + "/9";
        if (PiranhaCounts >= 9 && !recompensadada)
        {
            Debug.Log("ENTRO AL IF DE RECOMPENSA");
            recompensadada = true;
            Invoke("CargarSiguienteNivel", 3f);
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
     if (other.CompareTag("Player"))
        {
            Addcollectible();
        }
     Destroy(other.gameObject);
    }

    // Update is called once per frame
    void CargarSiguienteNivel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
