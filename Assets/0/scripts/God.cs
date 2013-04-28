using UnityEngine;
using System.Collections;

public class God : MonoBehaviour
{
	private int minTime = 3;
	private int maxTime = 6;
	private int thunderTime = 0;
	
	void Start ()
	{
		thunderTime = Random.Range (minTime, maxTime);
		Invoke ("Thunder", thunderTime);
	}
	
	void Update ()
	{
	
	}
	
	protected void Thunder ()
	{
		
	}
}
