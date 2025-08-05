using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContoller : MonoBehaviour
{
    public Transform playerTr;
    public float speed;

    private void Update()
    {
        Vector3 direction = playerTr.position - transform.position;
        direction.Normalize();  
        transform.position += direction * speed * Time.deltaTime;
    }
}