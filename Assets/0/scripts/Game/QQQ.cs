
using UnityEngine;
using System.Collections;


public class QQQ : MonoBehaviour
{
	public GUIText about;
	
	public AudioClip intro;

	public AudioClip loop;


	void Start()
	{
		audio.PlayOneShot(intro);
		
		Invoke("PlayLoop", 4);
		
		InvokeRepeating("RandomRotation", 0, 1);
	}

	
	void OnBecameVisible()
	{
		Invoke("Fin", 0.5f);
	}
	
	
	private void PlayLoop()
	{
		audio.PlayOneShot(loop);
		
		Invoke("PlayLoop", 35);
	}

	
	private void Fin()
	{
		Messenger.Broadcast(CameraEvent.Focus, transform);
	
		Messenger.Broadcast(MotionEvent.Stop);
		
		Messenger.Broadcast(KeyboardInputEvent.Stop);
		
		about.text = "Ludum DARE 26\n#minimalism\n\ngame @alvivar\ncode @tzamora";
	}

	
	private void RandomRotation()
	{
		transform.rotation = Random.rotation;
	}
}
