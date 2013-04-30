
using UnityEngine;
using System.Collections;


public class CheckPointBlock : MonoBehaviour
{
	void OnTriggerEnter()
	{
		Messenger.Broadcast(CheckPointEvent.Save, this.transform.position);
	}
}
