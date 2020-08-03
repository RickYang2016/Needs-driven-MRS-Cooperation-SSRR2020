using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSensorState : MonoBehaviour
{
    public string ID;
    public float agentEnergy;
    public Vector3 agentPos;
    
    // Start is called before the first frame update
    void Start()
    {
        ID = gameObject.GetComponentInParent<RescuerObserver>().name;
    }

    // Update is called once per frame
    void Update()
    {
        agentEnergy = gameObject.GetComponentInParent<RescuerObserver>().currentAgentEnergy;
        agentPos = gameObject.GetComponentInParent<RescuerObserver>().transform.position;
    }
}
