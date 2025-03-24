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
    [SerializeField] private float m_fStartTimer = 60.0f;
    private float m_fCurrentTimer;

    // Delegates
    delegate void OnPointsChanged(int _iPoints);
    OnPointsChanged m_dOnPointsChanged;

    delegate void OnTimeChanged(float _fCurrentTime);
    OnTimeChanged m_dOnTimeChanged;

    delegate void OnGameEnded();
    OnGameEnded m_dOnGameEnded;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(this);
        else Instance = this;
    }

    private void Start() {
        m_fCurrentTimer = m_fStartTimer;

        m_bGameStarted = true;  
    }

    private void Update() {
        if (m_bGameStarted) {
            m_fCurrentTimer -= Time.deltaTime;
            m_dOnTimeChanged?.Invoke(m_fCurrentTimer);

            if (m_fCurrentTimer <= 0.0f) {
                m_bGameStarted = false;
                m_dOnGameEnded?.Invoke();
            } 
        }
    }

    public void AddPoints(int _iPointsToAdd) {
        m_iPoints += _iPointsToAdd;
        m_dOnPointsChanged?.Invoke(m_iPoints);
    }
}