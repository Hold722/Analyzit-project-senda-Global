using UnityEngine;

public class FishCollectible : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Player"))
      {
            //Here you cant call the method to add the collectible to the GameManager
            Debug.Log("¡Pez recolectado!");
          Destroy(gameObject); // Destroy the object Collectible 
        }
      GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.AddCollectible(); //Call the method to add the collectible to the GameManager
            Debug.Log("Peces recolectados: ");

            //Destroy the fish collectible after collection
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("GameManager no Found in the Scene.");
        }

            // Update is called once per frame
            void Update()
            {

            }   }
}
