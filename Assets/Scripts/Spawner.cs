using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<ItemSlot> _slots;
    [SerializeField] private List<GameObject> _prefubs;

    public void Spawn()
    {
        if (TryGetObject(out ItemSlot slot))
        {
            Instantiate(_prefubs.ElementAtOrDefault(Random.Range(0, _prefubs.Count)), slot.transform.position, Quaternion.identity); ;
        }
        else
        {
            Debug.Log("No empty slots");
        }

        //int randomIndex = Random.Range(0, _slots.Count);

        //if (_slots[randomIndex].IsEmpty)
        //{
        //    Instantiate(_prefub, _slots[randomIndex].transform);
        //}
        //else
        //{
        //     Debug.Log("No empty slots");
        //}

    }


    private bool TryGetObject(out ItemSlot result)
    {
        List<ItemSlot> slots = _slots.Where(slot => slot.IsEmpty == true).ToList();

        result = slots.ElementAtOrDefault(Random.Range(0, slots.Count));

        return result != null;
    }
}
