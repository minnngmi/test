using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    float rotspeed;


    private void Start()
    {
        rotspeed = Random.Range(10f, 50f);
    }


    private void Update()
    {
        transform.Rotate(new Vector3 (0, 0, 10) * rotspeed * Time.deltaTime); //update�� ȣ�� �ӵ��� �Ȱ��� �ʱ� ������ Time.deltatime
    }
}
