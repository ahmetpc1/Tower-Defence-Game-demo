using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    Bank bank;
    [SerializeField] int cost=50;

    
    public bool CreateTower(Tower tower, Vector3 V3position)
    {
        bank = FindObjectOfType<Bank>();

        if (bank == null) { Debug.Log("1"); return false;  }

        if (bank.CurrentGold >= cost) { Debug.Log("2");
        Instantiate(tower.gameObject, V3position, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
            
        Debug.Log("3");
        return false;
    }
}
