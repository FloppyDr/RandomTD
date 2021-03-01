using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private int _score;

    public event UnityAction<int> ScoreChanged;

    public void AddScore(int level)
    {
        _score += level;
        ScoreChanged?.Invoke(_score);
        PlaySound();
    }

    private void PlaySound()
    {
        _audioSource.Play();
    }
}
