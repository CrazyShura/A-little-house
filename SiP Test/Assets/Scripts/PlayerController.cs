using UnityEngine;

public class PlayerController : MonoBehaviour
{
	#region Fields
	CharacterController controller;

	[SerializeField]
	LayerMask groundMask;
	[SerializeField]
	Transform cameraObj;
	[SerializeField]
	float speed = 10f, jumpStr = 5f, lookSensetivity = 100f;
	[SerializeField]
	Vector3 TPPosition;

	float xRot, yRot, gravPull;
	Vector3 lastMoveVector;
	#endregion

	#region Properties

	#endregion

	#region Methods
	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		float xRotIn = Input.GetAxis("Mouse Y") * lookSensetivity * Time.deltaTime;
		float yRotIn = Input.GetAxis("Mouse X") * lookSensetivity * Time.deltaTime;

		xRot += xRotIn;
		xRot = Mathf.Clamp(xRot, -90f, 90f);
		yRot += yRotIn;

		transform.localRotation = Quaternion.Euler(0f, yRot, 0f);
		cameraObj.localRotation = Quaternion.Euler(-xRot, 0f, 0f);
		if (Physics.OverlapSphere(transform.position - new Vector3(0, controller.height / 2, 0), .3f, groundMask).Length > 0)
		{
			if (Input.GetButtonDown("Jump"))
			{
				gravPull = -jumpStr;
			}
			else
			{
				if (gravPull > 0)
				{
					gravPull = 0;
				}
			}
		}
		else
		{
			gravPull += 10 * Time.deltaTime;
		}

		float y = Input.GetAxis("Vertical");
		float x = Input.GetAxis("Horizontal");

		Vector3 move = transform.forward * y + transform.right * x;
		controller.Move(move * speed * Time.deltaTime + new Vector3(0, -gravPull, 0) * Time.deltaTime);
		lastMoveVector = move;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 7)
		{
			controller.enabled = false;
			transform.position = TPPosition;
			controller.enabled = true;
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		Rigidbody rbd = hit.gameObject.GetComponent<Rigidbody>();
		if(rbd != null)
		{
			rbd.AddForce(lastMoveVector);
		}
	}
	#endregion
}
