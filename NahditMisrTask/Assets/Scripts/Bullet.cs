using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] float power;
    void Update()
    {
        gameObject.transform.position += Vector3.right * power * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}
