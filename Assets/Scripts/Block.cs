using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Block : MonoBehaviour
{
    [SerializeField] private List<GameObject> _hand;
    [SerializeField] private Player _player;

    private SpriteRenderer _spriteRenderer;
    private int _level = 0;



    public int Level => _level;

    public event UnityAction<int> LevelChanged;


    private void OnBecameVisible()
    {
        LevelChanged?.Invoke(_level);
    }

    private void Start()
    {
        _player = Camera.main.GetComponent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    public void LevelUp()
    {
        _player.AddScore(_level*2);
        _level++;
        LevelChanged?.Invoke(_level);

        ChangeBlock();
    }


    private void ChangeBlock()
    {
        _spriteRenderer.color = _hand.ElementAtOrDefault(Random.Range(0, _hand.Count)).GetComponent<SpriteRenderer>().color;
    }
}
