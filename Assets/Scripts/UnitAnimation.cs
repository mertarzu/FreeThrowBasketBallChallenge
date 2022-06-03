using UnityEngine;
using UnityEngine.AI;

public class UnitAnimation : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Animator anim;
   
    void Update()
    {
        anim.SetFloat("VelocityX", navMeshAgent.velocity.x);
        anim.SetFloat("VelocityZ", navMeshAgent.velocity.z);
    }   
}
