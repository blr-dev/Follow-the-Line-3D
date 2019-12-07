using UnityEngine.UI;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [Header("Referencje")]
    [SerializeField] Player player;
    [SerializeField] CameraMovement camera;
    [SerializeField] Map map;

    [Header("Prefaby")]
    [SerializeField] Player playerPrefab;
    [SerializeField] CameraMovement cameraPrefab;
    [SerializeField] Map mapPrefab;

    public Button RestartButton;
    public bool platformsColor_soundPlay;
    public Color platformsColor;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartLevel();
        RestartButton.onClick.AddListener(RestartLevel);
    }

    public void RestartLevel()
    {
        ClearLevel();
        StartLevel();
    }

    void StartLevel()
    {
        player = Instantiate(playerPrefab);
        player.InitializePlayer();
        camera = Instantiate(cameraPrefab);
        camera.InitializeCameraMovement(player);
        map = Instantiate(mapPrefab);
        RestartButton.gameObject.SetActive(false);
        ClearPlayerCache();
        
    }

    void ClearLevel()
    {
        Sound.instance.PlayAudio(0);
        map.PrepareForFinalDestruction();
        Destroy(map.gameObject);
        Destroy(player.gameObject);
        Destroy(camera.gameObject);
        RestartButton.gameObject.SetActive(false);
        map = null;
    }

    private void ClearPlayerCache()
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("EndGame");
    }

    
}

