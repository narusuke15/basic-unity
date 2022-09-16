using UnityEngine;

// scripts เอาไว้ให้วัตถุใดๆ มองไปที่ target
public class LookAtTarget : MonoBehaviour
{
    public Transform target; // ประกาศตัวแปรเป็น public เพื่อให้เราลากใส่จาก Inspector ได้


    void Update()
    {
        transform.LookAt(target); // function ของ Transform ทำให้วัตถุนี้มองไปที่ target
    }
}
