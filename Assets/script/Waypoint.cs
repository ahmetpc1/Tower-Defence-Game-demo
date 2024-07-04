using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower tower;
    public bool IsPlaceable {  get { return isPlaceable; } }
     


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    void OnMouseDown()
     {
        if (isPlaceable)
        {
           
           bool isPlaced =  tower.CreateTower(tower,transform.position);
            isPlaceable = !isPlaced;
        }   
     }
}
