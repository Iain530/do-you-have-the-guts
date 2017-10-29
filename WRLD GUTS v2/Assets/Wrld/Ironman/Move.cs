using System.Collections;
using UnityEngine;


public class Move : MonoBehaviour
{


    public float moveSpeed = 300f;
    public float turnSpeed = 50f;
    public float changeToSpeed = 300f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W))
            this.GetComponent<Rigidbody>().velocity = this.transform.up * moveSpeed;

        if (Input.GetKeyUp(KeyCode.W))
            this.GetComponent<Rigidbody>().velocity = this.transform.up * 0f;

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S))
            this.GetComponent<Rigidbody>().velocity = this.transform.up * -moveSpeed;

        if (Input.GetKeyUp(KeyCode.S))
            this.GetComponent<Rigidbody>().velocity = this.transform.up * 0f;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (changeToSpeed != moveSpeed)
        {
            if (changeToSpeed < moveSpeed)
                moveSpeed-=25;
            else
                moveSpeed+=25;
        }
    }

    public void ChangeSpeed(int s)
    {
        changeToSpeed = s;
    }
}