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
    static Rigidbody2D playerBody;

    Quaternion newRotation;
    float moveAngle;                                                      //angle in degrees
    float maxVelocity = 3.5f;

    private static Vector2 lastPlayerVelocity;                            //last velocity before impact
    private int upgradeEngine;                                            //player upgrade system

    private bool PlayerTouchRock;
    public static bool PlayerMovePhase = false;
    static float rotationDirection;
    Vector2 moveDirection;
    Vector2 startTouchPosition;
    Vector2 currentTouchPosition;
 
    void Awake()
    {
        upgradeEngine = DataFileController.upgradeEngine;
        playerBody = GetComponent<Rigidbody2D>();
        player = this.gameObject;
    }

    void FixedUpdate()
    {
        KeyboardMove();
        TouchMove();
        MouseMove();

        PlayerTouchRock = PlayerCollisionAndHUD.PlayerTouchRock;
        if (!PlayerTouchRock) lastPlayerVelocity = GetPlayerVelocity();

		CheckPlayerVelocity ();
  
    }
	void CheckPlayerVelocity(){
		
		Vector2 currentVelocity = GetPlayerVelocity();

		if (currentVelocity.x > maxVelocity) currentVelocity.x = maxVelocity;
		else if (currentVelocity.x < -maxVelocity) currentVelocity.x = -maxVelocity;
		if (currentVelocity.y > maxVelocity) currentVelocity.y = maxVelocity;
		else if (currentVelocity.y < -maxVelocity) currentVelocity.y = -maxVelocity;

		playerBody.velocity = currentVelocity;

		if (currentVelocity.magnitude > 2.5f)
			playerBody.drag = currentVelocity.magnitude * 0.05f;
		else
			playerBody.drag = 0;
	}

    void PlayerMoveCalculation (Vector2 mDirection)
    {
		float rotationSpeed = 2f;
		playerBody.AddForce(mDirection * (1.5f * (1 + 0.05f * upgradeEngine))); //5% to force

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