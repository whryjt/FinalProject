using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClearSky;

public class AnimationBackground : MonoBehaviour
{
    private Material material;
    private Vector2 movement;
    public Vector2 speed;
    private SimplePlayerController playerController;
    private int standard = 10;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if(player != null){
            playerController = player.GetComponent<SimplePlayerController>();
        }
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement += speed * Time.deltaTime;

        if (playerController != null && playerController.score >= standard)
        {
            speed.y -= 0.2f * Time.deltaTime; // 使用 Time.deltaTime 确保平滑减速
            standard += 10;
        }

        if (material != null)
        {
            material.mainTextureOffset = movement;
        }
    }
}
