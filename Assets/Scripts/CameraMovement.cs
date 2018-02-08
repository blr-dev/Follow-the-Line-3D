using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    [SerializeField] GameObject target;
    Vector3 offset;

    public void InitializeCameraMovement(GameObject GameObject)
    {
        target = GameObject;
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player").gameObject;

        offset = target.transform.position - transform.position;
    }
	
	void Update()
    {
        if(target.GetComponent<Player>().canmove)
        {
            Vector3 Requiredpos = target.transform.position - offset;
            transform.position = Requiredpos;
            //transform.position = Vector3.Lerp(transform.position, Requiredpos, 1.5f);
        }
	}
}
