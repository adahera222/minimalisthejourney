
using UnityEngine;
using System.Collections;


public class KeyboardInput : MonoBehaviour
{
	public bool isEnabled = true;

	
	void Awake()
	{
		Messenger.AddListener(KeyboardInputEvent.Stop, Stop);
		
		Messenger.AddListener(KeyboardInputEvent.Play, Play);
	}

	
	void Update()
	{
		if ( !isEnabled )
		{
			return;
		}
		
		Detect();
	}


	private void Stop()
	{
		isEnabled = false;
	}

	
	private void Play()
	{
		isEnabled = true;
	}


	private void Detect()
	{
		if ( Input.GetKeyDown(KeyCode.Space) )
		{
			Messenger.Broadcast(MotionEvent.Jump);
		}
	}
	
}
