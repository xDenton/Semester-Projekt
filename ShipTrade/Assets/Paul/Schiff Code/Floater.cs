using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;
    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    private Vector3 gravityForce;

    // Start is called before the first frame update
    void Start()
    {
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody>();
            if (rigidBody == null)
            {
                Debug.LogError("No Rigidbody component found!");
            }
        }
        gravityForce = Physics.gravity / floaterCount;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        ApplyGravity();
        ApplyBuoyancy();

        rigidBody.AddForceAtPosition(Physics.gravity / floaterCount, transform.position, ForceMode.Acceleration);

    }
    // wird die Gravitation angewendet
    void ApplyGravity()
    {
        rigidBody.AddForceAtPosition(gravityForce, transform.position, ForceMode.Acceleration);
    }
    // Wird die Antriebskraft berechnet und angewendet
    void ApplyBuoyancy()
    {
        // Die wellenh�he wird abgefragt
        float waveHeight = WaveManager.instance.GetWaveHeight(transform.position.x);
        if (transform.position.y < waveHeight)
        {
            float displacementMultiplier = Mathf.Clamp01((waveHeight - transform.position.y) / depthBeforeSubmerged) * displacementAmount;
            rigidBody.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rigidBody.AddForce(displacementMultiplier * -rigidBody.velocity * waterDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rigidBody.AddTorque(displacementMultiplier * -rigidBody.angularVelocity * waterAngularDrag * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}

