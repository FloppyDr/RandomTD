using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;


[RequireComponent(typeof(SpriteRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private List<Block> _variants;
    [SerializeField] private Player _player;
    [SerializeField] private Color _color;

    private SpriteRenderer _spriteRenderer;
    private int _scoreMultiplier = 2;
    private int _level = 0;

    public Color Color => _color;
    public int Level => _level;

    public event UnityAction<int> LevelChanged;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;

        _player = Camera.main.GetComponent<Player>();
    }

    private void Start()
    {
        LevelChanged?.Invoke(_level);
    }

    private void ChangeBlockColor()
    {
        _color = _variants.ElementAtOrDefault(Random.Range(0, _variants.Count)).Color;
        _spriteRenderer.color = _color;
    }

    public void LevelUp()
    {
        _player.AddScore(_level * _scoreMultiplier);
        _level++;
        LevelChanged?.Invoke(_level);

        ChangeBlockColor();
    }
}
