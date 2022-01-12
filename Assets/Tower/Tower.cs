using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int towerCost = 75;
    public int TowerCost { get { return towerCost; } }

    [SerializeField] float buildTime = 1f;
    [SerializeField] List<GameObject> towerParts = new List<GameObject>();

    //int towerNumber = 0;
    Dictionary<Vector3, GameObject> towers = new Dictionary<Vector3, GameObject>();

    bool beginFiring = false;
    public bool BeginFiring { get { return beginFiring; } }

    AudioPlayer audioPlayer;

    private void Awake()
    {

    }

    private void Start()
    {
        StartCoroutine(Build());
    }

    public bool BuildTower(Tower tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (bank.CurrentBalance >= towerCost)
        {

            towers[position] = Instantiate(tower.gameObject, position, Quaternion.identity);
            bank.Withdrawl(towerCost);

            return true;
        }

        return false; //if all else fails, don't let it happen.
    }

    public bool RemoveTower(GameObject tower, Vector3 position)
    {
        Bank bank = FindObjectOfType<Bank>();

        if (bank == null)
        {
            return false;
        }

        if (towers.ContainsKey(position))
        {

            GameObject thisTower = towers[position];


            towers.Remove(position);


            Destroy(thisTower);
            Debug.Log($"Destroyed tower at {position}");
        }

        bank.Deposit(towerCost - 25);

        return true;

    }


    IEnumerator Build()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);

            foreach(Transform grandchild in transform)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildTime);

            foreach (Transform grandchild in transform)
            {
                grandchild.gameObject.SetActive(true);
            }
        }

        beginFiring = true;
    
    }

}
