using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPPlane : MonoBehaviour
{
	#region Fiedls
	[SerializeField]
	Transform TPPosition;
	#endregion

	#region Methods
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log(other.gameObject.transform.position);
		other.gameObject.transform.position = TPPosition.position;
	}
	#endregion
}
