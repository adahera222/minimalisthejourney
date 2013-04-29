using UnityEngine;
using System.Collections;

public enum GeneralSounds
{
	MenuBackgroundSound,
	GameBackgroundSound,
	PointUpSound,
	fall,
	TakeItem,
	Turbo
};

public class SoundManager : MonoBehaviour {
	
	public AudioSource currentBackgroundSound;
	
	public AudioSource[] audioSources;
	
	AudioSource audioSource;
	
	void Awake()
	{
		/*Messenger.AddListener<string>( SoundEvent.PlaySound, PlaySoundEventHandler);
		
		Messenger.AddListener<string>( SoundEvent.PlayBackgroundSound, PlayBackgroundSoundEventHandler);
		
		Messenger.AddListener<string>( SoundEvent.PlayBackgroundSound, PlayBackgroundSoundEventHandler);
		
		Messenger.AddListener<bool>( SoundEvent.MuteSound, MuteSoundEventHandler);
		
		Messenger.AddListener( SoundEvent.StopBackgroundSound, StopBackgroundSoundEventHandler);*/
	}
	
	// Use this for initialization
	void Start () {
		
		audioSource = null;
	}
	
	public void PlaySoundEventHandler(string soundName)
	{
		PlaySound( soundName );
	}
	
	public void PlayBackgroundSoundEventHandler(string name)
	{
		PlayBackgroundSound ( name );
	}
	
	private void MuteSoundEventHandler(bool mute)
	{
		if(mute)
		{
			if(currentBackgroundSound != null)
			{
				if(mute)
				{
					currentBackgroundSound.volume = 0f;
				}
				else
				{
					currentBackgroundSound.volume = 1f;
				}
			}
		}
	}

	private void PlaySound( string soundName )
	{
		if(audioSources == null)
		{
			return;
		}

		for (int i = 0; i < audioSources.Length; i++)
		{
			if(audioSources[i].name == soundName )
			{
				audioSources[i].Play();
				
				break;
			}
		}
	}
	
	public void PlayBackgroundSound(string soundName)
	{
		if(audioSources == null)
		{
			return;
		}

		for (int i = 0; i < audioSources.Length; i++)
		{
			if(audioSources[i].name == soundName )
			{
				if(currentBackgroundSound != null && currentBackgroundSound.isPlaying)
				{
					currentBackgroundSound.Stop();
				}
				
				currentBackgroundSound = audioSources[i];
					 
				currentBackgroundSound.Play();
				
				break;
			}
		}
	}
	
	public void StopBackgroundSoundEventHandler()
	{
		if(currentBackgroundSound != null && currentBackgroundSound.isPlaying)
		{
			currentBackgroundSound.Stop();
		}
	}

	public void stopSounds()
	{
		if(currentBackgroundSound)
		{
			currentBackgroundSound.Stop();
		}
	}
	
	void OnDestroy()
	{
		if(currentBackgroundSound != null)
		{
			currentBackgroundSound.Stop();	
		}
		
		if(audioSource != null)
		{
			audioSource.Stop();	
		}
		
		audioSource = null;
		
		currentBackgroundSound = null;
		
		//Messenger.RemoveListener<string>( SoundEvent.PlaySound, PlaySoundEventHandler);
	}
}
