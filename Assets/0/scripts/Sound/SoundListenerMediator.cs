using UnityEngine;
using System.Collections;

public class SoundListenerMediator : MonoBehaviour 
{
	private Transform audioListener;
	
	void Awake()
	{
		Messenger.Broadcast<transform>(SoundEvent.SetListener, SetListenerEventHandler);
	}
	
	/// <summary>
	/// Sets the listener of this audiosource.
	/// </summary>
	void SetListenerEventHandler( Transform transform )
	{
		audioListener = transform;
	}
	
	void Update()
	{
		AudioSource audioSource = new AudioSource();
		
		audioSource.volume = Mathf.Lerp(0, 1, Vector3.Distance(audioListener.position, this.transform.position));
	}
}
