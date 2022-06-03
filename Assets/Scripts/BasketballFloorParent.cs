using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballFloorParent : MonoBehaviour
{

    [SerializeField] BasketballFloor[] basketballFloors;
    public BasketballHoop PlayerHoop;
    public Transform PlayerReference;
    public List<Transform> PlayerTransforms;
    public BasketballHoop OpponentHoop;
    public Transform OpponentReference;
    public List<Transform> OpponentTransforms;
    
    public void Initialize()
    {
        int k = Random.Range(0, basketballFloors[0].HoopPositionCount);
        foreach (var basketballFloor in basketballFloors)
        {
            basketballFloor.Initialize(k);
            
        }
        int i = Random.Range(0, 2);
        PlayerTransforms = basketballFloors[i].GetUnitTransforms();
        PlayerHoop = basketballFloors[i].GetHoopTransform();
        PlayerReference = basketballFloors[i].GetReferenceTransform();
       
        int j = Mathf.Abs(1 - i);
        OpponentTransforms = basketballFloors[j].GetUnitTransforms();
        OpponentHoop = basketballFloors[j].GetHoopTransform();
        OpponentReference = basketballFloors[j].GetReferenceTransform();
        basketballFloors[j].gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }
}