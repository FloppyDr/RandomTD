using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private CanvasGroup _gameOverScreenCanvas;

    private void OnEnable()
    {
        _spawner.PlaceIsOver += CheckGameOver;
    }

    private void OnDisable()
    {
        _spawner.PlaceIsOver -= CheckGameOver;
    }

    private void Start()
    {
        _gameOverScreenCanvas.alpha = 0;
        _gameOverScreenCanvas.interactable = false;
        _gameOverScreenCanvas.blocksRaycasts = false;
    }

    private void CheckGameOver()
    {

        int match = 0;

        for (int i = 0; i < _spawner.Pool.Count; i++)
        {
            for (int j = i + 1; j < _spawner.Pool.Count; j++)
            {

                if (_spawner.Pool[i].GetComponent<Block>().Level == _spawner.Pool[j].GetComponent<Block>().Level
                && _spawner.Pool[i].GetComponent<Block>().Color == _spawner.Pool[j].GetComponent<Block>().Color)
                {
                    match++;
                }
            }
        }

        if (match < 1)
        {
            _gameOverScreenCanvas.alpha = 1;
            _gameOverScreenCanvas.interactable = true;
            _gameOverScreenCanvas.blocksRaycasts = true;
            Debug.Log("GameOVer");
        }
    }
}
