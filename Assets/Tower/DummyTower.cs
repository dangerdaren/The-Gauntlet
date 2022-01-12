using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DummyTower : MonoBehaviour
{
    Bank bank;
    Tower realTower;

    [SerializeField] Material ghostTowerMat;
    [SerializeField] Material readyTowerMat;

    private void Awake()
    {
        bank = FindObjectOfType<Bank>();
        realTower = FindObjectOfType<Tower>();
    }

    public void ChangeColor()
    {
        if (bank.CurrentBalance >= realTower.TowerCost)
        {
            foreach (Transform part in transform)
            {
                part.GetComponent<MeshRenderer>().material = readyTowerMat;
            }
        }
        else
        {
            foreach (Transform part in transform)
            {
                part.GetComponent<MeshRenderer>().material = ghostTowerMat;
            }
        }
    }

}
