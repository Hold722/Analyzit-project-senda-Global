using UnityEngine;

public class Camerafollow : MonoBehaviour
{
     [SerializeField]
     private Transform target; // The target the camera will follow
     [SerializeField]
     private float smoothSpeed = 0.125f; // The speed of the camera's movement 
     private Vector3 offset; // The offset between the camera and the target

    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
  void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calculate the desired position of the camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Smoothly interpolate between the current position and the desired position
        transform.position = smoothedPosition; // Update the camera's position
        transform.rotation = Quaternion.LookRotation(target.position - transform.position); // Make the camera look at the target
    }
}
