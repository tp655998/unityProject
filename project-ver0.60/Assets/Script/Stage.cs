using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Stage : MonoBehaviour
{
    public Flowchart StageFlowchart;
    public string stage;
    public static bool near = false;
    public static Flowchart FlowchartManager;
    void Start()
    {
        StageFlowchart=GameObject.Find("StageFlowchart").GetComponent<Flowchart>();
    }
    void Awake()
    {
        FlowchartManager = GameObject.Find("FlowchartManager").GetComponent<Flowchart>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FlowchartManager.GetBooleanVariable("isTalking") == true)
        {
            Player_Status.isTalking = true;
        }
        else
        {
            Player_Status.isTalking = false;
        }

    }
    public static bool isTalking
    {
        get { return FlowchartManager.GetBooleanVariable("isTalking"); }
    }
    private void OnTriggerStay(Collider other)
    {

        near = true;

        Block targetBlock = StageFlowchart.FindBlock(stage);
        StageFlowchart.ExecuteBlock(targetBlock);


    }
    private void OnTriggerExit(Collider other)
    {
        near = false;
    }
}
