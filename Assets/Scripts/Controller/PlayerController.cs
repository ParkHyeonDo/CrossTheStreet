using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    string isDieTr = "Die";
    string isMoveTr = "isMove";
    int isDie;
    int isMove;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isDie = Animator.StringToHash(isDieTr);
        isMove = Animator.StringToHash(isMoveTr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        Vector3 input = context.ReadValue<Vector3>();
        if (input.magnitude > 1) return;
        if (context.phase == InputActionPhase.Performed)
        {
            animator.SetBool(isMove, true);
            transform.position += input;
            if (input.y > 0)  GameManager.instance.Score++; 
            Rotate(input);
            
        } 
    }

    private void Rotate(Vector3 input)
    {
        if (input.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (input.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (input.z > 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
        if (context.phase == InputActionPhase.Performed)
        {
            transform.position += Vector3.up;
        }
    }

    public void Hit() 
    {
        animator.SetBool(isDie,true);
        GameManager.instance.GameOver();
    }
}
