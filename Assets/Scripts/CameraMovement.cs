using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField] Player target;
    Vector3 offset;

    public void InitializeCameraMovement(Player target)
    {
        this.target = target;
        offset = this.target.transform.position - transform.position;
    }
	
	void Update()
    {
        if(target.canMove)
        {
            var newPosition = target.transform.position - offset;
            transform.position = newPosition;
        }
	}
}
