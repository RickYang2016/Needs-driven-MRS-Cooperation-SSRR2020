using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Linq;
using System;

public class RescuerCarrier : MonoBehaviour
{
    private Rigidbody rigidBody;
    private List<GameObject> items = new List<GameObject>();
    private Vector3 goal;
    private Vector3 initial;
    private Vector3 agentOldPos;
    private Vector3 agentNewPos;
    private string ID;
    private float step;
    private float degree;
    private float xFactor;
    private float zFactor;
    private int itemsCount = 0;
    private int times = 0;
    private bool getToTheGoal = false;
    private bool getToTheSafety = false;
    private Dictionary<string, float> sortedCollisionDic;
    public int time = 0;
    public int rescuedAmount = 0;
    public float currentAgentEnergy;
    public bool highPriority = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        ID = gameObject.name;
        currentAgentEnergy = 100f;
        degree = 10f;
        xFactor = 1;
        zFactor = 2;
        initial = GetSafetyPos(ID);
        goal = GetGoalPos(ID);
    }

    // Update is called once per frame
    void Update()
    {
        time++;
        agentNewPos = gameObject.transform.position;

        if(time <= 3000)
        {
            step = 10.0f * Time.deltaTime;
        }
        else
        {
            step = 0.0f;
        }

        try
        {
            if(!gameObject.GetComponentInChildren<CarrierSensor>().collisionSignal || highPriority) // satisfy the safety needs without collision
            {
                if(!getToTheGoal)
                {
                    if(getToTheSafety) // get the enough rescued items in safe place and release, then keep on rescuing...
                    {
                        // lay down objects
                        layDownItems();
                    }

                    gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, goal, step);
                    adaptMovingDirection(gameObject.transform.localPosition, goal);
                }
                else if(getToTheGoal && itemsCount < 5) // get to the goal point start to circle the rescuing area
                {
                    gameObject.transform.Translate(xFactor * Time.deltaTime, 0, zFactor * Time.deltaTime);
                    gameObject.transform.RotateAround(goal, Vector3.up,  degree * Time.deltaTime);
                    searchingItemsDirection(gameObject.transform.localPosition, goal);
                }
                else if(itemsCount == 5) // get the enough rescued items and back to the initial point
                {
                    gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, initial, step);
                    adaptMovingDirection(gameObject.transform.localPosition, initial);
                }
            }
            else
            {
                aovidingCollisionPlan();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        // calculate current energy
        currentAgentEnergy = currentAgentEnergy - Vector3.Distance(agentNewPos, agentOldPos) * 0.015f;
        agentOldPos = agentNewPos;
    }

    private Vector3 GetSafetyPos(string ID)
    {
        float tmp = 0;
        Vector3 safetyPos = new Vector3();

        string tmps = Regex.Replace(ID, "[a-z]", "", RegexOptions.IgnoreCase);
        float.TryParse(tmps, out tmp);

        safetyPos = new Vector3(tmp * 10 - 10f, 1.5f, tmp * 10 -500f);

        return safetyPos;
    }

    private Vector3 GetGoalPos(string ID)
    {
        float tmp = 0;
        Vector3 goalPos = new Vector3();

        string tmps = Regex.Replace(ID, "[a-z]", "", RegexOptions.IgnoreCase);
        float.TryParse(tmps, out tmp);

        goalPos = new Vector3(tmp * 5, 1.5f, 200f);

        return goalPos;
    }

    // adjust agent's body to face the moving goal position
    private void adaptMovingDirection(Vector3 currentPos, Vector3 goalPoint)
    {
        Vector3 forwardDir = Quaternion.Euler(0f, 90f, 0f) * (goalPoint - currentPos);

        Quaternion lookRot = Quaternion.LookRotation(forwardDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(step));
    }

    // direction of agent's searching items
    private void searchingItemsDirection(Vector3 currentPos, Vector3 goalPoint)
    {
        Vector3 forwardDir = goalPoint - currentPos;

        Quaternion lookRot = Quaternion.LookRotation(forwardDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(step));
        
    }

    // grab items
    private void OnTriggerEnter(Collider agent)
    {
        // grab items less or equal to ten
        if(agent.tag == "RescuedItems" && itemsCount < 5 && getToTheGoal == true)
        {
            agent.gameObject.SetActive(false);
            agent.gameObject.tag = "getRescuedItems";

            if(!items.Contains(agent.gameObject))
            {
                items.Add(agent.gameObject);
                itemsCount++;
                rescuedAmount++;
            }
        }

        // get to the goal point
        if(agent.tag == "GoalPoint")
        {
            getToTheGoal = true;
            times++;
        }

        // get to the safety place
        if(agent.tag == "SafetyPlace")
        {
            getToTheSafety = true;
            getToTheGoal = false;
        }
    }

    private void OnTriggerExit(Collider agent)
    {
        if(agent.tag == "SafetyPlace")
        {
            getToTheSafety = false;
        }
    }

    // lay down objects
    private void layDownItems()
    {
        int i = 0;

        foreach(var item in items)
        {
            item.GetComponent<Transform>().position = gameObject.GetComponent<Transform>().position + new Vector3(3f * i, 0f, 3f * times);
            item.gameObject.SetActive(true);
            item.GetComponent<Rigidbody>().useGravity = true;
            i++;
        }

        items.Clear();
        itemsCount = 0;
    }

    private Dictionary<string, float> Sort(Dictionary<string, float> infoDic)
    {
        int tmp;
        Dictionary<int, float> tmpDic = new Dictionary<int, float>();
        Dictionary<string, float> infoDicSort = new Dictionary<string, float>();

        foreach(var item in infoDic)
        {
            string tmps = Regex.Replace(item.Key, "[a-z]", "", RegexOptions.IgnoreCase);
            int.TryParse(tmps, out tmp);
            tmpDic.Add(tmp, item.Value);
        }

        Dictionary<int, float> tmpinfoDicSort = tmpDic.OrderBy(o => o.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);

        foreach(var item in tmpinfoDicSort)
        {
            string temp = Convert.ToString(item.Key);
            temp = temp.Insert(0, "carrier");
            infoDicSort.Add(temp, item.Value);
        }

        return infoDicSort;
    }

    private void aovidingCollisionPlan()
    {
        sortedCollisionDic = new Dictionary<string, float>();

        Dictionary<string, float> tmpColList = new Dictionary<string, float>();

        foreach(var item in gameObject.GetComponentInChildren<CarrierCollisionDetection>().CollisionList)
        {
            tmpColList.Add(item.ID, item.agentEnergy);
        }

        sortedCollisionDic = Sort(tmpColList);

        if(sortedCollisionDic.Keys.First() != gameObject.name)
        {
            if(gameObject.GetComponentInChildren<CarrierSensor>().collisionTime <= 15)
            {
                step = 0.0f;
            }
        }
        else
        {
            highPriority = true;
        }
    }
}
