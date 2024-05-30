using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeController : MonoBehaviour
{

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D coll){
    if(coll.gameObject.tag == "Player"){
      this.gameObject.GetComponent<AudioSource>().Play();
      this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
      this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
  }
}
