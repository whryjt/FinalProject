using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClearSky;
using System.ComponentModel.Design;
public class FloorManager : MonoBehaviour
{
    [SerializeField]GameObject[] FloorPrefabs;
    private SimplePlayerController playerController;
    private ChestManager ChestController;
    private int standard = 10;

    void Start(){
        GameObject player = GameObject.Find("Player");
        if(player != null){
            playerController = player.GetComponent<SimplePlayerController>();
        }
        GameObject Chest = GameObject.Find("ChestManager");
        if(Chest != null){
            ChestController = Chest.GetComponent<ChestManager>();
        }
    }
    public void SpawnFloor(){
    int r = Random.Range(0,FloorPrefabs.Length);
    GameObject floor = Instantiate(FloorPrefabs[r],transform);
    floor.transform.position = new Vector3(Random.Range(-9f,9f),-13f,0f);
    if (playerController != null && playerController.score == standard)
        {
            ChestController.SpawnChest(floor.transform.position);
            standard += 10;
        }
   }
}
