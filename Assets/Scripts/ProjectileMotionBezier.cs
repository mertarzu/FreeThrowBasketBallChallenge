using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMotionBezier : MonoBehaviour
{
    [SerializeField] Transform ballTransform;  
    float time;
    float extraTime;
    float bounceTime;
    float bounceHeight;
    float timeModifier;
    int randomDirection;
    Vector3 startPosition;
    Vector3 finalPosition;
    Vector3 hoopPosition;
    Vector3 middlePosition;
    Vector3 secondMiddlePosition;
    Vector3 groundPosition;
    Vector3 middleBouncePosition;
    Vector3 finalBouncePosition;
    Vector3 direction;

    bool isProjectile;
    bool isBasket;

    public bool IsProjectile => isProjectile;
    [SerializeField] float releaseTime;
    float tempTime;

    private void FixedUpdate()
    {

        if (isProjectile)
        {
            if ( time < 1f)
            {
                // Debug.Log(startPosition + " " + middlePosition + " " + finalPosition);
                 ballTransform.position = QuadraticBezierCurveSolver(time,startPosition, middlePosition, finalPosition);
               // ballTransform.position = CubicBezierCurveSolver(time, startPosition, middlePosition, finalPosition, groundPosition);
                time += Time.fixedDeltaTime * timeModifier;
                
            }
            else if (extraTime < 1f && !isBasket)
            {
                ballTransform.position = QuadraticBezierCurveSolver(extraTime, finalPosition, secondMiddlePosition, groundPosition);
                extraTime += Time.fixedDeltaTime * timeModifier * 2;
                if(extraTime > 1f)
                {
                    randomDirection = 3;
                    bounceHeight = hoopPosition.y * 4 / 5;
                    direction /= 4;
                    middleBouncePosition = new Vector3(ballTransform.position.x + direction.x, ballTransform.position.y + bounceHeight, ballTransform.position.z + direction.z);
                    finalBouncePosition = new Vector3(ballTransform.position.x + randomDirection * direction.x, ballTransform.position.y, ballTransform.position.z + randomDirection * direction.z);
                   
                }
            }
            else if (isBasket)
            {
                if (ballTransform.position.y > 1f)
                {
                    //ballTransform.position = new Vector3(ballTransform.position.x, ballTransform.position.y - .5f, ballTransform.position.z);
                    ballTransform.position = new Vector3(hoopPosition.x, ballTransform.position.y - .5f, hoopPosition.z);
                }
                else
                {
                    isBasket = false;
                    extraTime = 1f;
                    randomDirection = -3;
                    direction = direction.normalized;
                    middleBouncePosition = new Vector3(ballTransform.position.x + direction.x, ballTransform.position.y + bounceHeight, ballTransform.position.z + direction.z);
                    finalBouncePosition = new Vector3(ballTransform.position.x + randomDirection * direction.x, ballTransform.position.y, ballTransform.position.z + randomDirection * direction.z);
                   // Debug.Log(ballTransform.position.y);
                }
               
            }
            else if (bounceTime < 1f)
            {             

                ballTransform.position = QuadraticBezierCurveSolver(bounceTime, ballTransform.position, middleBouncePosition, finalBouncePosition);
                bounceTime += Time.fixedDeltaTime * 1f;
                if (bounceTime > 1f && bounceHeight > 1f)
                {
                    bounceTime = 0;
                    bounceHeight /= 2;
                    direction /= 2;
                    middleBouncePosition = new Vector3(ballTransform.position.x + direction.x, ballTransform.position.y + bounceHeight, ballTransform.position.z + direction.z);
                    finalBouncePosition = new Vector3(ballTransform.position.x + randomDirection * direction.x, ballTransform.position.y, ballTransform.position.z + randomDirection * direction.z);

                }


            }
            else
            {
                tempTime += Time.fixedDeltaTime;

                if (tempTime > releaseTime)
                {
                    isProjectile = false;
                    ballTransform.gameObject.SetActive(false);
                    tempTime = 0;
                }

                //isProjectile = false;
                //ballTransform.gameObject.SetActive(false);
            }
        }

    }

    public void Navigate(Transform referenceTransform, Transform startTransform, Transform finalTransform, float mHeight, float tModifier, Vector3 offset)
    {
        ballTransform.position = startTransform.position;
        startPosition = startTransform.position;
        hoopPosition = finalTransform.position;
        finalPosition = finalTransform.position + offset;
        middlePosition = new Vector3((startPosition.x + finalPosition.x) / 2, finalPosition.y + mHeight, (startPosition.z + finalPosition.z) / 2);
       
        direction = finalPosition - startPosition;
        groundPosition = new Vector3(finalPosition.x + direction.x/2, 0, finalPosition.z + direction.z/2);
        secondMiddlePosition = new Vector3((finalPosition.x + groundPosition.x)/2, finalPosition.y/2, (finalPosition.z + groundPosition.z) / 2);
        
       

        timeModifier = tModifier;
        timeModifier = 1;
        time = 0;
        extraTime = 0;
        bounceTime = 0;
        bounceHeight = 10f;
        isProjectile = true;
        ballTransform.gameObject.SetActive(true);
       
    }

    Vector3 QuadraticBezierCurveSolver(float t, Vector3 P0, Vector3 P1, Vector3 P2)
    {
        float cX = QuadraticBezierCurve(t, P0.x, P1.x, P2.x);
        float cY = QuadraticBezierCurve(t, P0.y, P1.y, P2.y);
        float cZ = QuadraticBezierCurve(t, P0.z, P1.z, P2.z);
        return new Vector3(cX, cY, cZ);
    }
    float QuadraticBezierCurve(float t, float P0, float P1, float P2)
    {
        float curve = P0 * (1 - t) * (1 - t) + P1 * 2 * t * (1 - t) + P2 * t * t;
        return curve;
    }

    Vector3 CubicBezierCurveSolver(float t, Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3)
    {
        float cX = CubicBezierCurve(t, P0.x, P1.x, P2.x, P3.x);
        float cY = CubicBezierCurve(t, P0.y, P1.y, P2.y, P3.y);
        float cZ = CubicBezierCurve(t, P0.z, P1.z, P2.z, P3.z);
        return new Vector3(cX, cY, cZ);
    }
    float CubicBezierCurve(float t, float P0, float P1, float P2, float P3)
    {
        float curve = P0 * (1 - t) * (1 - t) * (1 - t) + P1 * 3 * t * (1 - t) * (1 - t) + P2 * 3 *  t * t * (1- t) + P3 * t * t * t;
        return curve;
    }

    public void SetIsBasket(bool basket)
    {
       
        isBasket = basket; 
    }
}
