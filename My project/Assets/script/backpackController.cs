using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.UI;
public class backpackController : MonoBehaviour
{
     // 道具結構體
    [System.Serializable]
    public struct Item
    {
        public string itemName;
        public Sprite itemIcon; // 道具圖標
    }

    // 設定三個道具
    public Item[] items = new Item[3];
    public GameObject backpackPanel; // 背包面板
    public GameObject itemSlotPrefab; // 用於顯示道具的預製體
    public Transform itemSlotContainer; // 道具槽容器
    public Button backpackButton; // 背包按鈕

    private void Start()
    {
        // 初始化背包面板為不可見
        backpackPanel.SetActive(false);

        // 初始化道具
        items[0].itemName = "妒芳紅";
        items[1].itemName = "紅麝粉";
        items[2].itemName = "牽機藥";
        // 添加按鈕點擊事件
        backpackButton.onClick.AddListener(ToggleBackpack);
    }

    // 切換背包面板的可見性
    public void ToggleBackpack()
    {
        backpackPanel.SetActive(!backpackPanel.activeSelf);

        if (backpackPanel.activeSelf)
        {
            // 更新背包面板內容
            UpdateBackpack();
        }
    }

    // 更新背包面板內容
    void UpdateBackpack()
    {
        // 清空舊的道具槽
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        // 添加新的道具槽
        foreach (Item item in items)
        {
            GameObject itemSlot = Instantiate(itemSlotPrefab, itemSlotContainer);
            itemSlot.GetComponentInChildren<Text>().text = item.itemName;
            if (item.itemIcon != null)
            {
                itemSlot.GetComponentsInChildren<Image>()[1].sprite = item.itemIcon; // 假設第二個Image是圖標
            }
        }
    }
}
