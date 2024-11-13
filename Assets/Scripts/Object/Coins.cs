using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class Coins : MonoBehaviour
{
    Animator animator;
    AudioSource coinSound;
    private string animBoolNameTr = "Eat";
    private int animBoolName;

    private void Start()
    {
        animator = GetComponent<Animator>();
        coinSound = GetComponent<AudioSource>();
        animBoolName = Animator.StringToHash(animBoolNameTr); // string 에서 int 로 바꾸면 메모리 효율 up 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            animator.SetBool(animBoolName, true);
            coinSound.Play();
        }
    }


    public void CountCoin() 
    {
        GameManager.instance.Coins++;
        Destroy(this.gameObject);
    }
}
