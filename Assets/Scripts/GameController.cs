using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController instance;
    private float size;
    [SerializeField] GameObject platform;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject spawnPlatform;
    [SerializeField] GameObject player;
    [SerializeField] new Camera camera;
    Vector3 lastpos;
    public Button RestartButton;

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
        Player.endGame = false;
        Instantiate(player);
        Instantiate(camera);
        Instantiate(platform);
        Instantiate(spawnPlatform);
        RestartButton.gameObject.SetActive(false);
        RestartButton.onClick.AddListener(RestartGame);
        ClearPlayerCache();
        size = platform.transform.localScale.x;
        lastpos = platform.transform.position;
        InvokeRepeating("SpawnPlatform", 1f, 0.2f);
    }

    public void ClearScene()
    {
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
        Destroy(camera);
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
        if(Player.endGame == true)
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
            platformsColor = Color.grey;
        else if (actualScore == 7)
            platformsColor = Color.white;
        else if (actualScore == 10)
            platformsColor = Color.magenta;


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

