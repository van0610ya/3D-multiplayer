using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public MatchSettings matchSettings;

    [SerializeField]
    private GameObject sceneCamera;

    void Awake ()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameManager in scene.");
        } else
        {
            instance = this;
        }
    }

    public void SetSceneCameraActive(bool isActive)
    {
        if (sceneCamera == null)
            return;

        sceneCamera.SetActive(isActive);
    }

    #region Player tracking

    private const string PLAYER_ID_PREFIX = "Player";

    private static Dictionary<string, Player> players = new Dictionary<string, Player>();

    public static void RegisterPlayer (string _netID, Player _player)
    {
        string _playerID = PLAYER_ID_PREFIX + _netID;
        players.Add(_playerID, _player);
        _player.transform.name = _playerID;
    }

    public static void UnRegisterPlayer (string _playerID)
    {
        players.Remove(_playerID);
    }

    public static Player GetPlayer (string _playerID)
    {
        return players[_playerID];
    }
   

    
        
       // void OnGUI()
    //{
      //  GUILayout.BeginArea(new Rect(0f, 300f, 100f, 200f));
      //  foreach (KeyValuePair<string, GameObject> _player in players)
      //  {
       //     GUILayout.Box(_player.Key + "   " + _player.Value.name);
       // }
      //  GUILayout.EndArea();
   // }
    #endregion

}
