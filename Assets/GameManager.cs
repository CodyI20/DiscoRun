using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance { get; private set; }
    private HashSet<RequiredPickUp> _allRequiredPickUpsInScene;
    private int _scoreToWin;


    /// <summary>
    /// These variables are static so that they persist through scene changes. This is due to the fact that the GameManager is unique
    /// </summary>
    private static GameObject _overlayUI;
    private static bool _overlayUIActive = false;
    ///
    public int ScoreToWin
    {
        get
        {
            return _scoreToWin;
        }
    }

    private void Awake()
    {
        Debug.Log("AWAKING");
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
            DontDestroyOnLoad(gameObject);
            PlayerHealth.OnPlayerDeath += PlayerDied;
            //PlayerHealth.playerHealth.OnPlayerDamageTaken += PlayerTookDamage;
        }
        else
        {
            Destroy(gameObject);
        }
        _overlayUI = GameObject.FindGameObjectWithTag("OverlayUI");
        _overlayUI.SetActive(false);
        _overlayUIActive = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        _scoreToWin = CountAllRequiredPickUps();
        //PlayerHealth.playerHealth.OnPlayerDamageTaken += PlayerTookDamage;
    }

    void PlayerTookDamage()
    {
        LevelLoader.levelLoaderInstance.ReloadCurrentScene();
    }

    void PlayerDied()
    {
        if (PlayerHealth.playerHealth.Lives > 0)
        {
            LevelLoader.levelLoaderInstance.ReloadCurrentScene();
        }
        else
        {
            PlayerData.ResetPlayerData();
            LevelLoader.levelLoaderInstance.LoadGameOver();
        }
    }

    int CountAllRequiredPickUps()
    {
        _allRequiredPickUpsInScene = new HashSet<RequiredPickUp>(FindObjectsOfType<RequiredPickUp>());
        return _allRequiredPickUpsInScene.Count;
    }

    public void ToggleOverlayUI()
    {
        if (_overlayUI != null)
        {
            _overlayUIActive = !_overlayUIActive;
            _overlayUI.SetActive(_overlayUIActive);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleOverlayUI();
        }
    }

    private void OnDestroy()
    {
        if (gameManagerInstance == this)
        {
            gameManagerInstance = null;
        }
        PlayerHealth.OnPlayerDeath -= PlayerDied;//unsubscribe
        if (PlayerHealth.playerHealth != null)
        {
            Debug.Log("UnSubbing");
            PlayerHealth.playerHealth.OnPlayerDamageTaken -= PlayerTookDamage;
        }
    }
}
