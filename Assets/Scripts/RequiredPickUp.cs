using UnityEngine;

public class RequiredPickUp : PickUp
{
    private GameObject _finalDoor;
    private void Awake()
    {
        _finalDoor = GameObject.FindGameObjectWithTag("FinalDoor"); //CHECK FOR NO DOOR HERE
    }

    void CheckForPickupNumber()
    {
        if (GameManager.gameManagerInstance != null && PlayerData.Score == GameManager.gameManagerInstance.ScoreToWin)
        {
            _finalDoor.GetComponent<Animator>().SetTrigger("OpenDoor");
            _finalDoor.GetComponent<AudioSource>().Play();
        }
    }

    protected override void DoStuff()
    {
        PlayerData.UpdateScore();
        CheckForPickupNumber();
    }
}
