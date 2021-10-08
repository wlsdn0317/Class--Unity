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
        //마스터 클라이언트의 씬 자동 동기화 옵션 설정
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = version; //게임버전
        PhotonNetwork.NickName = userId;    //게임 닉네임

        //포톤 서버와의 데이터 전송률 체크
        print(PhotonNetwork.SendRate);
        //포톤 서버 접속
        PhotonNetwork.ConnectUsingSettings();
    }

    //포톤 서버에 접속 후 호출되는 콜백 함수
    public override void OnConnectedToMaster()
    {
        print("접속했음 누구에게 마스터에게");
        print($"PhotonNetwork.InLoby = "+PhotonNetwork.InLobby);
        PhotonNetwork.JoinLobby();//로비에 접속
    }

    //포톤 로비에 접속 후 호툴되는 콜백 함수
    public override void OnJoinedLobby()
    {
        print("PhotonNetwork.InLoby = " + PhotonNetwork.InLobby);
        //랜덤한 방을 찾아 접속 시도
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        print("방접속 실패"+ returnCode + " : " + message);
        //print($"방접속 실패 { returnCode} : {message}");

        //새로 생성할 방 정보 설정
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 20; //방 최대 접속자 수
        ro.IsOpen = true; // 공개/비공개 유무
        ro.IsVisible = true; //로비에서 룸 목록을 노출 할 건지 말건지

        PhotonNetwork.CreateRoom("dia run 01",ro);
    }

    //방 생성이 완료되면 호출되는 콜백 함수
    public override void OnCreatedRoom()
    {
        print("방 만들어졌어!!!");
        print("내 방이름은 = " + PhotonNetwork.CurrentRoom.Name);
    }

    //방에 입장한 후에 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        print("방 접속 유무 = " + PhotonNetwork.InRoom);
        print("접속 유저 수 = " + PhotonNetwork.CurrentRoom.PlayerCount);

        //방에 접속한 유저의 정보는 PhotonNetwork.CurrentRoom.Players가 들고 있음
        foreach (var Player in PhotonNetwork.CurrentRoom.Players)
        {
            print("접속한 유저의 닉네임 = " + Player.Value.NickName);
        }

        Transform[] points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();
        int idx = Random.Range(1, points.Length);

        PhotonNetwork.Instantiate("Player", points[idx].position, points[idx].rotation, 0);


    }

}
