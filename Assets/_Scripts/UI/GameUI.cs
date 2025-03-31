using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private TextMeshProUGUI m_tScoreText;
    private TextMeshProUGUI m_tTimerSecondsText;
    private TextMeshProUGUI m_tTimerMillisecondsText;

    private void Awake() {
        m_tScoreText = GetComponentsInChildren<TextMeshProUGUI>()[0];
        m_tTimerSecondsText = GetComponentsInChildren<TextMeshProUGUI>()[1];
        m_tTimerMillisecondsText = GetComponentsInChildren<TextMeshProUGUI>()[2];
    }

    private void Start() {
        GameManager.Instance.m_dOnPointsChanged += UpdateScoreText;
        GameManager.Instance.m_dOnTimeChanged += UpdateTimerText;
        GameManager.Instance.m_dOnGameEnded += GameOver;
    }

    private void UpdateScoreText(int _iNewScore) {
        m_tScoreText.text = _iNewScore.ToString();
    }

    private void UpdateTimerText(float _fNewTime) {
        m_tTimerSecondsText.text = _fNewTime.ToString("00");
        m_tTimerMillisecondsText.text = ((_fNewTime - Mathf.Floor(_fNewTime)) * 100).ToString("00");
    }

    private void GameOver() {
        GameManager.Instance.m_dOnPointsChanged -= UpdateScoreText;
        GameManager.Instance.m_dOnTimeChanged -= UpdateTimerText;
        GameManager.Instance.m_dOnGameEnded -= GameOver;
    }
}