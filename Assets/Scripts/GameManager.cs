using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private float size;
    [Header("Referencje")]
    [SerializeField] Player pc; // pc - player character
    [SerializeField] CameraMovement cscript; // camera script
    public GameObject playerObj;
    public GameObject cameraObj;

    [Header("Prefaby")]
    [SerializeField] GameObject platform;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject spawnPlatform;
    [SerializeField] GameObject player;
    [SerializeField] GameObject cam;
    Vector3 lastpos;
    public Button RestartButton;
    public bool platformsColor_soundPlay;

    public Color platformsColor;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        playerObj = Instantiate(player);
        pc = playerObj.GetComponent<Player>();
        pc.InitializePlayer();

        cameraObj = Instantiate(cam);
        cscript = cameraObj.GetComponent<CameraMovement>();
        cscript.InitializeCameraMovement(playerObj);
        

        
        Instantiate(platform);
        Instantiate(spawnPlatform);
        RestartButton.gameObject.SetActive(false);
        RestartButton.onClick.AddListener(RestartGame);
        ClearPlayerCache();
        size = platform.transform.localScale.x;
        lastpos = platform.transform.position;
        InvokeRepeating("SpawnPlatform", 1f, 0.25f);
    }

    public void ClearScene()
    {
        Sound.instance.PlayAudio(0);
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Platform"))
        {
            Destroy(o);
        }
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Gem"))
        {
            Destroy(o);
        }
        Destroy(player);
        Destroy(spawnPlatform);
        DestroyImmediate(platform);
        RestartButton.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        ClearScene();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        InitializeGame();
    }

    private void ClearPlayerCache()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("EndGame");
    }

    private void SpawnPlatform()
    {
        if (Player.endGame == true)
        {
            CancelInvoke("SpawnPlatform");
        }
        var _platform = Instantiate(platform);
        /*
        switch (PlayerPrefs.GetInt("Score"))
        {
            case 1..4: { setColor = Color.red; break;  }
            case 2: { setColor = Color.blue; break; }
            case 3: { setColor = Color.green; break; }
            case 4: { setColor = Color.black; break; }
        }
        */
        var actualScore = PlayerPrefs.GetInt("Score");
        if (actualScore == 3)
        {
            platformsColor_soundPlay = true;
            platformsColor = Color.grey;
        }
        else if (actualScore == 7)
        {
            platformsColor = Color.white;
            platformsColor_soundPlay = true;
        }
        else if (actualScore == 10)
        {
            platformsColor_soundPlay = true;
            platformsColor = Color.magenta;
        }

        if(platformsColor_soundPlay)
        {
            Sound.instance.PlayAudio(2);
            platformsColor_soundPlay = false;
        }


        int random = Random.Range(1, 11);
        if (random < 5)
        {
            if (random < 3)
                SpawnGem();
            _platform.transform.position = lastpos + new Vector3(size, 0f, 0f);
        }
        if (random >= 5)
        {
            _platform.transform.position = lastpos + new Vector3(0f, 0f, size);
        }
        lastpos = _platform.transform.position;
    }

    private void SpawnGem()
    {
        Instantiate(gem, lastpos + new Vector3(0f, 0.7f, 0f), gem.transform.rotation);
    }
}

