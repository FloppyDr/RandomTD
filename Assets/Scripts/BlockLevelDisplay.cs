using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockLevelDisplay : MonoBehaviour
{
    [SerializeField] private Block _block;
    [SerializeField] private Text _levelDisplay;

    private void OnEnable()
    {
        _block.LevelChanged += OnLevelChanged;
    }

    private void OnDisable()
    {
        _block.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged(int level)
    {
        _levelDisplay.text = level.ToString();
    }
}
