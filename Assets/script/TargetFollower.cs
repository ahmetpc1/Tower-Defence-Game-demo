using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class TargetFollower : MonoBehaviour
{
    //Ballista prefab has 2 part and we only want the move the top part
    Transform TargetTransform;
    [SerializeField] ParticleSystem shootParticle;
    [SerializeField] float range = 15f;
    
    
    void Update()
    {
        FindEnemy();
        LookAtTarget();
    }

    private void LookAtTarget()
    {

        float targetDistance = Vector3.Distance(transform.position,TargetTransform.position);
        transform.LookAt(TargetTransform);

        if (targetDistance <= range)
        {
            Attack(true);

        } else { Attack(false); }
    }
   void  FindEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        float maxDistance = Mathf.Infinity;
        Transform closestTarget=null;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(this.transform.position , enemy.transform.position);
            if(maxDistance > targetDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
              
            }
        }
        TargetTransform = closestTarget;
    }

    void Attack(bool inRange)
    {

        var emissionOfParticle = shootParticle.emission;
        emissionOfParticle.enabled = inRange;
                    
        
    }
}
