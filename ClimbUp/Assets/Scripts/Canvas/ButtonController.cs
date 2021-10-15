using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Image _scroll;
    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonimprovement;
    [SerializeField] private Button _buttonfurther;
    [SerializeField] private Text _text;
    [SerializeField] private Text _levelNumber;

    private GoldController gold;
    private LevelController level;

    private void Awake()
    {
        Time.timeScale = 0;
        Camera.main.GetComponent<MovementlController>().enabled = false;
        Camera.main.GetComponent<WasherController>().enabled = false;
        gold = Camera.main.GetComponent<GoldController>();
        level = new LevelController();
        _buttonfurther.onClick.AddListener(Further);
        _buttonimprovement.onClick.AddListener(Improvement);
        _buttonPlay.onClick.AddListener(ButtonPlay);
        _buttonRestart.onClick.AddListener(Restart);
    }
     
    private void Improvement()
    {
            gold.WasteGold();
    }

    private void Further()
    {
        _text.text = "Уровень в разработке";
        level.NextLevel();
        _levelNumber.text = Convert.ToString(level.Level);
    }

    private void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void ButtonPlay()
    {
        Time.timeScale = 1;
        Camera.main.GetComponent<MovementlController>().enabled = true;
        Camera.main.GetComponent<WasherController>().enabled = true;
        _buttonPlay.gameObject.SetActive(false);
        _scroll.gameObject.SetActive(false);
    }
}