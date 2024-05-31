using System.Collections;
using System.Collections.Generic;
using ClearSky;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public GameObject MonsterPrefabs;
    private SimplePlayerController playerController;
    private int standard = 20;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            playerController = player.GetComponent<SimplePlayerController>();
        }
    }
    void Update()
    {
        SpawnMonster();
    }

    public void SpawnMonster()
    {
        if (playerController != null && playerController.score >= standard)
        {
            GameObject monster = Instantiate(MonsterPrefabs, transform);
            monster.transform.position = new Vector3(Random.Range(-9f, 9f), -13f, 0f);
            standard += 5; // Increment the standard after spawning the monster
        }
    }
}
