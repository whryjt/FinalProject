using System.Collections;
using System.Collections.Generic;
using ClearSky;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public float MoveSpeed;
    private int standard = 10;
    private SimplePlayerController playerController;
    private FloorManager floorManager;
    void Start(){
        GameObject player = GameObject.Find("Player");
        if(player != null){
            playerController = player.GetComponent<SimplePlayerController>();
        }
        floorManager = transform.parent.GetComponent<FloorManager>();
    }

    void Update()
    {
    // 移动地板
    transform.Translate(0, MoveSpeed * Time.deltaTime, 0);
    if (transform.position.y > 12f)
    {
        Destroy(this.gameObject);
        floorManager.SpawnFloor();
    }

    // 确保 playerController 不为空再访问 score
    if (playerController != null && playerController.score >= standard)
    {
        MoveSpeed += 1;
        standard += 10;
    }

    // 限制 MoveSpeed 的最大值
    if (MoveSpeed > 10)
    {
        MoveSpeed = 10;
    }
    } 

}
