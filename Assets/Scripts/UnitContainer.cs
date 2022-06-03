using System.Collections.Generic;
using UnityEngine;

public class UnitContainer : MonoBehaviour
{
    List<Unit> allUnits = new List<Unit>();
    public int Count => allUnits.Count;
  
    public Unit GetUnit(int i)
    {
        return allUnits[i];
    }

    public void SetUnit(Unit unit)
    {
        allUnits.Add(unit);
    }
}
