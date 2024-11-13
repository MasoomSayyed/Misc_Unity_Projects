using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSound : MonoBehaviour
{
    private Player player;
    private float footstepsTimer;
    private float footstepsTimerMax = .1f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        footstepsTimer -= Time.deltaTime;
        if(footstepsTimer < 0f)
        {
            if(player.IsWalking())
           { 
                footstepsTimer = footstepsTimerMax;
                float volume = 100f;
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);
            }
        }
    }
}
