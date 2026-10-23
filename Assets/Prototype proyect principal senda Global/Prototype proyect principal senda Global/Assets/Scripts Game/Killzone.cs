using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reload the current scene when the player enters the kill zone
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            Debug.Log("Player entered the kill zone. Reloading scene...");
        }
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy when it enters the kill zone
            Destroy(other.gameObject);
            Debug.Log("Enemy entered the kill zone. Enemy destroyed.");
        }
    }

}