using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class fireballController : MonoBehaviour
{
    public float timer = 0;
    public float speed = 0;
    public bool Right = true;
    public SpriteRenderer spr;
    void Start()
    {
        speed = 0.5f;
        timer = 2;
        spr = this.gameObject.GetComponent<SpriteRenderer>();
        if(!Right){
            spr.flipX = true;
        }
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(50*speed,0),ForceMode2D.Impulse);
    }

    void Update()
    {
        if(Right){
            this.gameObject.transform.position += new Vector3(speed*Time.deltaTime*60,0,0);
        }else{
             this.gameObject.transform.position -= new Vector3(speed*Time.deltaTime*60,0,0);
        }
        timer -= Time.deltaTime;
        if(timer <= 0){
            Destroy(this.gameObject);
        }
    }
}
