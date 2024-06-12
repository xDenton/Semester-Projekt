using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Rigidbody rigidBody;
    private Quaternion initialRotation;

    public float maxspeed = 50f;
    public float speed = 5f;
    public float acceleration = 2f;
    public float deceleration = 1f;
    public float coastDeceleration = 0.5f;
    public float waterDrag = 0.98f;

    public float turnspeed = 4f;
    public float turnsmoothtime = 0.1f;
    public float returnSpeed = 5f;

    //Zeitverwaltung
    public int freezeFrames = 0;  // Zähler für die Anzahl der Frames, die die Eingabe eingefroren werden soll
    public bool isInputFrozen = false;  // Zustand, ob die Eingabe eingefroren ist


    //Rudermechanik
    public float rowingForce = 10f; // Die Kraft, die bei jedem Ruderschlag angewendet wird
    public float rowingInterval = 1.5f; // Zeit zwischen Ruderschlägen in Sekunden
    //private float nextRowTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        rigidBody.freezeRotation = true;

        initialRotation = transform.rotation;
        rigidBody.drag = waterDrag; // Linearer Drag, kontrolliert das Abbremsen der Vorwärtsbewegung
        rigidBody.angularDrag = 2.0f; // Angular Drag, kontrolliert das Abbremsen der RotationS
    }

    // Update is called once per frame
    void Update()
    {
        //Erkennung auf Tasten
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (vertical > 0f && freezeFrames == 0)
        {
            speed += acceleration * Time.deltaTime;
        }
        else
        {
            speed -= coastDeceleration * Time.deltaTime;
        }
        //Begrenzung der Geschwindigkeit
        speed = Mathf.Clamp(speed, 0f, maxspeed);
        //Rudern einführen
        /* if (vertical > 0f && Time.time >= nextRowTime)
        {
            ApplyRowingForce();
            nextRowTime = Time.time + rowingInterval;
        }
        else
        {
            speed -= coastDeceleration * Time.deltaTime;
        }*/


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
                Quaternion targetRotation = Quaternion.Euler(rotation * turnspeed * Time.deltaTime * 0.05f * speed);

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
        if (freezeFrames > 0)
        {
            freezeFrames--;
            if (freezeFrames == 0)
            {
                isInputFrozen = false;  // Eingabe wieder freigeben
            }
            return;  // Eingabe wird ignoriert
        }
        //if (Input.GetKeyDown(KeyCode.W))
        if (vertical > 0f)
        {
            if (speed < maxspeed && freezeFrames == 0)
            {
                // Aktion bei Druck der W-Taste, z.B. Beschleunigen
                rigidBody.AddForce(transform.forward * 10f);  // Beispielhafte Kraftanwendung
            }
            else
            {
                //StartCoroutine
                // W-Taste für 2 Frames einfrieren, wenn die maximale Geschwindigkeit erreicht ist
                FreezeInputForFrames(300);
                
            }
        }
    }
    private void FreezeInputForFrames(int frames)
    {
        freezeFrames = frames;
        isInputFrozen = true;

    }

        /*void ApplyRowingForce()
        {
            if (rigidBody.velocity.magnitude < maxspeed)
            {
                rigidBody.AddForce(transform.forward * rowingForce, ForceMode.Impulse);
            }
        }*/
}