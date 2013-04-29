
using UnityEngine;
using System.Collections;


public class CheckPointManager : MonoBehaviour
{
	private Vector3 lastSavePosition = Vector3.zero;
	
	
	void Awake()
	{
		Messenger.AddListener<Vector3>(CheckPointEvent.Save, Save);
		
		Messenger.AddListener<GameObject>(CheckPointEvent.Respawn, Respawn);
	}

	
	private void Save( Vector3 newPosition )
	{
		lastSavePosition = newPosition;
	}
	
	
	private void Respawn( GameObject player )
	{
		player.transform.position = lastSavePosition;
	}
}
