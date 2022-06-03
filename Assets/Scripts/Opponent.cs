using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    [SerializeField] BasketballCourt basketballCourt;
    [SerializeField] UnitContainer unitContainer;
    [SerializeField] OpponentDecisionMaker opponentDecisionMaker;
    public void Initialize()
    {
        Spawn();
        opponentDecisionMaker.OnSelected = onOpponentSelected;
    }

    void onOpponentSelected(Unit unit)
    {
      
            int i = Random.Range(0, basketballCourt.OpponentTransforms.Count);
            unit.PathFinder(basketballCourt.OpponentTransforms[i].position);
        
    }
    void Spawn()
    {
       
        for (int i = 0; i < 5; i++)
        {
            
            Unit opponentUnit = (Unit)PoolManager.Instance.GetItemByName("Opponent");
            unitContainer.SetUnit(opponentUnit);
            if (opponentUnit != null)
            {
               // int k = Random.Range(0, basketballCourt.OpponentTransforms.Count);
              
                opponentUnit.SetBasketballHoop(basketballCourt.OpponentHoop.transform);
                opponentUnit.SetReference(basketballCourt.OpponentReference);
                opponentUnit.Navigate(basketballCourt.OpponentTransforms[i].position);
            }

        }

    }

}
