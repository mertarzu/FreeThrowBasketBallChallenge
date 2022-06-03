using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAI : UnitAI
{
    float maxHeight;
    float timeModifier;
    Vector3 offset;
    float offsetNum;

    public override float GetMaxHeight()
    {
        maxHeight = Random.Range(10,20);     
        return maxHeight;
    }

    public override float GetTimeModifier()
    {
        timeModifier = Random.Range(45, 60);
        return timeModifier;
    }

    public override Vector3 GetOffset()
    {
        offsetNum = Random.Range(0, 100);
        if (offsetNum < 18)
        {
            offset = new Vector3(Random.Range(2f, 3.0f), 0, Random.Range(2f, 3.0f));
           
        }else if (offsetNum < 36)
        {
            offset = new Vector3(Random.Range(-3.0f, -2f), 0, Random.Range(-3.0f, -2f));
            
        }
        else if (offsetNum < 54)
        {
            offset = new Vector3(Random.Range(-3.0f, -2f), 0, Random.Range(2f, 3f));
            
        }
        else if (offsetNum < 72)
        {
            offset = new Vector3(Random.Range(2f, 3f), 0, Random.Range(-3.0f, -2f));
           
        }else offset = Vector3.zero;

       //offset = Vector3.zero;
        return offset;
    }
}
