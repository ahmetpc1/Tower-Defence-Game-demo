using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward,goldPenalty;
    Bank bank;
    void Start()
    {
        goldPenalty = 25;
        goldReward = 25;
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoldRewardMethod()
    {
        if (bank == null)
        {
            return;
        }
        bank.Deposit(goldReward);

    }
    public void GoldPenaltyMethod()
    {
        if (bank == null)
        {
            return;
        }
        bank.Withdraw(goldPenalty);

    }
}
