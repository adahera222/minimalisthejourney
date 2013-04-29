
using UnityEngine;
using System.Collections;


public class God : MonoBehaviour
{
	private float thunderTime = 1f;
	
	private float timeSinceStart = 1.1f;
	
	private int thunderBursts = 1;
	
	public int thunderBurstCounter = 0;
	
	private bool doThunders = false;

	
	void Start()
	{
		InvokeRepeating("Thunder", 5f, 5f);
	}

	
	void Update()
	{
		if ( doThunders )
		{
			ApplyThunderEffect();
		}
	}

	
	void ApplyThunderEffect()
	{
		//
		// the effect will be executed when the timeSinceStart is below the thunder time
		//
		
		if ( timeSinceStart <= thunderTime )
		{
			timeSinceStart += Time.deltaTime;
			
			Camera.mainCamera.backgroundColor = Color.Lerp(Color.white, Color.black, timeSinceStart);
		}
		else
		{
			//
			// by default the background will be black
			//
			
			Camera.mainCamera.backgroundColor = Color.black;
			
			if ( thunderBurstCounter < thunderBursts )
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

	
	protected void Thunder()
	{
		Messenger.Broadcast(ThunderEvent.Thunder);
		
		timeSinceStart = 0f;
		
		thunderBurstCounter = 0;
		
		doThunders = true;
	}
}
