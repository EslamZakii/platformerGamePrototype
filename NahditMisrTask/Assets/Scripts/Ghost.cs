using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
   
    [SerializeField] float powerTime;
  [SerializeField]  Transform firstPos;
    [SerializeField]Transform SecPos;
    [SerializeField] Transform Current;
        [SerializeField]Transform nextP;
    // Start is called before the first frame update
    void Start()
    {
       
        nextP = SecPos;

    }
    IEnumerator Coroutin()
    {
        if (gameObject.transform.position == firstPos.position)
        {
            nextP = SecPos;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (gameObject.transform.position == SecPos.position)
        {
            nextP = firstPos;

            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        yield return new WaitForSeconds(1f);
        
    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextP.position,Time.deltaTime*powerTime);

        StartCoroutine(Coroutin());


    }
}
