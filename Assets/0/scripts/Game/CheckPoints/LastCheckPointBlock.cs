
using UnityEngine;
using System.Collections;


public class LastCheckPointBlock : MonoBehaviour
{
	void OnTriggerEnter()
	{
		Messenger.Broadcast(CheckPointEvent.Save, new Vector3( -5f, -1f, 0 ));
	}
}
