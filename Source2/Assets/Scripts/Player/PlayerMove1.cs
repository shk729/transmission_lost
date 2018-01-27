using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
/*
public class PlayerMove : MonoBehaviour
{
    private GameObject player;
    static Rigidbody playerBody;

    Quaternion newRotation;
    float moveAngle;                                                      //angle in degrees
	float maxVelocity = 4f;

    private static Vector2 lastPlayerVelocity;                            //last velocity before impact
    private int upgradeEngine=0;                                            //player upgrade system

    //private bool PlayerTouchRock;
    public static bool PlayerMovePhase = false;
    static float rotationDirection;
    Vector2 moveDirection;
    Vector2 startTouchPosition;
    Vector2 currentTouchPosition;
 
    void Awake()
    {
        //upgradeEngine = DataFileController.upgradeEngine;
        playerBody = GetComponent<Rigidbody>();
        player = this.gameObject;
    }

    void FixedUpdate()
    {
        KeyboardMove();
        TouchMove();
        MouseMove();

       // PlayerTouchRock = PlayerCollisionAndHUD.PlayerTouchRock;
       // if (!PlayerTouchRock) lastPlayerVelocity = GetPlayerVelocity();

		CheckPlayerVelocity ();
  
    }
	void CheckPlayerVelocity()
    {
		
		Vector2 currentVelocity = GetPlayerVelocity();

		if (currentVelocity.x > maxVelocity) currentVelocity.x = maxVelocity;
		else if (currentVelocity.x < -maxVelocity) currentVelocity.x = -maxVelocity;
		if (currentVelocity.y > maxVelocity) currentVelocity.y = maxVelocity;
		else if (currentVelocity.y < -maxVelocity) currentVelocity.y = -maxVelocity;

		playerBody.velocity = currentVelocity;

		//Check Player drag
		if (!SlowAreaSlowing.slowed)
		{
			if (currentVelocity.magnitude > 3f)
				playerBody.drag = currentVelocity.magnitude * 0.015f;
			else
				playerBody.drag = 0;		
		} else
			playerBody.drag = 1;
	}

	void CheckPlayerDrag()
	{


	}

    void PlayerMoveCalculation (Vector2 mDirection)
    {
		float rotationSpeed = 0.3f+GetPlayerVelocity().magnitude/5;                              //smooth rotation on lower speed
		playerBody.AddForce(mDirection * (2f * (1 + 0.05f * upgradeEngine)));                    //5% to force

	    playerBody.freezeRotation = true;
            Vector3 eulerAngles = player.transform.rotation.eulerAngles;
            float playerAngle = eulerAngles.z;
            if (playerAngle > 180) playerAngle -= 360;
            float rotAngle = Mathf.Atan(mDirection.normalized.y / mDirection.normalized.x);

            if (mDirection.normalized.x >= 0) moveAngle = rotAngle * Mathf.Rad2Deg - 90;
            else if (mDirection.normalized.x < 0) moveAngle = rotAngle * Mathf.Rad2Deg + 90;

            newRotation = Quaternion.Euler(0, 0, moveAngle);
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, newRotation, Time.fixedDeltaTime * rotationSpeed);
        playerBody.freezeRotation = false;

        //Calculationg for animation
        rotationDirection = playerAngle - moveAngle;

    }//void PlayerMove

    void TouchMove()
    {
         Touch[] phoneTouches = Input.touches;
        if (Input.touchCount > 0)
        {   
                PlayerMovePhase = true;
				currentTouchPosition = Camera.main.ScreenToWorldPoint(phoneTouches[0].position);

                moveDirection = new Vector2(currentTouchPosition.x - player.transform.position.x,
                                                    currentTouchPosition.y - player.transform.position.y);
                moveDirection = moveDirection * 0.1f;
                PlayerMoveCalculation(moveDirection);

        }//count is exist
        else
            PlayerMovePhase = false;
    }

    void KeyboardMove()
	{
		float forceScale = 5f;
		
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if (inputX != 0 || inputY != 0)
        {
            moveDirection = new Vector2(inputX * forceScale, inputY * forceScale);
            PlayerMoveCalculation(moveDirection);
        }
    } //void KeyboardMove


    void MouseMove()
    {        
        //if (!PlayerTouchRock)
        {
            if (Input.GetMouseButton(0))
            {
                PlayerMovePhase = true;
                currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                moveDirection = new Vector2(currentTouchPosition.x - player.transform.position.x,
                                                    currentTouchPosition.y - player.transform.position.y);
                moveDirection = moveDirection * 0.3f; 

                PlayerMoveCalculation(moveDirection);

            }
            else
                PlayerMovePhase = false;
            
        }
    }//  void MouseMove()

    public static Vector2 GetPlayerVelocity()
    {
        return playerBody.velocity;
    }

    public static Vector2 GetPlayerVelocityBeforeImpact()
    {
        return lastPlayerVelocity;
    }

    public static Vector3 GetPlayerPosition()
    {
        return playerBody.position;
    }

    public static float GetPlayerRotation()
    {
        return rotationDirection;
    }


}
*/