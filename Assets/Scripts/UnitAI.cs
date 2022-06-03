using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitAI : MonoBehaviour
{
    public abstract float GetMaxHeight();

    public abstract float GetTimeModifier();

    public abstract Vector3 GetOffset();
   
}
