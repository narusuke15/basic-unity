using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // ประกาศตัวแปร
    // [Header("ชื่อ header")] เอาไว้ประกาศชื่อ header ใน title เพื่อความสวยงาม
    [Header("Ref")]
    public GameObject goalGO;

    [Header("Parameters")]
    public float moveSpeed = 5f;
    public float jumpPower = 5f;
    public bool canJump = true;



    void Update()
    {
        // เช็ดปุ่มลูกศร เคลื่อนที่ซ้ายขวา
        // -- Input.GetKey เช็คทุก frame กดค้างได้
        // ---- KeyCode เป็น enum ที่ unity เขียนไว้ให้แล้ว มีชื่อปุ่มทุกปุ่มที่กดได้
        if (Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Rigidbody>().AddForce(-moveSpeed, 0, 0); // ใส่พลังให้ rigidBody ในแกน x
        else if (Input.GetKey(KeyCode.RightArrow))
            GetComponent<Rigidbody>().AddForce(moveSpeed, 0, 0);

        // เช็ดปุ่ม spave กระโดด
        // -- Input.GetKeyDown เช็คทุก frame ทำเฉพาะตอนกดปุ่มครั้งแรกครั้งเดียว
        // เช็ค canJump เพื่อให้กระโดดได้ครั้งเดียว
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            GetComponent<Rigidbody>().AddForce(0, jumpPower, 0, ForceMode.VelocityChange);
        }
    }

    // ให้กระโดดได้อีกครั้งถ้าผู้เล่นสัมผัสพื้นผิวอะไรซักอย่าง
    // -- OnCollisionEnter เป็น function พิเศษที่จะทำงานเมื่อเกิดการชนกันของวัตถุนี้กับวัตถุอื่นๆ หนึ่งครั้งจนกว่าจะขยับออกแล้วชนใหม่
    void OnCollisionEnter()
    {
        canJump = true;
    }

    // ให้จบเกมถ้าผู้เล่นเดินชน goal
    // -- OnTriggerEnter เป็น function พิเศษที่จะทำงานเมื่อวัตุเข้าไปในเขตของ collider ที่ไม่มี rigidbody หนึ่งครั้งจนกว่าจะขยับออกแล้วเข้าใหม่
    void OnTriggerEnter(Collider other)
    {
        // ถ้าวัตุที่เราโดนชื่อว่า Goal
        if (other.name == "Goal")
        {
            Debug.Log("Win");
            goalGO.SetActive(true); // <ตัวแปร GameObject>.SetActive ใช้เปิดปิด GameObject เหมือนกดติ๊กถูกใน Inspector
        }
    }
}
