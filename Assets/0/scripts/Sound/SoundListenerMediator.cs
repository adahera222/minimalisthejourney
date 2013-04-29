
using UnityEngine;
using System.Collections;


public class SoundListenerMediator : MonoBehaviour
{
	public AudioClip clipStart;
	
	public AudioClip clipLoop;
	
	public AudioSource audioSourceIntro;
	
	public AudioSource audioSourceLoop;

	
	void Start()
	{
		// audioSourceIntro.Play();
	}

	
	void Update()
	{
		// Debug.Log(audioSourceIntro.isPlaying);
		
		if ( !audioSourceIntro.isPlaying )
		{
			//
			// play the loop part
			//
			
			if ( !audioSourceLoop.isPlaying )
			{
				audioSourceLoop.Play();
			}
		}
	}
}
