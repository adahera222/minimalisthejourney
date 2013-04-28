using UnityEngine;
using System.Collections;

public class ZZZ : MonoBehaviour
{
	void Start ()
	{
		Messenger.Broadcast (CameraEvent.Focus, transform);
	}
	
	void Update ()
	{
		Vector3 currentPosition = transform.position;
		currentPosition.z = 0;
		transform.position = currentPosition;
	}
	
	void OnBecameInvisible ()
	{
		transform.position = Vector3.zero;
	}
}
