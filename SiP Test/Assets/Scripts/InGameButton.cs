using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameButton : MonoBehaviour
{
	#region Fields
	UnityEvent buttonPressed = new UnityEvent();
	Material mat;
	Color startColor = Color.white;
	Color hightlightCollor = Color.red;
	#endregion

	#region Methods
	private void Start()
	{
		mat = GetComponent<MeshRenderer>().material;
	}
	public void AddListener(UnityAction action)
	{
		buttonPressed.AddListener(action);
	}
	private void OnMouseOver()
	{
		mat.color = hightlightCollor;
	}
	private void OnMouseExit()
	{
		mat.color = startColor;
	}
	private void OnMouseDown()
	{
		buttonPressed.Invoke();
	}
	#endregion
}
