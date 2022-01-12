using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int rewardAmount = 25;
    [SerializeField] int stealAmount = 25;

    Bank bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    //with the return as void, it's like not getting a reciept from the bank. Return bool otherwise?
    public void DropGold()
    {
        if(bank == null) { return; }
        bank.Deposit(rewardAmount);
    }

    public void StealGold()
    {
        if (bank == null) { return; }
        bank.Withdrawl(stealAmount);
    }
}
