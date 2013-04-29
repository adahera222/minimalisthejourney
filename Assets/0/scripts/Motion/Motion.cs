
using UnityEngine;
using System.Collections;


[RequireComponent(typeof ( CharacterController ))]
public class Motion : MonoBehaviour
{
	public bool isEnabled = true;

	private CharacterController control;

	private Vector3 movement = Vector3.zero;

	private float gravity = 10f;

	private float groundSpeed = 1.75f;

	private float jumpSpeed = 3.5f;
	
	private int jumps = 0;

	
	void Awake()
	{
		Messenger.AddListener(MotionEvent.Stop, Stop);		

		Messenger.AddListener(MotionEvent.Jump, Jump);
	}

	
	void Start()
	{
		control = GetComponent<CharacterController>();
	}

	
	void Update()
	{
		float yBackup = movement.y;
		
		if ( isEnabled )
		{
			movement = new Vector3( Input.GetAxis("Horizontal"), 0, 0 );
		}
		
		movement = transform.TransformDirection(movement);
		
		movement *= groundSpeed;
		
		movement.y = yBackup;
		
		if ( !control.isGrounded )
		{
			movement.y -= gravity * Time.deltaTime;
		}
		else
		{
			jumps = 0;
		}
		
		control.Move(movement * Time.deltaTime);
		
		Debug.Log(movement + " :::: ");
	}

	
	private void Stop()
	{
		isEnabled = false;
		
		movement = Vector3.zero;
	}


	private void Play()
	{
		isEnabled = true;
	}


	private void Jump()
	{
		if ( jumps > 0 )
		{
			return;
		}
		
		movement.y = jumpSpeed;
		
		jumps += 1;
	}
}
