using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int maxGold=150;
    [SerializeField] int currentGold;
    public int CurrentGold {  get { return currentGold; } }
    void Awake()
    {
        currentGold = maxGold;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deposit(int reward)
    {
        currentGold += Mathf.Abs(reward);
    }

    public void Withdraw(int fine)
    {
       currentGold -= Mathf.Abs(fine);
    }
}
