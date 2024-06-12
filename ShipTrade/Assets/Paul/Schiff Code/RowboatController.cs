using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowboatController : MonoBehaviour
{
    public float rowingForce = 10f; // Die Kraft, die bei jedem Ruderschlag angewendet wird
    public float maxSpeed = 5f; // Die maximale Geschwindigkeit des Bootes
    public float waterDrag = 0.98f; // Der Widerstand des Wassers
    public float rowingInterval = 1.5f; // Zeit zwischen Ruderschlägen in Sekunden

    private Rigidbody rb;
    private float nextRowTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;


        if (Time.time >= nextRowTime)
        {
            //ApplyRowingForce();
            nextRowTime = Time.time + rowingInterval;
        }

        /*float rotationInput = Input.GetAxis("Horizontal");

            if (rotationInput != 0f)
            {
                // Berechnen der gewünschten Drehung basierend auf der horizontalen Eingabe
                Vector3 rotation = Vector3.up * rotationInput;

                // Umwandeln des Vektors in eine Rotation
                Quaternion targetRotation = Quaternion.Euler(rotation * turnspeed * Time.deltaTime);

                // Anwendung der Rotation auf das Schiff
                transform.rotation *= targetRotation;
            }
            else
            {
                // Wenn keine Eingabe erfolgt, das Schiff langsam zur Ausgangsrotation zurückdrehen
                transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, returnSpeed * Time.deltaTime);
            }

        void ApplyRowingForce()
        {
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.forward * rowingForce, ForceMode.Impulse);
            }
        }*/

    }
}
