using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 彈簧controller : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

  void OnTriggerEnter2D(Collider2D coll){
    if(coll.gameObject.tag == "Player"){
        anim.SetTrigger("touch");
    }
  }
}
