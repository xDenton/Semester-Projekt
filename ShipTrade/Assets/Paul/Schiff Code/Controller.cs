using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody rigidBody;
    private Quaternion initialRotation;

    public float maxspeed = 300f;
    public float speed = 5f;
    public float acceleration = 2f;
    public float deceleration = 1f;
    public float coastDeceleration = 0.5f;

    public float turnspeed = 4f;
    public float turnsmoothtime = 0.1f;
    public float returnSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        rigidBody.freezeRotation = true;

        initialRotation = transform.rotation;
        rigidBody.drag = 1.5f; // Linearer Drag, kontrolliert das Abbremsen der Vorwärtsbewegung
        rigidBody.angularDrag = 2.0f; // Angular Drag, kontrolliert das Abbremsen der RotationS
    }

    // Update is called once per frame
    void Update()
    {
        //Erkennung auf Tasten
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (vertical > 0f)
        {
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            speed -= coastDeceleration * Time.deltaTime;
        }
        //Begrenzung der Geschwindigkeit
        speed = Mathf.Clamp(speed, 0f, maxspeed);



        if (speed > 0f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnsmoothtime);
            // transform.rotation = Quaternion.Euler(0f, angle, 0f);

            float rotationInput = Input.GetAxis("Horizontal");

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

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //Debug.Log(moveDir.normalized.ToString());
            controller.Move(moveDir.normalized * speed * Time.deltaTime);

        }
    }
}