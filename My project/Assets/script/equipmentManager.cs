using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipmentManager : MonoBehaviour
{
    [SerializeField] GameObject[] itemPrefabs;
    
    public void GenerateItem(Vector3 chestPosition){
        int RandomIndex = Random.Range(0,itemPrefabs.Length);
        GameObject selectItem = itemPrefabs[RandomIndex];

        Vector3 spawnPosition = chestPosition + new Vector3(0,6,0);
        GameObject newItem = Instantiate(selectItem, spawnPosition, Quaternion.identity);

        StartCoroutine(DestroyAfterDelay(newItem,0.5f));
    }

    private IEnumerator DestroyAfterDelay(GameObject item,float delaySeconds){

        yield return new WaitForSeconds(delaySeconds);
        Destroy(item);
    }
}
