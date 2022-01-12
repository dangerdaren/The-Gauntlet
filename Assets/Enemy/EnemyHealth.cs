using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] EnemyHealthText enemyHealthText;
    [SerializeField] int startingHP = 1;

    [Tooltip("Adds amount to Max Hit Points when Enemy dies.")]
    [SerializeField] int difficultyRamp = 2;

    float threeFourthHP;
    float oneHalfHP;
    float oneFourthHP;

    public int percent;

    AudioPlayer audioPlayer;

    int currentHitPoints;
    public int CurrentHitPoints { get { return currentHitPoints; } }

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = startingHP;
        enemyHealthText.UpdateHealthText(startingHP);
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        audioPlayer = FindObjectOfType<AudioPlayer>();

    }

    private void OnParticleCollision(GameObject other)
    {
        audioPlayer.PlayEnemyHurt();
        ProcessHit();
        CalculatePercentageHP();
        enemyHealthText.UpdateHealthText(currentHitPoints);
        //enemyHealthText.ChangeTextColor(percent);
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            audioPlayer.PlayEnemyDown();
            enemy.DropGold();
            startingHP += difficultyRamp;
            gameObject.SetActive(false);
        }
    }

    private void CalculatePercentageHP() //todo Something is wrong in my If Statement. Can't get it to work.
    {
        threeFourthHP = (currentHitPoints * .75f);
        oneHalfHP = (currentHitPoints * .5f);
        oneFourthHP = (currentHitPoints * .25f);

        if (currentHitPoints >= threeFourthHP)
        {
            percent = 75;
            Debug.Log("Healthy");
        }
        else if (currentHitPoints <= threeFourthHP && currentHitPoints >= oneHalfHP)
        {
            percent = 50;
            Debug.Log("Hurting");
        }
        else if (currentHitPoints <= oneHalfHP && currentHitPoints >= oneFourthHP)
        {
            percent = 25;
            Debug.Log("Limping");
        }
        else if (currentHitPoints <= oneFourthHP)
        {
            percent = 1;
            Debug.Log("Dying");
            }
        else
        {
            percent = 0;
            Debug.Log("Broken");
        }
    }

}
