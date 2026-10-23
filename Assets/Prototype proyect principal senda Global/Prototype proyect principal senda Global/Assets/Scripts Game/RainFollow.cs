using UnityEngine;

public class RainFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            Camera.main.transform.position.z
        );
    }

    // Update is called once per frame

}
