using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : PooledObject
{
    [SerializeField] PathFinder pathFinder;
    [SerializeField] GameObject selectionBox;
    [SerializeField] UnitAI unitAI;
    [SerializeField] Transform ballTransform;
    [SerializeField] Transform lookTransform;
    [SerializeField] float maxTime;
    Transform basketballHoop;
    Transform reference;
    float tempTime;
    Vector3 destination;
    bool isTaken;

    public override bool IsPooledObjectTaken => isTaken;
  
    public void PathFinder(Vector3 target)
    {       
        pathFinder.NavigateUnit(target);
        destination = target;
    }

    public void SetSpeed(float speed)
    {
        pathFinder.SetSpeed(speed);   
    }

    public void SetTreshold(float treshold)
    {
        pathFinder.SetTreshold(treshold);
    }

    public void ActivateSelectionBox()
    {
        selectionBox.SetActive(true);
    }

    public void DeactivateSelectionBox()
    {
        selectionBox.SetActive(false);
    }

    public override void SetActive()
    {
        gameObject.SetActive(true);
        isTaken = true;
    }

    public override void Dismiss()
    {
        gameObject.SetActive(false);
        isTaken = false;
    }

    public void SetBasketballHoop(Transform playerHoop)
    {
        basketballHoop = playerHoop;
    }

    public void SetReference(Transform playerReference)
    {
        reference = playerReference;
    }

    void StartProjectile()
    {

        Ball ballItem = BallSpawn();
        
        if (ballItem != null)
        {
            ballItem.ProjectileMotion(reference, ballTransform, basketballHoop, unitAI.GetMaxHeight(), unitAI.GetTimeModifier(),unitAI.GetOffset());
        }
   
    }

    public Ball BallSpawn()
    {

        Ball ball = (Ball)PoolManager.Instance.GetItemByName("Ball");
        ball.SetActive();
   
        ball.transform.position = ballTransform.position;
        return ball;
    }

    public void Navigate(Vector3 pos)
    { 
        transform.position = pos; 
        lookTransform.position = new Vector3(basketballHoop.position.x, transform.position.y, basketballHoop.position.z);
        transform.LookAt(lookTransform);
        SetActive();
    }

    bool CheckDestinationReached()
    {

        if (Vector3.Distance(transform.position, destination) < 1f)
        {
            return true;
        }
        else return false;
    
    }

    private void Update()
    {
        if (CheckDestinationReached())
        {
            lookTransform.position = new Vector3(basketballHoop.position.x, transform.position.y, basketballHoop.position.z);
            transform.LookAt(lookTransform);
            tempTime += Time.deltaTime;

           if (tempTime > maxTime)
            {
                StartProjectile();
                tempTime = 0;
                
            }
        }
          
    }
}
