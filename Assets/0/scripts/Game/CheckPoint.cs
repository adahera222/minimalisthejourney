
using UnityEngine;
using System.Collections;


public class CheckPoint : MonoBehaviour
{
	void OnTriggerEnter()
	{
		Messenger.Broadcast(CheckPointEvent.Save, this.transform.position);
	}
}
