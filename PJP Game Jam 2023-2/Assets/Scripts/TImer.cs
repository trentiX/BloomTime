using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TImer : MonoBehaviour
{
    [SerializeField] private TMP_Text secs;

    private int sec = 0;

    private void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (sec < 9)
            {
                sec += 1;
                secs.text = "00" + sec.ToString();
                yield return new WaitForSeconds(1);
            }
            else if (sec < 99)
            {
                sec += 1;
                secs.text = "0" + sec.ToString();
                yield return new WaitForSeconds(1);
            }
            else
            {
                sec += 1;
                secs.text = sec.ToString();
                yield return new WaitForSeconds(1);
            }
        }
    }
}
