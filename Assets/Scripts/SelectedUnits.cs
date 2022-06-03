using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectedUnits : MonoBehaviour
{
   
    public List<Unit> selectedUnits = new List<Unit>();
   
    public void AddSelectedUnit(Unit unit)
    {
        selectedUnits.Add(unit);
        unit.ActivateSelectionBox();
     
    }

    public void RemoveSelectedUnits()
    {
        foreach (Unit unit in selectedUnits)
        {
            unit.DeactivateSelectionBox();
        }
        
        selectedUnits.Clear();
        
    }

    public void RemoveSelectedUnit(int i)
    {
        selectedUnits.RemoveAt(i);
    }

    public int GetSelectedUnitsNumber()
    {
        return selectedUnits.Count;
    }
    public bool isInSelectedUnitsList(Unit unit)
    {
        if (selectedUnits.Contains(unit)) return true;
        else return false;
    }

}
