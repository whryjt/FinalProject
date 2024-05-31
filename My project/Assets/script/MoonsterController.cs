using System.Collections;
using System.Collections.Generic;
using ClearSky;
using Unity.VisualScripting;
using UnityEngine;

public class MoonsterController : MonoBehaviour
{
    public float MoveYSpeed;
    private int standard = 10;
    private SimplePlayerController playerController;
    public float speed;
    private Transform myTransform;
    public Transform playerTransform;
    public enum Status{idle,walk,attack};
    public enum Face{Right,Left};
    public Status status;
    public Face face;
    private SpriteRenderer spr;
    private Rigidbody2D rb;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if(player != null){
            playerController = player.GetComponent<SimplePlayerController>();
        }
        status = Status.idle;
        spr = this.transform.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if(spr.flipX){
            face = Face.Right;
        }else{
            face = Face.Left;
        }
        myTransform = this.transform;
        if(player != null){
            playerTransform = player.transform;
        }
    }
    void Update()
    {
        //移動Y方向的怪物
        transform.Translate(0,MoveYSpeed * Time.deltaTime,0);

        //重新產生怪物
        if (transform.position.y > 12f){
        Destroy(this.gameObject);
        }

        //update status condition
        float deltaTime = Time.deltaTime;
        switch(status){
            case Status.idle:
            if(playerTransform){
                if(Mathf.Abs(myTransform.position.x - playerTransform.position.x) < 10f){
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
                if(Mathf.Abs(myTransform.position.x - playerTransform.position.x) >= 10f){
                    status = Status.idle;
                }
            }
            break;
        }
        //加快上升速度
         if (playerController != null && playerController.score >= standard)
        {
        MoveYSpeed += 1;
        standard += 10;
        }

        // 限制 MoveSpeed 的最大值
        if (MoveYSpeed > 10)
        {
        MoveYSpeed = 10;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "fireball"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
