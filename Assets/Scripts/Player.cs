using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    private int _score;

    private Spawner spawner;

    public event UnityAction<int> ScoreChanged;

    public void AddScore(int level)
    {
        _score += level;
        ScoreChanged?.Invoke(_score);
    }
}
