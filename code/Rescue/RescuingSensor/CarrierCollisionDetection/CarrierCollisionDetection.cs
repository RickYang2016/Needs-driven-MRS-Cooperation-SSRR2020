using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierCollisionDetection : MonoBehaviour
{
    public List<CarrierCollisionSensorState> CollisionList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetUnionList(gameObject.GetComponent<CarrierCollisionSensorState>());
    }

    private void GetUnionList(CarrierCollisionSensorState currentAgent)
    {
        Queue<CarrierCollisionSensorState> tmpQueue = new Queue<CarrierCollisionSensorState>();
        CollisionList = new List<CarrierCollisionSensorState>();

        tmpQueue.Enqueue(currentAgent);

        while(tmpQueue.Count > 0)
        {
            CarrierCollisionSensorState agent = tmpQueue.Dequeue();

            foreach(var item in agent.GetComponent<CarrierSensor>().agentsInfo)
            {                
                if(!CollisionList.Contains(item))
                {
                    CollisionList.Add(item);
                    tmpQueue.Enqueue(item);
                }
            }
        }
    }
}
