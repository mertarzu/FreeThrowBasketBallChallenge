using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballFloor : MonoBehaviour
{
    [SerializeField] List<Transform> unitTransforms;
    [SerializeField] List<Transform> hoopPositions;
    [SerializeField] Transform hoop;
    [SerializeField] BasketballHoop hoopTransform;
    [SerializeField] Transform referenceTransform;
    public int HoopPositionCount => hoopPositions.Count;
    public void Initialize(int i)
    {
        
        Transform hoopPos = hoopPositions[i];
        hoop.position = hoopPos.position;
        hoop.rotation = hoopPos.rotation;
    
    }
    public BasketballHoop GetHoopTransform()
    {
        return hoopTransform;

    }
    public List<Transform> GetUnitTransforms()
    {
        return unitTransforms;
    }
    public Transform GetReferenceTransform()
    {
        return referenceTransform;

    }

   
}
