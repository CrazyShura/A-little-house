using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	#region Fields
	[SerializeField]
	Trophy[] trophies;
	int amount;
	Rigidbody rgbd;
	#endregion

	#region Methods
	private void Start()
	{
		amount = trophies.Length;
		rgbd = GetComponent<Rigidbody>();
	}
	public void CollectedTrophy()
	{
		amount--;
		if(amount == 0)
		{
			rgbd.useGravity = true;
			transform.position = new Vector3(-8, 10, 0);
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 7)
		{
			rgbd.velocity = Vector3.zero;
			transform.position = new Vector3(-8, 10, 0);
		}
	}
	#endregion
}
