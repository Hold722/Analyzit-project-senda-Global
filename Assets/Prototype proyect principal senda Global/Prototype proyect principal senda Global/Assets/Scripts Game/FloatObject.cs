using UnityEngine;

public class FloatObject : MonoBehaviour
{
    [SerializeField] public float speed = 2f;      // How fast the canoe moves up and down
    [SerializeField] public float height = 0.2f;   // How high the canoe floats

    private Vector3 startPosition;

    void Start()
    {
        // Saves the exact position where you placed the canoe in the editor
        startPosition = transform.position;
    }

    void Update()
    {
        // Simple math to make the canoe go up and down smoothly
        float newY = startPosition.y + Mathf.Sin(Time.time * speed) * height;

        // Updates the position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}