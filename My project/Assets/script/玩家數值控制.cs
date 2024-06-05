using System.Collections;
using System.Collections.Generic;
using TMPro; // 引入 TextMeshPro 的命名空間
using UnityEngine;

public class 玩家數值控制 : MonoBehaviour
{
    private float ability = 0f; // 玩家的能力值
    private string rank = "答應"; // 玩家的等級，初始等級為 答應

    // 私有變量，用於存儲 TextMeshPro Text 元件
    private TMP_Text playerAbilityText;
    private TMP_Text playerRankText;

    void Start()
    {
        // 在 Start 方法中查找並設置 TextMeshPro Text 元件
        GameObject playerAbilityGO = GameObject.Find("PlayerAbility");
        if (playerAbilityGO != null)
            playerAbilityText = playerAbilityGO.GetComponent<TMP_Text>();

        GameObject playerRankGO = GameObject.Find("PlayerRank");
        if (playerRankGO != null)
            playerRankText = playerRankGO.GetComponent<TMP_Text>();

        UpdateUI(); // 初始化 UI 顯示
    }

    // 更新玩家的 UI
    void UpdateUI()
    {
        // 如果 TextMeshPro Text 元件已經找到，則更新顯示
        if (playerAbilityText != null)
            playerAbilityText.text = "Ability: " + ability.ToString();

        if (playerRankText != null)
            playerRankText.text = "Rank: " + rank;
    }

    // 增加玩家的能力值
    public void IncreaseAbility(float value)
    {
        ability += value;
        // 根據能力值更新玩家的等級
        UpdateRank();
        UpdateUI(); // 更新 UI 顯示
    }

    // 根據能力值更新玩家的等級
    void UpdateRank()
    {
        if (ability >= 100f)
            rank = "皇后";
        else if (ability >= 80f)
            rank = "貴妃";
        else if (ability >= 60f)
            rank = "妃";
        else if (ability >= 40f)
            rank = "嬪";
        else if (ability >= 20f)
            rank = "貴人";
        else
            rank = "答應";
    }
}