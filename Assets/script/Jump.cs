using UnityEngine;

public class Jump : MonoBehaviour
{
    public float powerJump = 5f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            rb.AddForce(Vector3.up * powerJump, ForceMode.Impulse);
        }
    }
}
