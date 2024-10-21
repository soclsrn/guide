using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private UI_GamePopup gamePopup;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("������ ���� ����");
        PhotonNetwork.JoinLobby();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        gamePopup = FindObjectOfType<UI_GamePopup>();
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount == 2)
        {
            gamePopup.ready();
        }
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("�κ� ���� ����");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("�� ���� ����");
        Debug.Log("���ο� �� ����");
        RoomOptions option = new RoomOptions();
        option.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null,option);
    }

    public override void OnJoinedRoom()
    {
        gamePopup = FindObjectOfType<UI_GamePopup>();
        GameObject cam = GameObject.Find("Main Camera");
        Debug.Log("�� ���� ����");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if (playerCount == 1)
        {
            gamePopup.wait();
            cam.GetComponent<CameraControler>().setPlayer();
        }
        else
        {
            gamePopup.ready();
            cam.GetComponent<CameraControler>().setPlayer();
        }
    }
}
