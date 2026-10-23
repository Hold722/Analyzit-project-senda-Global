using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory Settings")]
    public int SandwichCount = 0; // Number of sandwiches collected
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
      SandwichCount++;
      Debug.Log("Sándwiches Collecteds: " + SandwichCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
