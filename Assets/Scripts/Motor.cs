using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {
	public Rigidbody BodyToAffect;

	public float DownwardsThrust = 25.0f;
	public float PerpendicularThrust = 10.0f;
	public bool TurnsClockwise = false;
	public float Power = 0.0f;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		Power = Mathf.Clamp(Power, 0, 1);
		Vector3 upForceVector = new Vector3(0f, DownwardsThrust * Power, 0f);
		Vector3 perpForceVector = new Vector3(TurnsClockwise ? PerpendicularThrust * Power: -PerpendicularThrust * Power, 0f, 0f);
		BodyToAffect.AddForceAtPosition(transform.rotation * upForceVector, transform.position);
		BodyToAffect.AddForceAtPosition(transform.rotation * perpForceVector, transform.position);
	}
}
