using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
	#region Fields
	[SerializeField]
	Ball host;
	[SerializeField]
	float bounceDeapth = 1f , rotationSpeed = 30f;
	[SerializeField]
	GameObject onPickUpEffect;
	float transitionTime = 0;

	Vector3 lowPosition, highPosition;
	#endregion

	#region Methods
	private void Start()
	{
		lowPosition = transform.position + Vector3.up * bounceDeapth/2;
		highPosition = transform.position + Vector3.down * bounceDeapth/2;
		transitionTime = .5f;
	}
	private void Update()
	{
		if(transitionTime < 1)
		{
			transform.position = Vector3.Lerp(lowPosition, highPosition, transitionTime);
			transitionTime += Time.deltaTime;
		}
		else
		{
			transitionTime = 0;
			Vector3 temp = lowPosition;
			lowPosition = highPosition;
			highPosition = temp;
		}
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			host.CollectedTrophy();
			GameObject temp = Instantiate(onPickUpEffect,transform.position,Quaternion.identity);
			temp.GetComponent<ParticleSystem>().Play();
			Destroy(temp, 1);
			Destroy(gameObject);
		}
	}
	#endregion
}
