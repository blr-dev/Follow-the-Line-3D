using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class ObjectsPool:MonoBehaviour
{
    public GameObject prefab;
    Stack<GameObject> activeObjects = new Stack<GameObject>();
    Stack<GameObject> inactiveObjects = new Stack<GameObject>();


    internal void RecycleEverything()
    {
        while (activeObjects.Any())
        {
            var go = activeObjects.Pop();
            go.SetActive(false);
            inactiveObjects.Push(go);
        }
    }

    public GameObject Instantiate()
    {
        if (inactiveObjects.Count>0)
            return TakeObjectFromPoolAndActivate();
        var go = Instantiate(prefab, transform);
        activeObjects.Push(go);
        return go;
    }

    GameObject TakeObjectFromPoolAndActivate()
    {
        var go = inactiveObjects.Pop();
        activeObjects.Push(go);
        go.gameObject.SetActive(true);
        go.transform.position = prefab.transform.position;
        go.transform.rotation = prefab.transform.rotation;
        go.GetComponentInParent<Rigidbody>().isKinematic = true;
        return go;
    }
}