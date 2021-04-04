using UnityEngine;
using UnityEngine.AI;

public class ZombieNavigation : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2.0f;
    Transform playerTransform;
    NavMeshPath path;
    GameObject cube;

    void Awake()
    {
        GetComponent<Health>().OnDied += ZombieNavigation_OnDied;
    }

    void ZombieNavigation_OnDied()
    {
        this.enabled = false;
    }

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        path = new NavMeshPath();
    }

    void Update()
    {
        var targetPosition = playerTransform.position;

        bool foundPath = NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
        if (foundPath)
        {
            Vector3 nextDestination = path.corners[1];

            Vector3 directionToTarget = nextDestination - transform.position;
            Vector3 flatDirection = new Vector3(directionToTarget.x, 0, directionToTarget.z);
            directionToTarget = Vector3.Normalize(flatDirection);

            var desiredRotation = Quaternion.LookRotation(directionToTarget);
            var finalRotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime);
            transform.rotation = finalRotation;
        }
    }
}
