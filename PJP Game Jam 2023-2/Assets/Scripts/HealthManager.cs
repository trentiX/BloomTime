using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject[] healths;

    private int index = 0;

    public void GetDamage()
    {
        if (index < 4)
        {
            Destroy(healths[index]);
            index++;
        }
    }
}
