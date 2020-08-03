using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDection : MonoBehaviour
{
    public List<CollisionSensorState> CollisionList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetUnionList(gameObject.GetComponent<CollisionSensorState>());
    }

    private void GetUnionList(CollisionSensorState currentAgent)
    {
        Queue<CollisionSensorState> tmpQueue = new Queue<CollisionSensorState>();
        CollisionList = new List<CollisionSensorState>();

        tmpQueue.Enqueue(currentAgent);

        while(tmpQueue.Count > 0)
        {
            CollisionSensorState agent = tmpQueue.Dequeue();

            foreach(var item in agent.GetComponent<Sensor>().agentsInfo)
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
