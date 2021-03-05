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

        for (int i = 0; i < _spawner.SpawnedBlocks.Count; i++)
        {
            for (int j = i + 1; j < _spawner.SpawnedBlocks.Count; j++)
            {
                var curretBlock = _spawner.SpawnedBlocks[i].GetComponent<Block>();
                var nextBlock = _spawner.SpawnedBlocks[j].GetComponent<Block>();

                if (curretBlock.Level == nextBlock.Level
                    && curretBlock.Color == nextBlock.Color)
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
