using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTree : MonoBehaviour
{
    public GameObject scaleTree;
    public float scaleSpeed = 1.0f;
    public bool canScale = false;

    private float scaleChange;

   
    public void StartScaling()
    {
        //scaleTree.transform.position = new Vector3(0, 0, 0);
        scaleChange = 0;
        canScale = true;
    }

    // Update is called once per frame
    void Update()
    {
        //when StartScaling() is called, start growing trees
        if (scaleChange < 1 && canScale)
        {
            scaleChange = Mathf.MoveTowards(scaleChange, 1.0f, scaleSpeed * Time.deltaTime);
            scaleTree.transform.localScale = new Vector3(scaleChange, scaleChange, scaleChange);
        }

    }
}
