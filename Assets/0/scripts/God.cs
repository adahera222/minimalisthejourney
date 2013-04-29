using UnityEngine;
using System.Collections;

public class God : MonoBehaviour
{
	private int minTime = 3;
	
	private int maxTime = 6;
	
	private float thunderTime = 1f;
	
	private float[] thunderTimeList = {0.7f, 1.2f};
	
	private float timeSinceStart = 1.1f;
	
	private int thunderBursts = 1;
	
	public int thunderBurstCounter = 0;
	
	private bool doThunders = false;
	
	private float thunderInvokeTime = 4f;
	
	void Start ()
	{
		//float thunderInvokeTime = Random.Range (minTime, maxTime);
		
		InvokeRepeating("Thunder",4f,4f);
	}
	
	void Update()
	{
		if(doThunders)
		{
			ApplyThunderEffect();
		}
	}
	
	void ApplyThunderEffect()
	{
		//
		// the effect will be executed when the timeSinceStart is below the thunder time
		//
		
		if(timeSinceStart <= thunderTime)
		{
			timeSinceStart += Time.deltaTime;
			
			Camera.mainCamera.backgroundColor = Color.Lerp(Color.white, Color.black, timeSinceStart );
		}
		else
		{
			//
			// by default the background will be black
			//
			
			Camera.mainCamera.backgroundColor = Color.black;
			
			if(thunderBurstCounter < thunderBursts)
			{
				thunderBurstCounter++;
				
				timeSinceStart = 0f;
			}
			else
			{
				doThunders = false;
			}
		}
	}
	
	protected void Thunder ()
	{
		Messenger.Broadcast(ThunderEvent.Thunder);
		
		timeSinceStart = 0f;
		
		thunderBurstCounter = 0;
		
		doThunders = true;
	}
}
