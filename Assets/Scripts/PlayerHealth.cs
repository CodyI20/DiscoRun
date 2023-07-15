using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private static int _lives = PlayerData.MAX_LIVES;

    public static event Action OnPlayerDeath;
    public event Action OnPlayerDamageTaken;

    public int Lives
    {
        get
        {
            return _lives;
        }
    }
    [HideInInspector] public static PlayerHealth playerHealth { get; private set; }

    void Awake()
    {
        if (playerHealth == null)
            playerHealth = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResetPlayerLives()
    {
        _lives = PlayerData.MAX_LIVES;
    }
    private void GainExtraLife()
    {
        _lives++;
    }
    public void TakeDamage()
    {
        _lives--;
        OnPlayerDeath?.Invoke();
    }

    void OnDestroy()
    {
        playerHealth = null;
    }
}
