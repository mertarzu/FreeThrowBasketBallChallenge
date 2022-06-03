using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
  
    public void NavigateUnit(Vector3 navigationPoint )
    {
        navMeshAgent.SetDestination(navigationPoint);
        
    }

    public void SetSpeed(float speed)
    {
        navMeshAgent.speed = speed;        
    }

    public void SetTreshold(float treshold)
    {
        navMeshAgent.stoppingDistance = treshold;       
    }

   
    

}
