using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierCollisionSensorState : MonoBehaviour
{
    public string ID;
    public float agentEnergy;
    public Vector3 agentPos;

    // Start is called before the first frame update
    void Start()
    {
        ID = gameObject.GetComponentInParent<RescuerCarrier>().name;
    }

    // Update is called once per frame
    void Update()
    {
        agentEnergy = gameObject.GetComponentInParent<RescuerCarrier>().currentAgentEnergy;
        agentPos = gameObject.GetComponentInParent<RescuerCarrier>().transform.position;
    }
}
