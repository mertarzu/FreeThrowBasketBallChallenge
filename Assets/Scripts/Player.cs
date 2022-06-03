using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] SelectedUnits selectedUnits;
    [SerializeField] TargetInputController targetInputController;
    [SerializeField] BasketballCourt basketballCourt;
    [SerializeField] UnitContainer unitContainer;
 
    void  onTargetSelected(Vector3 target)
    {
        foreach (Unit selectedUnit in selectedUnits.selectedUnits)
        {
            selectedUnit.PathFinder(target);
        }            
    }
  
    public void Initialize()
    {
        Spawn();
        targetInputController.OnTriggerInput = onTargetSelected;   
    }

   void Spawn()
    {
       
        for (int i = 0; i < 5; i++)
        {                       
            Unit playerUnit = (Unit)PoolManager.Instance.GetItemByName("Player");
            unitContainer.SetUnit(playerUnit);

            if (playerUnit != null)
            {
                //int k = Random.Range(0, basketballCourt.OpponentTransforms.Count);
               
                playerUnit.SetBasketballHoop(basketballCourt.PlayerHoop.transform);
                playerUnit.SetReference(basketballCourt.PlayerReference);
                playerUnit.Navigate(basketballCourt.PlayerTransforms[i].position);
            }                         
        }           
    }
}
