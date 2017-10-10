using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerControler : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;
	[SerializeField]
	private float thrusterForce = 1000f;

	private PlayerMotor motor;


	void Start ()
	{
		motor = GetComponent<PlayerMotor>();
	}

	void Update ()
	{

		float _xMove = Input.GetAxisRaw ("Horizontal");
		float _zMove = Input.GetAxisRaw ("Vertical");

		Vector3 _movHorizontal = transform.right * _xMove;
		Vector3 _movVertical = transform.forward * _zMove;

		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		motor.Move(_velocity);

		float _yRot = Input.GetAxisRaw("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * lookSensitivity;

		motor.Rotate (_rotation);


		float _xRot = Input.GetAxisRaw("Mouse Y");

		float _cameraRotationX = _xRot * lookSensitivity;

		motor.RotateCamera (_cameraRotationX);

		Vector3 _thrusterforce = Vector3.zero;
		if (Input.GetButton ("Jump")) 
		{
			_thrusterforce = Vector3.up * thrusterForce;
		}

		motor.ApplyThruster (_thrusterforce);
	}

}
