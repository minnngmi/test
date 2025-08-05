using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScore : MonoBehaviour
{
    public int score;

    private void OnDisable()
    {
        Invoke("EnableObj", 3f);
    }

    void EnableObj()
    {
        gameObject.SetActive(true);
    }
}
