using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScore : MonoBehaviour
{
    public int scoreOff;

    private void OnDisable()
    {
        Invoke("EnableObj", 3f);
    }

    void EnableObj()
    {
        gameObject.SetActive(true);
    }
}
