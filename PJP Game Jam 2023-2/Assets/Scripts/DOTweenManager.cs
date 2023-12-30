using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DOTweenManager : MonoBehaviour
{
    //components
    [SerializeField] private GameObject prefab;
    
    //circle
    private GameObject _circle;
    private const float CircleAnimTime = 1f;

    private void Awake()
    {
        _circle = Instantiate(prefab);
        _circle.transform.localScale = new Vector3(21f, 21f, 21f);
    }

    private void Start()
    {
        _circle.transform.DOScale(new Vector3(0f, 0f, 0f), CircleAnimTime).SetEase(Ease.InOutQuint);
        Destroy(prefab, CircleAnimTime);
    }
    
    public void StartGame()
    {
        _circle.transform.DOScale(new Vector3(21f, 21f, 21f), CircleAnimTime).SetEase(Ease.InOutQuint).OnComplete(() =>
        {
            SceneManager.LoadScene(1);
        }); 
    }
    public void Exit()
    {
        _circle.transform.DOScale(new Vector3(21f, 21f, 21f), CircleAnimTime).SetEase(Ease.InOutQuint).OnComplete(() =>
        {
            Application.Quit();
        }); 
    }
}