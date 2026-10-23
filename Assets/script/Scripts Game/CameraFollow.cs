using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 3, -6);
    public float smootspeed = 2.5f;

    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void LateUpdate()
    {
      if(target==null) return;

      Vector3 desiredposition=target.position+ offset;
        transform.position = desiredposition;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
