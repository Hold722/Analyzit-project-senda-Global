using TMPro;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public TMP_Text goldText;

    private int gold = 0;

    void Start()
    {
        goldText.text = gold.ToString();
    }

    public void AddGoldSystem(int amount)
    {
        gold += amount;

        goldText.text = gold.ToString();
    }
}