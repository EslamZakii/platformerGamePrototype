using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampline : MonoBehaviour
{
    Animator Tramplines;
    void Start()
    {
        Tramplines = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="MainCharacter")
        {
            print("hit");
            Tramplines.Play("trampolineAnim");
           
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "MainCharacter")
        {
            print("hit");
            Tramplines.Play("Idle");

        }
    }
}
