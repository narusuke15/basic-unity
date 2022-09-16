using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTarget : MonoBehaviour
{
    public Transform target; // ประกาศตัวแปรเป็น public เพื่อเอาไว้เลือกวัตถุที่จะตามใน inspector


    void Update()
    {
        // เคลื่อนที่ตาม target ที่เลือก (เฉพาะแกน x)
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
