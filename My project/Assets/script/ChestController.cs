using UnityEngine;

public class ChestController : MonoBehaviour
{
    public enum ChestType
    {
        Gold,
        Silver,
        Bronze,
        Iron
    }

    public ChestType chestType;
    private bool isOpened = false;
    private equipmentManager equipment;
    private void Start(){
        GameObject item = GameObject.Find("itemManager");
          if(item != null){
            equipment = item.GetComponent<equipmentManager>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            float abilityValue = 0f;
            switch (chestType)
            {
                case ChestType.Gold:
                    abilityValue = 50f;
                    break;
                case ChestType.Silver:
                    abilityValue = 30f;
                    break;
                case ChestType.Bronze:
                    abilityValue = 10f;
                    break;
                case ChestType.Iron:
                    abilityValue = 5f;
                    break;
                default:
                    abilityValue = 0f;
                    break;
            }
            Vector3 chestPosition = transform.position;

            equipment.GenerateItem(chestPosition);

            // 傳遞能力值給玩家
            玩家數值控制 playerStats = other.GetComponent<玩家數值控制>();
            if (playerStats != null)
            {
                playerStats.IncreaseAbility(abilityValue);
            }

            // 設置寶箱為已打開狀態
            isOpened = true;
        }
    }
}
