using Unity.Mathematics;
using UnityEngine;

public class FloatingUI : MonoBehaviour
{
    [Header("Floating UI Settings")]
    public float floatspeed = 2.5f;
    public float Amplitude = 0.5f;

    private Vector3 initialPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     //Save the position on the Object 
     initialPosition=transform.localPosition;
    }
    

    // Update is called once per frame
    void Update()
    {
      //Calculate the Position of the Object
      float newY = initialPosition.y + Mathf.Sin(Time.time * floatspeed) * Amplitude;

        //Aplly the movement to the Object
        transform.localPosition = new Vector3(initialPosition.x, newY, initialPosition.z);
    }
}