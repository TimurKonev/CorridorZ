using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] Transform firstPersonWeaponPoint;
    [SerializeField] Transform thirdPersonWeaponPoint;
    [SerializeField] GameObject[] weapons;

    public bool IsFpsMode { get; set; }



    void Update()
    {
        if (IsFpsMode)
        {
            transform.position = firstPersonWeaponPoint.position;
            transform.rotation = firstPersonWeaponPoint.rotation;
        }
        else
        {
            transform.position = thirdPersonWeaponPoint.position;
            transform.rotation = thirdPersonWeaponPoint.rotation;
        }
    }

}
