/*
Used to authenticate google play and load up the leaderboard from google play console.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

using UnityEngine.SocialPlatforms;
using System.Runtime.Serialization.Formatters.Binary;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Authenticator : MonoBehaviour
{

    public bool connectedToGP;
    void Awake()
    {
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }
    GameController GC;
    void Start()
    {
        
        GC = FindObjectOfType<GameController>();
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }

    private void ProcessAuthentication(SignInStatus status)
    {
        if(status==SignInStatus.Success)
            connectedToGP = true;
        else
            connectedToGP = false;
    }

    public void LeaderBoard()
    {
        if(!connectedToGP)
            PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        else
            Social.ShowLeaderboardUI();

        if(connectedToGP)
        {
            Social.ReportScore(GC.currentscore, GPGSIds.leaderboard_dusk_runner, LeaderBoardUpdate);
            Social.ShowLeaderboardUI();
        }
    }

    private void LeaderBoardUpdate(bool sucess)
    {
        if(sucess)
            Debug.Log("Updated High Score");
        else
            Debug.Log("Failed to update High Score");
    }

}
