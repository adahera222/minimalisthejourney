using UnityEngine;
using System.Collections;

public class CameraMediator : MonoBehaviour
{
	public float cameraSpeed = 10f;
	public Transform currentFocus;
	public Vector2 offset;
	
	void Awake ()
	{
		Messenger.AddListener<Transform> (CameraEvent.Focus, FocusEventHandler);
	}
	
	void FocusEventHandler (Transform position)
	{
		currentFocus = position;
	}
	
	void Update ()
	{
		Vector3 newCameraPosition = new Vector3 (currentFocus.position.x + offset.x, currentFocus.position.y + offset.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newCameraPosition, Time.deltaTime * cameraSpeed);
	}
}
