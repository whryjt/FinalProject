using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoonsterController : MonoBehaviour
{
    int hp = 0;
    public int max_hp = 0;
    public GameObject hp_bar;
    public float speed;
    public float jumpForce;
    private Transform myTransform;
    public Transform playerTransform;
    public enum Status{idle,walk,attack,jump};
    public enum Face{Right,Left};
    public Status status;
    public Face face;
    private SpriteRenderer spr;
    private Rigidbody2D rb;
    private bool canJump = true; // 是否可以跳跃

    void Start()
    {
        max_hp = 20;
        hp = max_hp;
        status = Status.idle;
        spr = this.transform.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if(spr.flipX){
            face = Face.Right;
        }else{
            face = Face.Left;
        }
        myTransform = this.transform;
        if(GameObject.Find("Player") != null){
            playerTransform = GameObject.Find("Player").transform;
        }
    }
    void Update()
    {
        if(hp <= 0){
            Destroy(this.gameObject);
        }
        float _percentage = (float)hp/(float)max_hp;
        hp_bar.transform.localScale = new Vector3(_percentage,hp_bar.transform.localScale.y,hp_bar.transform.localScale.z);
        //update status condition
        float deltaTime = Time.deltaTime;
        switch(status){
            case Status.idle:
            if(playerTransform){
                if(Mathf.Abs(myTransform.position.x - playerTransform.position.x) < 50f){
                    status = Status.walk;
                }
            }
            break;
            case Status.walk:
            if(playerTransform){
                if(myTransform.position.x >= playerTransform.position.x){
                    spr.flipX = false;
                face = Face.Left;
            }else{
                spr.flipX = true;
                face = Face.Right;
            }
            }
            switch(face){
                case Face.Right:
                myTransform.position += new Vector3(speed * deltaTime,0,0);
                break;
                case Face.Left:
                myTransform.position -= new Vector3(speed * deltaTime,0,0);
                break;
            }
            if(playerTransform){
                if(Mathf.Abs(myTransform.position.x - playerTransform.position.x) >= 50f){
                    status = Status.idle;
                }
            }
            break;
        }
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded() && canJump)
        {
            Jump();
            canJump = false; // 跳跃后禁用跳跃功能
        }
    }
    void Jump()
    {
    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "fireball"){
            hp -= 1;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true; // 重新启用跳跃功能
        }
    }
}
