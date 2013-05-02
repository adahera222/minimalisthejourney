
using UnityEngine;
using System.Collections;


public class ThunderBlockMediator : MonoBehaviour
{
	private float timeSinceStart = 0f;

	
	void Awake()
	{
		Messenger.AddListener(ThunderEvent.Thunder, ThunderEventHandler);
	}

	
	void ThunderEventHandler()
	{
		timeSinceStart = 0f;
	}
	
	//
	//
	//

	
	void Update()
	{
		if ( timeSinceStart <= 1f )
		{
			timeSinceStart += Time.deltaTime;
			
			transform.renderer.material.color = Color.Lerp(Color.white, Color.black, timeSinceStart);
		}
	}
}
