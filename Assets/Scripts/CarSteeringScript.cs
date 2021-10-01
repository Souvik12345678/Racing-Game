using UnityEngine;

public class CarSteeringScript : MonoBehaviour
{

	public GameObject frontWheelLeft;
	public GameObject frontWheelRight;

	Vector3 localAngle;
	float steerAngle, maxSteerAngle = 30f;

	// Update is called once per frame
	void Update()
	{
		steerAngle = -Input.GetAxis("Horizontal") * maxSteerAngle;
	}

	void LateUpdate()
	{
		localAngle = frontWheelLeft.transform.localEulerAngles;
		localAngle.z = steerAngle;
		frontWheelLeft.transform.localEulerAngles = localAngle;
		frontWheelRight.transform.localEulerAngles = localAngle;
	}
}
