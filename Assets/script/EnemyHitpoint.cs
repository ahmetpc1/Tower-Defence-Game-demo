using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitpoint : MonoBehaviour
{
    [SerializeField] int hitpoint,currentHitpoint;
    Enemy enemy;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        currentHitpoint = hitpoint;
    }
    void OnParticleCollision(GameObject other)
    {
        currentHitpoint--;
        if(currentHitpoint<= 0) 
        {
            enemy.GoldRewardMethod();
            gameObject.SetActive(false);
            hitpoint++;
        }
    }
}
