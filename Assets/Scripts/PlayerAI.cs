using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : UnitAI
{
    float maxHeight;
    float timeModifier;
    Vector3 offset;
    int offsetNum;

    public override float GetMaxHeight()
    {
        maxHeight = Random.Range(10, 20);       
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
        if (offsetNum < 8)
        {
            offset = new Vector3(Random.Range(2f, 3.0f), 0, Random.Range(2f, 3.0f));

        }
        else if (offsetNum < 16)
        {
            offset = new Vector3(Random.Range(-3.0f, -2f), 0, Random.Range(-3.0f, -2f));

        }
        else if (offsetNum < 24)
        {
            offset = new Vector3(Random.Range(-3.0f, -2f), 0, Random.Range(2f, 3f));

        }
        else if (offsetNum < 32)
        {
            offset = new Vector3(Random.Range(2f, 3f), 0, Random.Range(-3.0f, -2f));

        }
        else offset = Vector3.zero;
        return offset;
    }
}
