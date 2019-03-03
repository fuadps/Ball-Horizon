using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class App_Initialize : MonoBehaviour
{
    public GameObject adButton;
    public GameObject inMenuUI;
    public GameObject inGameUI;
    public GameObject gameOverUI;
    public GameObject player;
    private bool hasGameStarted = false;
    private bool hasSeenRewardAd = false;

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        player.GetComponent<Player>().canControl = false;
        inMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void PlayButton()
    {
        if (hasGameStarted)
            StartCoroutine(StartGame(1.0f));
        else
            StartCoroutine(StartGame(0.0f));

    }

    public void PauseButton ()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        player.GetComponent<Player>().canControl = false;

        hasGameStarted = true;
        inMenuUI.SetActive(true);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOverButton ()
    {
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        player.GetComponent<Player>().canControl = false;

        hasGameStarted = false;
        inMenuUI.SetActive(false);
        inGameUI.SetActive(false);
        gameOverUI.SetActive(true);

        if (hasSeenRewardAd)
        {
            adButton.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            adButton.gameObject.GetComponent<Button>().enabled = false;
        }
    }

    public void ShowAd ()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
        

    }

    IEnumerator StartGame (float waitTime)
    {
        inMenuUI.SetActive(false);
        inGameUI.SetActive(true);
        gameOverUI.SetActive(false);
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<Player>().canControl = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;

    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                hasSeenRewardAd = true;
                StartCoroutine(StartGame(1.5f));
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
