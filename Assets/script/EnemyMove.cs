using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f, 5f)] int speed;
    Enemy enemy;


    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());

    }

    IEnumerator FollowPath()
    {
        
        foreach (Waypoint waypoint in path)
        {
           
            Vector3 startPos = transform.position;
            Vector3 endPos =waypoint.transform.position;
            float travelPercent=0f;

            transform.LookAt(endPos);

            while (travelPercent <=1f) 
            {
            travelPercent += Time.deltaTime*speed;
               
            transform.position = Vector3.Lerp(startPos, endPos, travelPercent);
           

            yield return new WaitForEndOfFrame();
            }
            
        }
        enemy.GoldPenaltyMethod();
        gameObject.SetActive(false);
        
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform) {
            path.Add(child.GetComponent<Waypoint>()); 
        
        }

    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;

    }
}
