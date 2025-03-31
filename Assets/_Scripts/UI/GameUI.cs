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
    
    [SerializeField] TextMeshProUGUI m_tEndScoreText;
    [SerializeField] GameObject m_goTimeOutScreen;

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
        int iTempTime = (int)_fNewTime;
        m_tTimerSecondsText.text = iTempTime.ToString("00");
        m_tTimerMillisecondsText.text = ((_fNewTime - iTempTime) * 100).ToString("00");
    }

    private void GameOver() {
        m_tEndScoreText.text = GameManager.Instance.m_iPoints.ToString();
        m_goTimeOutScreen.gameObject.SetActive(true);

        GameManager.Instance.m_dOnPointsChanged -= UpdateScoreText;
        GameManager.Instance.m_dOnTimeChanged -= UpdateTimerText;
        GameManager.Instance.m_dOnGameEnded -= GameOver;
    }
}