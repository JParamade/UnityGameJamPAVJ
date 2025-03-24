using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    private TextMeshProUGUI m_tScoreText;
    private TextMeshProUGUI m_tTimerSecondsText;
    private TextMeshProUGUI m_tTimerMilisecondsText;

    private void Awake() {
        m_tScoreText = GetComponentsInChildren<TextMeshProUGUI>()[0];
        m_tTimerSecondsText = GetComponentsInChildren<TextMeshProUGUI>()[1];
        m_tTimerMilisecondsText = GetComponentsInChildren<TextMeshProUGUI>()[2];    
    }

    private void Start()
    {
        GameManager.Instance.m_dOnPointsChanged += UpdateScoreText;
        GameManager.Instance.m_dOnTimeChanged += UpdateTimerText;
        GameManager.Instance.m_dOnGameEnded += GameOver;
    }

    private void UpdateScoreText(int _iNewScore) {
        m_tScoreText.text = _iNewScore.ToString();
    }

    private void UpdateTimerText(float _iNewTime) {
        m_tTimerSecondsText.text = _iNewTime < 10 ? ("0" + _iNewTime.ToString("0")) : _iNewTime.ToString("0");
        m_tTimerMilisecondsText.text = (_iNewTime * 1000).ToString("0");
        //string.Format()
    }

    private void GameOver() {
        GameManager.Instance.m_dOnPointsChanged -= UpdateScoreText;
        GameManager.Instance.m_dOnTimeChanged -= UpdateTimerText;
        GameManager.Instance.m_dOnGameEnded -= GameOver;
    }
}
