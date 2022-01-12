using System.Collections;
using UnityEngine;
using TMPro;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0, 50)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    [SerializeField] TMP_Text countDownText;

    int countDown;

    GameObject[] pool;

    void Awake()
    {

        PopulatePool();
    }

    void Start()
    {
        StartCoroutine(CountDown());
    }


    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }

    }

    private void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator CountDown()
    {
        countDownText.enabled = true;
        for (int i = 3; i > 0; i--)
        {
            countDown = i;
            countDownText.text = $"STARTING IN... {countDown}";
            yield return new WaitForSeconds(1);
        }
        countDownText.enabled = false;
        StartCoroutine(SpawnEnemy());
    }
}
