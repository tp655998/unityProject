using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class talk : MonoBehaviour
{
    public Flowchart talkFlowchart;
    public string NPC;
    public static bool near = false;
    public static Flowchart FlowchartManager;
    // Start is called before the first frame update
    void Start()
    {
     
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
        if (Input.GetKeyDown(KeyCode.F))
        {                  
            Block targetBlock = talkFlowchart.FindBlock(NPC);
            talkFlowchart.ExecuteBlock(targetBlock);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        near = false;
    }
}
