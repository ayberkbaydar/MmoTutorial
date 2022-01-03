using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCharacterController : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator[] _animatorLimbs;

    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private Vector3 v_velocity;
    private float moveSpeed;
    private float gravity;
    private GameObject tempPlayer;

    /*
    private Vector3 targetPosition;
    private Vector3 lookAtTarget;
    private Quaternion playerRot;
    float rotSpeed = 5;
    float speed = 10;
    bool moving = false;

    private Quaternion tempPlayerRot;
    private Vector3 tempTargetPosition;
    */

    void Start()
    {
        moveSpeed = 0.1f;
        gravity = 0.5f;
        tempPlayer = GameObject.FindGameObjectWithTag("Player");
        GameObject[] tempPlayerLimbs = GameObject.FindGameObjectsWithTag("Limb");
        _characterController = tempPlayer.GetComponent<CharacterController>();
        _animatorLimbs = new Animator[tempPlayerLimbs.Length];
        for (int i = 0; i < tempPlayerLimbs.Length; i++)
        {
            _animatorLimbs[i] = tempPlayerLimbs[i].GetComponent<Animator>();
        }
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        if (inputZ <= 0)
        {
            foreach (var item in _animatorLimbs)
            {
                item.SetBool("isRun", false);
            }
        }
        else
        {
            foreach (var item in _animatorLimbs)
            {
                item.SetBool("isRun", true);
            }
        }

    }

    private void FixedUpdate()
    {


        //input forward
        if (inputZ > 0)
        {
            v_movement = _characterController.transform.forward * inputZ * 70;
        }
        else if (inputZ < 0)
        {
            v_movement = _characterController.transform.forward * inputZ * 10;
        }
        else
        {
            v_movement = _characterController.transform.forward * inputZ * 0;
        }


        if (_characterController.isGrounded)
        {
            v_velocity.y = 0f;
        }
        else
        {
            v_velocity.y -= gravity * Time.deltaTime;
        }


        //character rotate
        _characterController.transform.Rotate(Vector3.up * inputX * (35 * Time.deltaTime));


        //char move + gravity
            _characterController.Move(v_movement * moveSpeed * Time.deltaTime);
            _characterController.Move(v_velocity);

        //if (Input.GetMouseButton(0))//animasyon eklenecek.
        //{
        //    SetTargetPosition();
        //    if (moving)
        //    {
        //        Move();
        //    }
        //}
        //else
        //{
        //    _characterController.Move(v_movement * moveSpeed * Time.deltaTime);
        //    _characterController.Move(v_velocity);
        //}
    }








    /*
    void SetTargetPosition()
    {
        Camera.main.ScreenToWorldPoint(Input.mousePosition);// bununla if(getmousebutton) bloðu içinde denenebilir.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            targetPosition = hit.point;
            //Debug.Log("x:" + targetPosition.x);
            //Debug.Log("y:" + targetPosition.y);
            //Debug.Log("z:" + targetPosition.z);
            lookAtTarget = new Vector3(targetPosition.x - tempPlayer.transform.position.x, targetPosition.y - tempPlayer.transform.position.y, targetPosition.z - tempPlayer.transform.position.z);
            //Debug.Log("look_x:" + lookAtTarget.x);
            //Debug.Log("look_y:" + lookAtTarget.y);
            //Debug.Log("look_z:" + lookAtTarget.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            //Debug.Log("rot_x" + playerRot.x);
            //Debug.Log("rot_y" + playerRot.y);
            //Debug.Log("rot_z" + playerRot.z);
            //Debug.Log("rot_w" + playerRot.w);
            moving = true;
        }
    }

    void Move()
    {
        tempPlayerRot = new Quaternion(playerRot.x * 0, playerRot.y * 1, playerRot.z * 0, playerRot.w * 1);
        tempTargetPosition = new Vector3(targetPosition.x * 1, targetPosition.y * 0, targetPosition.z * 1);
        tempPlayer.transform.rotation = Quaternion.Slerp(tempPlayer.transform.rotation, tempPlayerRot, rotSpeed * Time.deltaTime);
        tempPlayer.transform.position = Vector3.MoveTowards(tempPlayer.transform.position, tempTargetPosition, speed * Time.deltaTime);
        if (tempPlayer.transform.position == targetPosition)
        {
            moving = false;
        }
    }
    */

}
