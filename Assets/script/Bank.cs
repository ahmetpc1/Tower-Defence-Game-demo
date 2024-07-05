using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int maxGold=150;
    [SerializeField] int currentGold;
    [SerializeField] TMP_Text goldTxt;

    public int CurrentGold {  get { return currentGold; } }
    void Awake()
    {
        currentGold = maxGold;
        goldTxt.text = "Gold = " + currentGold.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Deposit(int reward)
    {
        currentGold += Mathf.Abs(reward);
        goldTxt.text = "Gold = " + currentGold.ToString();
        if (currentGold >= 2000)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

        }

    }

    public void Withdraw(int fine)
    {
        
       currentGold -= Mathf.Abs(fine);
       goldTxt.text = "Gold = " + currentGold.ToString();
        if (currentGold <0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
