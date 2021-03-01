using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> _slots;
    [SerializeField] private List<GameObject> _prefubs;
    [SerializeField] private List<GameObject> _pool;
    [SerializeField] private GameObject _container;

    public List<GameObject> Pool => _pool;
    public List<ItemSlot> Slots => _slots;

    public event UnityAction PlaceIsOver;

    public void Spawn()
    {
        if (TryGetObject(out ItemSlot slot))
        {
            GameObject spawned = Instantiate(_prefubs.ElementAtOrDefault(Random.Range(0, _prefubs.Count)), slot.transform.position, Quaternion.identity);
            spawned.transform.SetParent(_container.transform);
            _pool.Add(spawned);

            spawned.GetComponent<DragAndDrop>().Destroied += OnBlockDestroyed;

            if (_pool.Count == _slots.Count)
            {
                PlaceIsOver?.Invoke();
            }
        }     
    }

    private void OnBlockDestroyed(GameObject block)
    {
        block.GetComponent<DragAndDrop>().Destroied -= OnBlockDestroyed;
        _pool.Remove(block);
    }

    private bool TryGetObject(out ItemSlot result)
    {
        List<ItemSlot> slots = _slots.Where(slot => slot.IsEmpty == true).ToList();

        result = slots.ElementAtOrDefault(Random.Range(0, slots.Count));

        return result != null;
    }
}
