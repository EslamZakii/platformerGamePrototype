using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class Move : MonoBehaviour
{ public Vector2 jmpforce;
    public Button jmpBtn;
  public  Joystick joystk;
   public Animator PlayerAnim;
   public Rigidbody2D Rg;
    Vector3 Ppostion;
   [SerializeField] float speed;
    [SerializeField] bool isJump;
    [SerializeField] bool isRun;
    [SerializeField] bool isGround;
    //Climb Var
    public float distance;
    public bool isClimbing;
    public LayerMask ladder;
    //trampoline
    [SerializeField] float powerX;
    [SerializeField] GameObject Win;

    void Start()
    {
        jmpBtn = GameObject.FindGameObjectWithTag("JumpBtn").GetComponent<Button>();
        joystk = FindObjectOfType<Joystick>();
        PlayerAnim = gameObject.GetComponent<Animator>();
        Rg = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance,ladder);
        if (hitinfo.collider!=null)
        {
            //function
            isClimbing = true;
        }
        else
        {
            isClimbing = false;
        }
        if (isClimbing == true)
        {
            transform.position = Ppostion + gameObject.transform.position;
            Ppostion = new Vector2(joystk.Horizontal * speed * Time.deltaTime, joystk.Vertical * speed * Time.deltaTime);
            Rg.gravityScale = 0;
            PlayerAnim.Play("LadderClimb");
        }
        else
        {
            Rg.gravityScale = 1;
        }
    }
    void Update()
    {

        
        if (PlayerAnim.GetBool("isGround") == false)
        {
            Ppostion = new Vector3(joystk.Horizontal * speed * Time.deltaTime, 0, 0);
            transform.position = Ppostion + gameObject.transform.position;
        }

        PlayerAnim.SetFloat("Speed", joystk.Horizontal);
        if (joystk.Horizontal>0 && PlayerAnim.GetBool("isGround") == true && isClimbing == false)
        {
            PlayerAnim.Play("Run");
           
            transform.position = Ppostion + gameObject.transform.position;
            Ppostion = new Vector2(joystk.Horizontal * speed * Time.deltaTime, 0);

            transform.rotation = new Quaternion(0, 0, 0, 0);
            
           
        }
        else if(joystk.Horizontal < 0 && PlayerAnim.GetBool("isGround") == true && isClimbing == false)
        {
            PlayerAnim.Play("Run");
            Ppostion = new Vector3(joystk.Horizontal * speed * Time.deltaTime, 0,0);
            transform.position = Ppostion+gameObject.transform.position;

            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (joystk.Horizontal==0&&PlayerAnim.GetBool("isGround")==true&&isClimbing==false)
        {
            PlayerAnim.Play("Idle");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Finish")
        {
            Win.gameObject.SetActive(true);
        }
        if (collision.collider.tag == "Ground"|| collision.collider.tag == "Mplatform")
        {
            isGround = true;
            PlayerAnim.SetBool("isGround", isGround);
            
        }
        if (collision.collider.tag=="Mplatform")
        {
            gameObject.transform.SetParent(collision.collider.transform);
        }
        else
        {
            gameObject.transform.SetParent(null);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Trampline")
        {
            Rg.AddForce(new Vector2(0, powerX));
        }
    }

    public void checkledgeClimb()
    {

    }
    public void jump()
    {
        if (jmpBtn.isActiveAndEnabled)
        {
            if (isGround== true)
            {
               
                PlayerAnim.Play("Jump");
                Rg.AddForce(jmpforce);
                print("ok");
                isGround = false;
                PlayerAnim.SetBool("isGround", isGround);
            }
           
        }
    }
}
