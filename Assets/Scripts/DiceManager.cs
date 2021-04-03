using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DiceManager : MonoBehaviour
{
    
    public Image die1Image;
    public Image die2Image;

    public TMP_Text holesInIceText;
    public TMP_Text iceBearsText;
    public TMP_Text fishText;
    public TMP_Text showAnswerText;

    public Dice[] dice;

    private bool _showAnswer = true;
    private int _die1;
    private int _die2;

    public void GenerateNew()
    {
        _die1 = Random.Range(1, 6);
        _die2 = Random.Range(1, 6);
        die1Image.sprite = dice[_die1].image;
        die2Image.sprite = dice[_die2].image;

        RefreshTexts();
    }

    public void ToggleAnswer()
    {
        _showAnswer = !_showAnswer;
        showAnswerText.text = _showAnswer ? "Hide Answer" : "Show Answer";

        if (_showAnswer)
        {
            RefreshTexts();
        }
        else
        {
            holesInIceText.text = "";
            iceBearsText.text = "";
            fishText.text = "";
        }
    }

    private void RefreshTexts()
    {
        if(!_showAnswer) return;
        holesInIceText.text = dice[_die1].holesInIce + dice[_die2].holesInIce == 1 ? dice[_die1].holesInIce + dice[_die2].holesInIce + " Hole" : dice[_die1].holesInIce + dice[_die2].holesInIce + " Holes";
        iceBearsText.text = dice[_die1].iceBears + dice[_die2].iceBears + " Ice Bears";
        fishText.text = dice[_die1].fish + dice[_die2].fish + " Fish";
    }

    private void Start()
    {
        GenerateNew();
    }
}
