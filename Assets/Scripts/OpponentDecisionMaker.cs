using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class OpponentDecisionMaker : MonoBehaviour
{
    public Action<Unit> OnSelected;
    [SerializeField] UnitContainer unitContainer; 
    bool isGameActive;
    float maxTime = 1;
    float tempTime;
  

    void CheckSelectedUnit()
    {
        if (isGameActive)
        {
          
            int i = Random.Range(0, unitContainer.Count);


            if (OnSelected != null)
            {
                OnSelected(unitContainer.GetUnit(i));
            }

        }     
         
    }
   
    private void Update()
    {
    
        tempTime += Time.deltaTime;

        if (tempTime > maxTime)
        {
           CheckSelectedUnit();
            tempTime = 0;
            maxTime = Random.Range(0, 5);
        }
        

    }

    public void Initialize()
    {
        isGameActive = true;
      
    }
}
