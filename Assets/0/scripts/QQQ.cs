using UnityEngine;
using System.Collections;

public class QQQ : MonoBehaviour
{
	void Start ()
	{
		InvokeRepeating ("RandomRotation", 0, 1);
	}
	
	void OnBecameVisible ()
	{
		Invoke ("Fin", 0.5f);
	}
	
	private void Fin ()
	{
		Messenger.Broadcast (CameraEvent.Focus, transform);
		Messenger.Broadcast (MotionEvent.Stop);
		Messenger.Broadcast (KeyboardInputEvent.Stop);
	}
	
	private void RandomRotation ()
	{
		transform.rotation = Random.rotation;
	}
}
