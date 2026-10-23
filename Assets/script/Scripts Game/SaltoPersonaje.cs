using UnityEngine;

public class SaltoPersonaje : MonoBehaviour
{
   
    public float fuerzaSalto = 7f;
    public bool estaEnSuelo;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Detectar si presiona la tecla de salto (barra espaciadora)
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo)
        {
            Saltar();
        }
    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        estaEnSuelo = true;
    }

    // Detectar cuando toca el suelo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            estaEnSuelo = true;
        }
    }
}
