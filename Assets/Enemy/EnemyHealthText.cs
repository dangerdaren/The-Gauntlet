using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]//this script will ALWAYS EXECUTE, both in-game and while editing!

[RequireComponent(typeof(TextMeshPro))]

public class EnemyHealthText : MonoBehaviour
{

    [SerializeField] GameObject placeholder;

    [SerializeField] Color healthyColor;
    [SerializeField] Color hurtColor;
    [SerializeField] Color limpingColor;
    [SerializeField] Color dyingColor;

    [SerializeField] EnemyHealth enemyHealth;
    TMP_Text enemyHealthText;


    private void Awake()
    {
        enemyHealthText = GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(placeholder.transform.position);
    }
       
    public void UpdateHealthText(float currentHP)
    {
        string newHP = currentHP.ToString();
        enemyHealthText.text = $"{newHP} HP";
    }

    public void ChangeTextColor(int percent) //todo still don't have this working for some reason
    {
        switch (percent)
        {
            case 75:
                enemyHealthText.color = healthyColor;
                break;
            case 50:
                enemyHealthText.color = hurtColor;
                break;
            case 25:
                enemyHealthText.color = limpingColor;
                break;
            case 1:
                enemyHealthText.color = dyingColor;
                break;
            default:
                enemyHealthText.color = Color.white;
                break;
        }


    }
}
