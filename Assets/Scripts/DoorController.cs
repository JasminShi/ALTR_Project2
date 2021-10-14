using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    //check each action's completion status
    private bool step1Start = false;
    private bool step1Complete = false;
    private bool step2Complete = false;
    private bool step3Complete = false;
    private bool step4Complete = false;

    //get script from the light objects
    //https://www.codegrepper.com/code-examples/csharp/call+script+in+another+script+unity
    public ColorController light1Script;
    public ColorController light2Script;
    public ColorController light3Script;
    public ColorController light4Script;

    //color scripts for the cabinet doors
    public ColorControllerRed color1Script;
    public ColorControllerYellow color2Script;
    public ColorControllerGreen color3Script;
    public ColorControllerBlue color4Script;

    //reference to the checkCollision script
    public checkPotCollision plantPot;
    public checkAshCollision ashPot;
    public checkSeedCollision seedPot;
    public checkWaterCollision waterPot;

    public OpenDoor doorTrigger;


    //need to define the bool before assigning value to it
    //pick the pot first
    public bool potPick;
    public bool potExit;

    //ash second
    public bool ashPick;
    public bool ashExit;

    //seed third
    public bool seedPick;
    public bool seedExit;

    //last water bottle
    public bool waterPick;
    public bool waterExit;
  


    private void Start()
    {
        //step1 automatically starts(light flashing and check action1)
        Step1Start();
        //get bool from checkCollision script
        //checkCollision checkCol = GameObject.Find("waterBottle").GetComponent<checkCollision>();
        //waterBottle.GetComponent<checkCollision>();      
    }

    private void Update()
    {
        //get the reference value
        potPick = plantPot.potPicked;
        potExit = plantPot.potOut;

        ashPick = ashPot.ashPicked;
        ashExit = ashPot.ashOut;

        seedPick = seedPot.seedPicked;
        seedExit = seedPot.seedOut;

        waterPick = waterPot.waterPicked;
        waterExit = waterPot.waterOut;

        if(step1Start == true)
        {
            checkAction1();
        }

        if (step1Complete)
        {
            //make light1 constant and make light2 flash
            light1Script.StopFlashing();
            color1Script.StopFlashing();
            light2Script.Flash();
            color2Script.Flash();
            Debug.Log("step1complete!");
            //check action2
            checkAction2();
            //make sure it only run once
            step1Complete = false;
        }

        if (step2Complete)
        {
            //make light2 constant and make light3 flash
            light2Script.StopFlashing();
            color2Script.StopFlashing();
            light3Script.Flash();
            color3Script.Flash();
            Debug.Log("step2complete!");
            //check action3
            checkAction3();
            step2Complete = false;
        }

        if (step3Complete)
        {
            //make light3 constant and make light4 flash
            light3Script.StopFlashing();
            color3Script.StopFlashing();
            light4Script.Flash();
            color4Script.Flash();
            Debug.Log("step3complete!");
            //check action4
            checkAction4();
            step3Complete = true;
        }

        if (step4Complete)
        {
            //make light3 constant and make light4 flash
            light4Script.StopFlashing();
            color4Script.StopFlashing();
     
            Debug.Log("step4complete! Now go out to grow trees");
            //open the door
            DoorOpen();
            step4Complete = true;
        }


    }

    //called at the beginning by void start()
    private void Step1Start()
    {
        //at the beginning
        //light flashes at start           
        light1Script.Flash();
        color1Script.Flash();
        step1Start = true;
        //don't call checkAction1 here because it's called once
    }


    public void checkAction1()
    {
        if (potPick == true && potExit == true)
        {
            step1Complete = true;
        }
    }


    public void checkAction2()
    {
        if (ashPick == true && ashExit == true)
        {
            step2Complete = true;
        }
    }

    public void checkAction3()
    {
        if (seedPick == true && seedExit == true)
        {
            step3Complete = true;
        }
    }

    public void checkAction4()
    {
        if (waterPick == true && waterExit == true)
        {
            step4Complete = true;
        }
    }


    public void DoorOpen()
    {
        doorTrigger.StartDoorOpen();
    }


}
