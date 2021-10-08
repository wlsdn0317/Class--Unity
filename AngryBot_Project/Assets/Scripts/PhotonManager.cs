using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    readonly string version = "1.0";
    string userId = "Min";

    void Awake()
    {
        //������ Ŭ���̾�Ʈ�� �� �ڵ� ����ȭ �ɼ� ����
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version; //���ӹ���
        PhotonNetwork.NickName = userId;    //���� �г���

        //���� �������� ������ ���۷� üũ
        print(PhotonNetwork.SendRate);
        //���� ���� ����
        PhotonNetwork.ConnectUsingSettings();
    }

    //���� ������ ���� �� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnConnectedToMaster()
    {
        print("�������� �������� �����Ϳ���");
        print($"PhotonNetwork.InLoby = "+PhotonNetwork.InLobby);
        PhotonNetwork.JoinLobby();//�κ� ����
    }

    //���� �κ� ���� �� ȣ���Ǵ� �ݹ� �Լ�
    public override void OnJoinedLobby()
    {
        print("PhotonNetwork.InLoby = " + PhotonNetwork.InLobby);
        //������ ���� ã�� ���� �õ�
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("������ ����"+ returnCode + " : " + message);
        //print($"������ ���� { returnCode} : {message}");

        //���� ������ �� ���� ����
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20; //�� �ִ� ������ ��
        ro.IsOpen = true; // ����/����� ����
        ro.IsVisible = true; //�κ񿡼� �� ����� ���� �� ���� ������

        PhotonNetwork.CreateRoom("dia run 01",ro);
    }

    //�� ������ �Ϸ�Ǹ� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnCreatedRoom()
    {
        print("�� ���������!!!");
        print("�� ���̸��� = " + PhotonNetwork.CurrentRoom.Name);
    }

    //�濡 ������ �Ŀ� ȣ��Ǵ� �ݹ� �Լ�
    public override void OnJoinedRoom()
    {
        print("�� ���� ���� = " + PhotonNetwork.InRoom);
        print("���� ���� �� = " + PhotonNetwork.CurrentRoom.PlayerCount);

        //�濡 ������ ������ ������ PhotonNetwork.CurrentRoom.Players�� ��� ����
        foreach (var Player in PhotonNetwork.CurrentRoom.Players)
        {
            print("������ ������ �г��� = " + Player.Value.NickName);
        }

        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        PhotonNetwork.Instantiate("Player", points[idx].position, points[idx].rotation, 0);


    }

}
