using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.transform.position; // 벡터는 빼기의 앞에 있는 대상으로 화살표 방향이 향함
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
