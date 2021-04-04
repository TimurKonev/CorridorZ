using UnityEngine;

public class WeaponProjectileLauncher : WeaponComponent
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float moveSpeed = 40;
    [SerializeField] float maxDistance = 100;
    [SerializeField] int damageAmount = 3;
    
    [SerializeField] LayerMask layerMask;
    RaycastHit hitInfo;


   
    protected override void WeaponFired()
    {
        Vector3 direction = weapon.IsInAimMode ? GetDirection() : firePoint.forward;

        var projectile = projectilePrefab.Get<Projectile>(firePoint.position, Quaternion.Euler(direction));
        projectile.GetComponent<Rigidbody>().velocity = direction * moveSpeed;
    }

    private Vector3 GetDirection()
    {
        var ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        Vector3 target = ray.GetPoint(300);

        if (Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            Health health = hitInfo.collider.GetComponent<Health>();

            if (health != null)
            {
                health.TakeHit(damageAmount);
            }
            else
            {
                target = hitInfo.point;
            }
        }

        Vector3 direction = target - transform.position;
        direction.Normalize();

        return direction;
    }
}


