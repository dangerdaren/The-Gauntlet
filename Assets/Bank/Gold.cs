using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    int gold = 0;
    TMP_Text goldText;
    //HighScore highScore;

    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<TMP_Text>();
        goldText.text = "Gold: ";

        //highScore = FindObjectOfType<HighScore>();
    }

    public void IncreaseGold(int toAdd)
    {
        gold += Mathf.Abs(toAdd);
        goldText.text = ($"Gold: {gold}");
    }

    public void DecreaseGold(int toSubtract)
    {
        gold -= Mathf.Abs(toSubtract);
        goldText.text = ($"Gold: {gold}");
    }



}
