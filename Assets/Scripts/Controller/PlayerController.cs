using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    string isDieTr = "Die";
    string isMoveTr = "isMove";
    string isIdleTr = "isIdle";
    int isDie;
    int isMove;
    int isIdle;
    IEnumerator moveCoroutine;
    IEnumerator jumpCoroutine;
    float moveDuration = 0.02f;
    float jumpDuration = 0.05f;
    float moveCount;
    float jumpCount;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        isDie = Animator.StringToHash(isDieTr);
        isMove = Animator.StringToHash(isMoveTr);
        isIdle = Animator.StringToHash(isIdleTr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        if (GameManager.instance.IsGameOver)  return; 
        Vector3 input = context.ReadValue<Vector3>();
        if (input.magnitude > 1) return;
        if (context.phase == InputActionPhase.Performed)
        {
           
            moveCoroutine = MoveCoroutine(input);
            StartCoroutine(moveCoroutine);
            
            if (input.y > 0)  GameManager.instance.Score++; 
            Rotate(input);
            
        } 
    }

    public IEnumerator MoveCoroutine(Vector3 input) 
    {
        moveCount = 0;
        while (moveCount < 1) 
        {
            transform.position += input*moveDuration;
            moveCount += moveDuration;
            yield return null;
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
        if (GameManager.instance.IsGameOver) return;
        if (context.phase == InputActionPhase.Performed)
        {
            Vector3 input = Vector3.up;
            jumpCoroutine = JumpCoroutine(input);
            StartCoroutine(jumpCoroutine);
        }
    }

    public IEnumerator JumpCoroutine(Vector3 input)
    {
        jumpCount = 0;
        while (jumpCount < 1)
        {
            transform.position += input * jumpDuration;
            jumpCount += jumpDuration;
            if (jumpCount >= 1) transform.position -= input;
            yield return null;
        }

    }

    public void Hit() 
    {
        animator.SetBool(isDie,true);
        animator.SetBool(isIdle,false);
        GameManager.instance.GameOver();
    }

    
}
