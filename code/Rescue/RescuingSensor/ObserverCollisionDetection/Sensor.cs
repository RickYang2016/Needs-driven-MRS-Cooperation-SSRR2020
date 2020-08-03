using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public List<Collider> agents = new List<Collider>();
    public List<CollisionSensorState> agentsInfo;
    public bool collisionSignal = false;
    public int collisionTime = 0;
    private CollisionSensorState agentState;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(collisionSignal)
        {
            collisionTime++;
        }
    }

    private void OnTriggerEnter(Collider agent)
    {
        agentState = agent.GetComponent<CollisionSensorState>();

        // update agent's state and entire agents' list information
        if(agent.tag == "Observer")
        {
            collisionSignal = true;
            agents.Add(agent);
            agentsInfo.Add(agentState);
        }
    }

    private void OnTriggerExit(Collider agent)
    {
        agentState = agent.GetComponent<CollisionSensorState>();

        if(agent.tag == "Observer")
        {
            agents.Remove(agent);
            agentsInfo.Remove(agentState);
            collisionSignal = false;
            collisionTime = 0;
            gameObject.GetComponentInParent<RescuerObserver>().highPriority = false;
        }
    }
}