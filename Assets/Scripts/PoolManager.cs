using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;

    public static PoolManager Instance => instance;

    private void Awake()
    {
        instance = this;
    }


    [SerializeField] List<ObjectPooler> objectpoolers = new List<ObjectPooler>();
  
    public ObjectPooler this[int i] => objectpoolers[i];
    
    public PooledObject GetItemByIndex(int index)
    {
        return objectpoolers[index].GetPooledObject();
    }
    public PooledObject GetItemByName(string poolName)
    {
        return objectpoolers.Where(i => i.GetPoolName() == poolName).FirstOrDefault().GetPooledObject();
    }

    public void Release()
    {
        
        for(int i = 0; i < objectpoolers.Count; i++)
        {
            for(int j = 0; j < objectpoolers[i].PooledObjects.Count; j++)
            {
                objectpoolers[i].PooledObjects[j].Dismiss();
            }
        }       
    }
}
