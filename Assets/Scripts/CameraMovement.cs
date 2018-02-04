using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    [SerializeField] Transform target;
    Vector3 offset;

	void Start()
    {
        offset = target.transform.position - this.transform.position;
	}
	
	void Update()
    {
        if(target.gameObject.GetComponent<Player>().canmove)
        {
            Vector3 Requiredpos = target.transform.position - offset;
            this.transform.position = Vector3.Lerp(this.transform.position, Requiredpos, 1.5f);
        }
	}
}
