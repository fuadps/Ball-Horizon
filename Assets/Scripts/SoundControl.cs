using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public Sprite unMuteSprite;
    public Sprite muteSprite;
    public GameObject player;

    private bool isMute = false;

    public void MuteButton()
    {
        if (!isMute)
        {
            player.GetComponent<AudioSource>().enabled = false;
            gameObject.GetComponent<Image>().sprite = muteSprite;
            isMute = true;
        }
        else
        {
            player.GetComponent<AudioSource>().enabled = true;
            gameObject.GetComponent<Image>().sprite = unMuteSprite;
            isMute = false;
        }
    }
}
