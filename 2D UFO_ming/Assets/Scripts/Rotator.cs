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
        transform.Rotate(new Vector3 (0, 0, 10) * rotspeed * Time.deltaTime); //update는 호출 속도가 똑같지 않기 때문에 Time.deltatime
    }
}
