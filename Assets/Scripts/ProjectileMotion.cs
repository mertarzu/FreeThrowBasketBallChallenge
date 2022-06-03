using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    [SerializeField] Transform ballTransform;
    [SerializeField] Rigidbody ballRigidbody;
    float maxHeight = 2;
    float deltaHeight;
    float deltaTime;
    float time;
    float timeOfFlight;
    float r;
    float r0;
    float alpha;
    float beta;
    float x;
    float z;
    float y;
    float theta;
    float theta2;
    float angle0;
    float v0;
    float n = 100;
    Vector3 startPosition;
    Vector3 finalPosition;
    Vector3 referencePosition;
    const float gravityConst = 9.8f;
    bool isProjectile;
    bool isOffset;
    public bool IsProjectile => isProjectile;
    [SerializeField] float releaseTime;
    float tempTime;

    private void FixedUpdate()
    {

        if (isProjectile)
        {
            if ((timeOfFlight - time) > 1e-7f)
            {
                r = r0 + v0 * Mathf.Cos(angle0) * time;
                y = startPosition.y + v0 * Mathf.Sin(angle0) * time - .5f * gravityConst * time * time;
                theta = beta + alpha * time;
                x = r * Mathf.Cos(theta);
                z = r * Mathf.Sin(theta);
               
                ballTransform.position = new Vector3(x, y, z) + referencePosition;
                time += deltaTime;
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
            }         
        }
     
    }

    public void Navigate(Transform referenceTransform, Transform startTransform, Transform finalTransform, float mHeight, float timeModifier,Vector3 offset)
    {
        ballTransform.position = startTransform.position;
    
        referencePosition = referenceTransform.position;
        startPosition = startTransform.position - referencePosition;
        offset.y = 0;
        finalPosition = finalTransform.position + offset - referencePosition;    
        maxHeight = mHeight;
        n = timeModifier;
        r0 = Mathf.Sqrt(startPosition.x * startPosition.x + startPosition.z * startPosition.z);  
        beta = Mathf.Atan2(startPosition.z , startPosition.x);
        theta2 = Mathf.Atan2(finalPosition.z , finalPosition.x);       
        float finalPositionR = Mathf.Sqrt(finalPosition.x * finalPosition.x + finalPosition.z * finalPosition.z); 
        deltaHeight = finalPosition.y - startPosition.y;
       

        timeOfFlight = (2 * (maxHeight + Mathf.Sqrt(maxHeight * (maxHeight - deltaHeight)))) / Mathf.Sqrt(2 * gravityConst * maxHeight);
       
        angle0 = Mathf.Atan(timeOfFlight * Mathf.Sqrt(2 * gravityConst * maxHeight )/ (finalPositionR - r0));
        v0 = Mathf.Sqrt(2 * gravityConst * maxHeight) / Mathf.Sin(angle0);

        alpha = (theta2 - beta) / timeOfFlight;
        if (offset != Vector3.zero)
        {
            n = 100;
            timeOfFlight *= 1.3f;
        }
        deltaTime = timeOfFlight / n;

        time = 0;
        isProjectile = true;
        ballTransform.gameObject.SetActive(true);
        //Debug.Log(startPosition + " " + finalPosition + " " + mHeight + " " + timeModifier);
    }

    
}
