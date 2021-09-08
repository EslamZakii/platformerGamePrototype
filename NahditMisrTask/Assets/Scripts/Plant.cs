using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField]LayerMask chara;
    [SerializeField] float distance;
    [SerializeField] Animator playnet;
    // Start is called before the first frame update
    RaycastHit2D hitinfo;
    void Start()
    {
        playnet = GetComponent<Animator>();
    }

    IEnumerator bulletwait()
    {
        hitinfo = Physics2D.Raycast(transform.position, Vector2.right, distance, chara);
        if (hitinfo.collider != null)
        {
            if (GameObject.FindGameObjectsWithTag("Bullets").Length<1)
            {
                Instantiate(bullet, GameObject.FindGameObjectWithTag("Muzzel").GetComponent<Transform>().position, Quaternion.identity);
                playnet.Play("Attack");

            }
            yield return new WaitForSeconds(1);
        }
        else
        {
            playnet.Play("Idle Anim");

        }



    }
    // Update is called once per frame
    void Update()
    {
        
        StartCoroutine(bulletwait());
        
    }
}
