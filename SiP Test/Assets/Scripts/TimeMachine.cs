using UnityEngine;

public class TimeMachine : MonoBehaviour
{
	#region Fields
	[SerializeField]
	InGameButton addTime, subtractTime;
	[SerializeField]
	Transform arrow;
	[SerializeField]
	Light sun;
	[SerializeField]
	float transitionTime = 1f;

	float currentTime = 6f;
	float moveTime = 50;
	Quaternion sunOldRot, sunNewRot , arrowOldRot, arrowNewRot;
	#endregion

	#region Properteies
	float CurrentTime
	{
		get { return currentTime; }
		set
		{
			if (value >= 24)
			{
				currentTime = value - 24;
			}
			else if (value < 0)
			{
				currentTime = value + 24;
			}
			else
			{
				currentTime = value;
			}
		}
	}
	#endregion

	#region Methods
	private void Start()
	{
		addTime.AddListener(AddTime);
		subtractTime.AddListener(SubtractTime);
	}
	private void Update()
	{
		if (moveTime < transitionTime)
		{
			moveTime += Time.deltaTime;
			sun.transform.rotation = Quaternion.Lerp(sunOldRot, sunNewRot, moveTime / transitionTime);
			arrow.localRotation = Quaternion.Lerp(arrowOldRot, arrowNewRot, moveTime / transitionTime);
		}
	}
	void AddTime()
	{
		CurrentTime++;
		SetUp();
	}
	void SubtractTime()
	{
		CurrentTime--;
		SetUp();
	}
	void SetUp()
	{
		sunOldRot = sun.transform.rotation;
		sunNewRot = Quaternion.Euler(CurrentTime * 15, 30, 0);
		arrowOldRot = arrow.localRotation;
		arrowNewRot = Quaternion.Euler(-CurrentTime * 15, 180, 180);
		moveTime = 0;
		if(CurrentTime > 12 && CurrentTime < 23)
		{
			sun.intensity = Mathf.Abs(18 - CurrentTime)/6;
		}
	}
	#endregion
}
