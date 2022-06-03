using UnityEngine;
public abstract class PooledObject : MonoBehaviour
{
    public abstract bool IsPooledObjectTaken { get; }
    public abstract void SetActive();
    public abstract void Dismiss();

}