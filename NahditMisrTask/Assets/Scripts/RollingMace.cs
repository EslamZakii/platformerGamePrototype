using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMace : MonoBehaviour
{
    Quaternion T_0 = Quaternion.Euler(0, 0,-90);
    Quaternion T_1 = Quaternion.Euler(0, 0, 90);
    [SerializeField] float powerTime;
    public Quaternion Current_T;
    // Start is called before the first frame update
    void Start()
    {
        Current_T = T_0;
    }
    IEnumerator Coroutin()
    {
       transform.rotation = Quaternion.Lerp(T_1, Current_T,Mathf.Abs( Mathf.Sin(Time.time)));
        
        yield return new WaitForSeconds(.1f);
        
    }
    // Update is called once per frame
    void Update()
    {
        
      StartCoroutine(Coroutin());
    }
}
