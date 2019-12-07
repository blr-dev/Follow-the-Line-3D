using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject gemPrefab;
    [SerializeField] GameObject startPlatformPrefab;
    float size;
    Vector3 lastpos;

    ObjectsPool platformsPool;

    void Start()
    {
        platformsPool = FindObjectOfType<ObjectsPool>();
        StartLevel();
    }

    void StartLevel()
    {
        platformsPool.Instantiate();
        size = platformsPool.prefab.transform.localScale.x;
        Instantiate(startPlatformPrefab, transform);
        InvokeRepeating("SpawnPlatform", 1f, 0.25f);
        lastpos = platformsPool.prefab.transform.position;
    }

    void SpawnPlatform()
    {
        if (Player.endGame == true)
        {
            CancelInvoke("SpawnPlatform");
        }
        var _platform = platformsPool.Instantiate();
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
        /*if (actualScore == 3)
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

        if (platformsColor_soundPlay)
        {
            Sound.instance.PlayAudio(2);
            platformsColor_soundPlay = false;
        }*/


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

    public void PrepareForFinalDestruction()
    {
        platformsPool.RecycleEverything();
    }

    void SpawnGem()
    {
        Instantiate(gemPrefab, lastpos + new Vector3(0f, 0.7f, 0f), gemPrefab.transform.rotation, transform);
    }
}
