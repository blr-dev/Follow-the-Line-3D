using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Player : MonoBehaviour {

    static public bool endGame;

    private Rigidbody rb;
    private bool ismovingright = false;
    public bool fallDown;
	[HideInInspector] public bool canMove = true;
    [SerializeField] float speed = 4f;
    [SerializeField] GameObject particle;
    [SerializeField] Button RestartButton;

    [SerializeField] AudioSource audio;


    public void InitializePlayer()
    {
        endGame = false;
        audio = GameObject.Find("GemSound").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

	void Update()  
	{
		if(Input.GetMouseButtonDown (0) && canMove) 
		{
            ismovingright = !ismovingright;
            if (ismovingright)
            {
                rb.velocity = new Vector3(speed, 0f, 0f);
            }
            else
            {
                rb.velocity = new Vector3(0f, 0f, speed);
            }
        }

		if(Physics.Raycast (this.transform.position, Vector3.down * 2) == false) 
		{
			if(fallDown == false) FallDown();
		}
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameManager.instance.RestartLevel();
        }
        
	}


	public void FallDown()
	{
        fallDown = true;
        Sound.instance.PlayAudio(1);
        GameManager.instance.RestartButton.gameObject.SetActive(true);
        endGame = true;
		canMove = false;
        CancelInvoke("SpawnPlatform");
        rb.velocity = new Vector3(0f, -4f, 0f);
        if (PlayerPrefs.GetInt("HighScore") < PlayerPrefs.GetInt("Score"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Gem")
        {
            audio.Play();
            Destroy(col.gameObject);
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+1);
            GameObject _particle = Instantiate(particle, col.gameObject.transform.parent) as GameObject;
            _particle.transform.position = this.transform.position;
          //  FindObjectOfType<AudioManager>().Play("PickGem");
        }
    }
}
