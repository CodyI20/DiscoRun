using UnityEngine; //Used for Debug.Log

public class PlayerData
{
    public const int MAX_LIVES = 3;
    private static int _score = 0;
    public static int Score
    {
        get
        {
            return _score;
        }
    }

    public static void UpdateScore()
    {
        _score++;
        //Debug.Log($"Updating score....{Score}");
    }

    public static void ResetPlayerData()
    {
        _score = 0;
        PlayerHealth.playerHealth.ResetPlayerLives();
    }
}
