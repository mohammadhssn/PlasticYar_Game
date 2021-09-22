using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject  settingPanel;
    [SerializeField] private Text mainScoreText;
    private int _mainScore;
    void Awake()
    {
        _mainScore = PlayerPrefs.GetInt("_mainScore", 0);
        Debug.Log(_mainScore);
        mainScoreText.text = _mainScore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void SelectButtonSetting()
    {
        settingPanel.GetComponent<Animator>().SetTrigger("Pop");
    }
}
