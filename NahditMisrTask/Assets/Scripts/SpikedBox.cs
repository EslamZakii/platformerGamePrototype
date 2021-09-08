using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBox : MonoBehaviour
{
   
    [SerializeField] float powerTime;
    public Quaternion Current_T;
  [SerializeField]  Transform firstPos;
    [SerializeField]Transform SecPos;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    IEnumerator Coroutin()
    {
        transform.position = new Vector2( Mathf.Lerp(firstPos.position.x, SecPos.position.x, Mathf.Sin(Time.time)),this.transform.position.y);
        yield return new WaitForSeconds(.1f);
        
    }
    // Update is called once per frame
    void Update()
    {
        
      StartCoroutine(Coroutin());
    }
}
