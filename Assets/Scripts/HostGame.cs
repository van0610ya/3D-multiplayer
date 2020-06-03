using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HostGame : MonoBehaviour
{
    [SerializeField]
    private uint roomSize = 6;

    private string roomName;

    private NetworkManager networkManager;

    public string Username;
    public InputField nameInput;
    public Text nameText;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            NetworkManager.singleton.StartMatchMaker();
        }
    }

    public void SetRoomName (string _name)

    {
        roomName = _name;
    }

    public void CreateRoom ()
    {
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creating Room: " + roomName + " with room for " + roomSize + " players.");
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
    }

    public void SetName()
    {
        if (nameInput.text.Length >= 2)
        {
            Username = nameInput.text;
            nameText.text = Username;

            PlayerPrefs.SetString("username", Username);
            PlayerPrefs.Save();
        }
        Debug.Log("Name is too short");

    }
}
