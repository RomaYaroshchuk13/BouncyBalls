using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField]
    private List<SerializableKeyValuePair<TKey, TValue>> list = new List<SerializableKeyValuePair<TKey, TValue>>();
    private Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
    private bool isModify = false;
    public void OnAfterDeserialize()
    {
        if (!isModify)
        {
            dictionary.Clear();
            foreach (var pair in list)
            {
                dictionary[pair.Key] = pair.Value;
            }

            isModify = true;
        }
    }

    public void OnBeforeSerialize()
    {
        if (!isModify)
        {
            list.Clear();
            foreach (var pair in dictionary)
            {
                list.Add(new SerializableKeyValuePair<TKey, TValue>(pair.Key, pair.Value));
            }

            isModify = true;
        }
    }

    public TValue this[TKey key]
    {
        get { return dictionary[key]; }
        set { dictionary[key] = value; }
    }

    public void Add(TKey key, TValue value)
    {
        dictionary.Add(key, value);
    }

    public bool Remove(TKey key)
    {
        return dictionary.Remove(key);
    }

    public bool ContainsKey(TKey key)
    {
        return dictionary.ContainsKey(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return dictionary.TryGetValue(key, out value);
    }
}