using UnityEngine;

public class Ball : PooledObject
{
    //[SerializeField] ProjectileMotion projectileMotion;
    [SerializeField] ProjectileMotionBezier projectileMotion;
    public override bool IsPooledObjectTaken => projectileMotion.IsProjectile;

    public override void Dismiss()
    {
        gameObject.SetActive(false);
     
    }

    public void ProjectileMotion(Transform referenceTransform, Transform startTransform, Transform finalTransform, float maxHeight, float time, Vector3 offset)
     {
       projectileMotion.Navigate(referenceTransform, startTransform, finalTransform, maxHeight, time,offset);
     
    }

    public override void SetActive()
    {
        gameObject.SetActive(true);
   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hoop"))
        {
            projectileMotion.SetIsBasket(true);
        }
      
       
    }

}
