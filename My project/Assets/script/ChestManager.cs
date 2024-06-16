using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] GameObject[] ChestPrefabs;

    // Update is called once per frame
    public void SpawnChest(Vector3 position){
    int r = Random.Range(0,ChestPrefabs.Length);
    Vector3 chestPosition = position + new Vector3(0f, 1f, 0f); // 调整 Y 轴上的位置，使宝箱在地板上方
    GameObject chest = Instantiate(ChestPrefabs[r], chestPosition, Quaternion.identity);
   }
}
