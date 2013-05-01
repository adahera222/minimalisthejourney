
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
	
	private float extraJumps = 1;
	
	private int jumps = 0;
	
	private bool resetGravity = false;
	
	
	void Awake()
	{
		Messenger.AddListener( MotionEvent.Stop, Stop );		

		Messenger.AddListener( MotionEvent.Jump, Jump );
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
			movement = new Vector3( Input.GetAxis( "Horizontal" ), 0, 0 );
		}
				
		movement = transform.TransformDirection( movement );
		
		movement *= groundSpeed;
				
		movement.y = yBackup;
			
		if ( control.isGrounded && !resetGravity )
		{
			jumps = 0;
		}
		else
		{
			movement.y -= gravity * Time.deltaTime;
		}
		
		control.Move( movement * Time.deltaTime );
	}

	
	void OnControllerColliderHit( ControllerColliderHit hit )
	{
		if ( transform.position.y > hit.point.y )
		{
			movement = Vector3.zero;
			
			resetGravity = false;
		}
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
		resetGravity = true;
		
		if ( jumps > extraJumps )
		{
			return;
		}
		
		movement.y = jumpSpeed;
		
		jumps += 1;
	}
}
