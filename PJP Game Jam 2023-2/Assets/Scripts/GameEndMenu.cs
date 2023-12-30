using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEndMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text sec;
    [SerializeField] private TMP_Text endSec;

    private void Start()
    {
        endSec.text = sec.text;
    }
}
