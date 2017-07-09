using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {
	public Rigidbody BodyToAffect;

	public float MaxRPM = 250f;
	public float RotorDiameterCm = 10.0f;
    public float ForceCoefficient = 6.11e-8f;
    public float MomentCoefficient = 1.5e-9f;

    public bool RotateClockwise = false;

	public float Power = 0.0f;
    public float Mass = 0.040f;
    public float MotorRadiusCm = 1.5f;

    // Use this for initialization
    void Start () {
        // Future versions will calculate thrust based on roto size et c.
        //float RotorRadius = RotorDiameterCm / 200;
        //float RotorArea = RotorRadius * RotorRadius * Mathf.PI;

        //Vector3 Inertia = new Vector3(0f, Mass * (MotorRadiusCm / 100.0f) * (MotorRadiusCm / 100.0f) / 2.0f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate() {
		Power = Mathf.Clamp(Power, 0, 1);
        float RotationsPerSecond = MaxRPM * Power / 60.0f;
        float AngularVelocity = 2 * Mathf.PI * RotationsPerSecond;

        float ForceMagnitude = ForceCoefficient * AngularVelocity * AngularVelocity;
        Vector3 upForceVector = new Vector3(0f, ForceMagnitude, 0f);
        BodyToAffect.AddForceAtPosition(transform.rotation * upForceVector, transform.position);

        // These will eventually be used to calculate torque properly, I think
        //Vector3 Moment = new Vector3(0f, MomentCoefficient * AngularVelocity * AngularVelocity * (RotateClockwise ? 1 : -1), 0f);
        //Vector3 AngularMomentum = Inertia * AngularVelocity;
    }
}
