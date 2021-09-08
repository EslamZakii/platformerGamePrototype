using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
  public  GameManger GM;
  [SerializeField]  float time;
    public const int collected = 1;
    void Start()
    {
        GM = FindObjectOfType<GameManger>();
    }
    private void OnTriggerEnter2D(Collider2D knight)
    {
        if (knight.tag=="MainCharacter")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled= false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("Spark").GetComponent<Animator>().Play("Collected Anim");
            if (gameObject.tag=="CollectableApple")
            {
                print("ayyyy");
                GM.Apple += 1 ;
                GM.Score += 10;
            }
            if (gameObject.tag== "Collectables")
            {
                GM.Melon += 1;
                GM.Score += 15;

            }
            Invoke("destroyall", time);
        }
    }
    private void destroyall()
    {
        Destroy(gameObject);
    }
}
