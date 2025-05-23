using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance { get; private set; }

    // Serialized Fields
    [Header("Game Manager")]
    [SerializeField] private bool m_bGameStarted;
    public int m_iPoints;

    [Header("Time Variables")]
    [SerializeField] private float m_fStartTimer = 60f;
    private float m_fCurrentTimer;

    // Delegates
    public delegate void OnPointsChanged(int _iPoints);
    public OnPointsChanged m_dOnPointsChanged;

    public delegate void OnTimeChanged(float _fCurrentTime);
    public OnTimeChanged m_dOnTimeChanged;

    public delegate void OnGameEnded();
    public OnGameEnded m_dOnGameEnded;

    private void Awake() {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private void Start() {
        m_fCurrentTimer = m_fStartTimer;

        m_bGameStarted = true;
    }

    private void Update() {
        TimeManager(m_bGameStarted);

        if (Input.GetKeyDown(KeyCode.Escape)) QuitGame();
    }

    public void AddPoints(int _iPointsToAdd) {
        m_iPoints += _iPointsToAdd;
        m_dOnPointsChanged?.Invoke(m_iPoints);
    }

    private void TimeManager(bool _bGameStarted)
    {
        if (_bGameStarted)
        {
            m_fCurrentTimer -= Time.deltaTime;
            m_dOnTimeChanged?.Invoke(m_fCurrentTimer);

            if (m_fCurrentTimer <= 0.0f)
            {
                _bGameStarted = false;
                m_dOnGameEnded?.Invoke();
            }
        }
    }
    
    private void QuitGame() {
        Application.Quit();
    }

}