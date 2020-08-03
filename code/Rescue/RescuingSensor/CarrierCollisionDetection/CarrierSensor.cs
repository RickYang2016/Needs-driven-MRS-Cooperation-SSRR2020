using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierSensor : MonoBehaviour
{
    public List<Collider> agents = new List<Collider>();
    public List<CarrierCollisionSensorState> agentsInfo;
    public bool collisionSignal = false;
    public int collisionTime = 0;
    private CarrierCollisionSensorState agentState;

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
        agentState = agent.GetComponent<CarrierCollisionSensorState>();

        // update agent's state and entire agents' list information
        if(agent.tag == "Carrier")
        {
            collisionSignal = true;
            agents.Add(agent);
            agentsInfo.Add(agentState);
        }
    }

    private void OnTriggerExit(Collider agent)
    {
        agentState = agent.GetComponent<CarrierCollisionSensorState>();

        if(agent.tag == "Carrier")
        {
            agents.Remove(agent);
            agentsInfo.Remove(agentState);
            collisionSignal = false;
            collisionTime = 0;
            gameObject.GetComponentInParent<RescuerCarrier>().highPriority = false;
        }
    }
}
