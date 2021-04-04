using UnityEngine;

public class Spawnable : PooledMonoBehaviour
{
    [SerializeField] float returnToPoolDelay = 10f;

    private void Start()
    {
        if(GetComponent<Health>() != null)
           GetComponent<Health>().OnDied += () => ReturnToPool(returnToPoolDelay);
    }
}
