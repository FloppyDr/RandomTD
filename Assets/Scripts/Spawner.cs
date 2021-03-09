using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : Pool
{
    [SerializeField] private List<Block> _spawnedBlocks;
    [SerializeField] private GameObject _container;

    public List<Block> SpawnedBlocks => _spawnedBlocks;

    public event UnityAction PlaceIsOver;

    public void Spawn()
    {
        if (TryGetObject(out ItemSlot slot))
        {
            GameObject spawned = Instantiate(_prefubs.ElementAtOrDefault(Random.Range(0, _prefubs.Count)), slot.transform.position, Quaternion.identity);
            spawned.transform.SetParent(_container.transform);
            Block block = spawned.GetComponent<Block>();
            _spawnedBlocks.Add(block);

            spawned.GetComponent<DragAndDrop>().Destroied += OnBlockDestroyed;

            if (_spawnedBlocks.Count == _slots.Count)
            {
                PlaceIsOver?.Invoke();
            }
        }     
    }

    private void OnBlockDestroyed(Block block)
    {
        block.GetComponent<DragAndDrop>().Destroied -= OnBlockDestroyed;
        _spawnedBlocks.Remove(block);
    }
}
