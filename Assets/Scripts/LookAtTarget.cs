using UnityEngine;

// scripts เอาไว้ให้วัตถุใดๆ มองไปที่ target
public class LookAtTarget : MonoBehaviour
{
    public Transform target;


    void Update()
    {
        transform.LookAt(target);
    }
}
