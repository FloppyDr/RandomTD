using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : Pool
{


    [SerializeField] private List<GameObject> _spawnedBlocks;
    [SerializeField] private GameObject _container;

    public List<GameObject> SpawnedBlocks => _spawnedBlocks;

    public event UnityAction PlaceIsOver;

    public void Spawn()
    {
        if (TryGetObject(out ItemSlot slot))
        {
            GameObject spawned = Instantiate(_prefubs.ElementAtOrDefault(Random.Range(0, _prefubs.Count)), slot.transform.position, Quaternion.identity);
            spawned.transform.SetParent(_container.transform);
            _spawnedBlocks.Add(spawned);

            spawned.GetComponent<DragAndDrop>().Destroied += OnBlockDestroyed;

            if (_spawnedBlocks.Count == _slots.Count)
            {
                PlaceIsOver?.Invoke();
            }
        }     
    }

    private void OnBlockDestroyed(GameObject block)
    {
        block.GetComponent<DragAndDrop>().Destroied -= OnBlockDestroyed;
        _spawnedBlocks.Remove(block);
    }
}
