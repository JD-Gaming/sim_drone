using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadController : MonoBehaviour {
	public IMUSensor Sensor;
	public Motor FrontLeftMotor, FrontRightMotor, BackLeftMotor, BackRightMotor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		FrontRightMotor.Power = 0f;
		FrontLeftMotor.Power = 0f;
		BackRightMotor.Power = 0f;
		BackLeftMotor.Power = 0f;

		if (Input.GetButton("F_R"))
		{
			FrontRightMotor.Power = 1f;
		}

		if (Input.GetButton("F_L"))
		{
			FrontLeftMotor.Power = 1f;
		}

		if (Input.GetButton("B_R"))
		{
			BackRightMotor.Power = 1f;
		}

        if (Input.GetButton("B_L"))
        {
            BackLeftMotor.Power = 1f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            transform.SetPositionAndRotation(new Vector3(0f, 0.2f, 0f), Quaternion.Euler(0f, 0f, 0f));
        }


    }
}
