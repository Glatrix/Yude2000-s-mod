// Decompiled with JetBrains decompiler
// Type: PhasmophobiaGUI.Cheat
// Assembly: PhasmophobiaGUI, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0967AAEE-F31B-4649-99E8-D66F4327D3A0
// Assembly location: C:\Users\Ry\Desktop\New folder\PhasmophobiaGUI.dll

using ExitGames.Demos.DemoPunVoice;
using Photon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;

namespace PhasmophobiaGUI
{
  public class Cheat : MonoBehaviour
  {
    private string textArea;
    private string textArea2;
    private string textArea3;
    private string textArea4;
    private string Name;
    private string serverName;
    private string roomName;
    private string steamID;
    private bool antikick;
    private bool noclip;
    private bool noclip2;
    private bool showGUI;
    private bool showGUI2;
    private bool carAlarmOn;
    private bool SpeedHack;
    private bool SpeedHack2;
    private bool GhostESP;
    private bool PlayerESP;
    private bool KeyESP;
    private bool OuijaESP;
    private bool EvidenceESP;
    private bool KeybindSpeed;
    private bool KeybindNoclip;
    private bool KeybindRandom;
    private bool KeybindHunt;
    private bool KeybindIdle;
    private bool KeybindWander;
    private bool ActivateStats;
    private bool ShowInfoPlayer;
    private bool ShowInfoGhost;
    private bool ShowInfoRoom;
    private bool ShowWatermark;
    private bool ShowItemList;
    private bool ShowMaster;
    private bool forcehost;
    private bool NoFog;
    private bool Fullbright;
    private bool ghostold;
    private bool isPrivateServer;
    private bool ShowGUIKey;
    private bool Showtalkingplayers;
    private bool showabusiveoptions;
    public float movementForwardMultiplier;
    public float movementSideMultiplier;
    private float serverSlots;
    private int selectedPlayer;
    private int myplayerinlist;
    private int characterindex;
    private PostProcessProfile mainProfile;
    private int selecteditem;
    private Vector2 scrollViewVector;
    public Rect dropDownRect;
    public Rect dropDownRect2;
    private GUIStyle guiStyle;
    public string[] allitems;
    public static ServerManager serverManager;
    public static GhostAI ghostAI;
    public static List<GhostAI> ghosts;
    public static ExitLevel exitLevel;
    public static GhostInfo ghostInfo;
    public static HandCamera handCamera;
    public static InventoryManager inventoryManager;
    public static LiftButton liftButton;
    public static GameController gameController;
    public static ItemSpawner itemSpawner;
    public static Player player;
    public static OuijaBoard ouijaBoard;
    public static List<OuijaBoard> ouijaBoards;
    public static HuntingState huntingstate;
    public static GhostInteraction ghostInteraction;
    public static StateMachine stateMachine;
    public static PCMenu pCMenu;
    public static WalkieTalkie walkieTalkie;
    public static PhotonView photonView;
    public static Light light;
    public static GhostAudio ghostAudio;
    public static KillPlayerState killPlayerState;
    public static Contract contract;
    public static LevelSelectionManager levelSelectionManager;
    public static List<LightSwitch> lightSwitches;
    public static LightSwitch lightSwitch;
    public static Rigidbody rigidbody;
    public static BaseController baseController;
    public static GhostEventPlayer ghostEventPlayer;
    public static GhostController ghostController;
    public static DeadPlayer deadPlayer;
    public static GhostTraits ghostTraits;
    public static LevelController levelController;
    public static FuseBox fuseBox;
    public static List<Torch> torches;
    public static List<Door> doors;
    public static List<Light> lights;
    public static List<Contract> contracts;
    public static List<InventoryItem> items;
    public static List<FriendInfo> friends;
    public static List<Key> keys;
    public static List<DNAEvidence> dNAEvidences;

    private void Start()
    {
      Utils.CreateConsole();
      new Thread((ThreadStart) (() =>
      {
        while (true)
        {
          this.StartCoroutine(this.CollectGameObjects());
          Thread.Sleep(5000);
        }
      })).Start();
      Console.WriteLine("PhasmophobiaGUI v1.5 by Yude2000 initialized");
    }

    private void Update()
    {
      this.StartCoroutine(this.KeyHandler());
      if (PhotonNetwork.get_isMasterClient() || !this.forcehost)
        return;
      if (Object.op_Inequality((Object) Cheat.serverManager, (Object) null) && ((PhotonPlayer) this.PlayerSpots[this.myplayerinlist].player).IsLocal != null)
        PhotonNetwork.SetMasterClient((PhotonPlayer) this.PlayerSpots[this.myplayerinlist].player);
      PhotonNetwork.SetMasterClient((PhotonPlayer) ((PlayerData) ((GameController) GameController.instance).myPlayer).photonPlayer);
    }

    private void OnGUI()
    {
      GUI.set_color(Color.get_green());
      if (this.ShowWatermark)
      {
        GUI.Label(new Rect(10f, 45f, 150f, 20f), "PhasmophobiaGUI v1.5");
        GUI.Label(new Rect(10f, 60f, 150f, 20f), "by Yude2000");
      }
      GUI.set_color(Color.get_white());
      if (this.ShowMaster)
      {
        if (GUI.Button(new Rect(320f, 0.0f, 200f, 20f), "Set Master Client"))
        {
          if (Object.op_Inequality((Object) Cheat.serverManager, (Object) null))
            PhotonNetwork.SetMasterClient((PhotonPlayer) this.PlayerSpots[this.myplayerinlist].player);
          PhotonNetwork.SetMasterClient((PhotonPlayer) ((PlayerData) ((GameController) GameController.instance).myPlayer).photonPlayer);
        }
        if (Object.op_Inequality((Object) Cheat.gameController, (Object) null) && GUI.Toggle(new Rect(320f, 25f, 200f, 20f), this.forcehost, "Force Host") != this.forcehost)
          this.forcehost = !this.forcehost;
      }
      if (Object.op_Inequality((Object) Cheat.serverManager, (Object) null))
      {
        if (this.selectedPlayer >= this.PlayerSpots.Count)
          this.selectedPlayer = 0;
        if (this.PlayerSpots[this.selectedPlayer].player == null)
          GUI.Label(new Rect(120f, 0.0f, 200f, 20f), "Selected: None");
        if (this.PlayerSpots[this.selectedPlayer].player != null)
          GUI.Label(new Rect(120f, 0.0f, 500f, 20f), "Selected: " + ((PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player).get_NickName().ToString());
        for (int index = 0; index < this.PlayerSpots.Count; ++index)
        {
          if (((PhotonPlayer) this.PlayerSpots[index].player).IsLocal != null)
            this.myplayerinlist = index;
          if (GUI.Button(new Rect(120f, (float) (25 + index * 25), 200f, 20f), ((PhotonPlayer) this.PlayerSpots[index].player).get_NickName() ?? ""))
            this.selectedPlayer = index;
        }
        if (GUI.Button(new Rect(120f, (float) (50 + this.PlayerSpots.Count * 25), 200f, 20f), "Kick Player"))
          ((PhotonView) Cheat.serverManager.view).RPC("LeaveServer", (PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player, new object[1]
          {
            (object) true
          });
        if (GUI.Button(new Rect(120f, (float) (75 + this.PlayerSpots.Count * 25), 200f, 20f), "Force Ready"))
          ((PhotonView) Cheat.serverManager.view).RPC("NetworkedReady", (PhotonTargets) 6, new object[1]
          {
            (object) this.PlayerSpots[this.selectedPlayer].player
          });
        if (GUI.Button(new Rect(120f, (float) (100 + this.PlayerSpots.Count * 25), 200f, 20f), "Change Character"))
        {
          ++this.characterindex;
          if (this.characterindex >= 8)
            this.characterindex = 0;
          ((PhotonView) Cheat.serverManager.view).RPC("UpdateCharacter", (PhotonTargets) 6, new object[2]
          {
            (object) this.PlayerSpots[this.selectedPlayer].player,
            (object) this.characterindex
          });
        }
        if (GUI.Button(new Rect(120f, (float) (125 + this.PlayerSpots.Count * 25), 200f, 20f), "Spawn Dead Ragdoll"))
          (!Object.op_Inequality((Object) ((Player) this.PlayerSpots[this.selectedPlayer].myPlayer).VRIKObj, (Object) null) ? (DeadPlayer) PhotonNetwork.InstantiateSceneObject("DeadPlayerRagdoll", ((Component) this).get_transform().get_position(), ((Component) this.PlayerSpots[this.selectedPlayer].myPlayer).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<DeadPlayer>() : (DeadPlayer) PhotonNetwork.InstantiateSceneObject("DeadPlayerRagdoll", ((GameObject) ((Player) this.PlayerSpots[this.selectedPlayer].myPlayer).headObject).get_transform().get_position(), ((Component) this.PlayerSpots[this.selectedPlayer].myPlayer).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<DeadPlayer>()).Spawn((int) ((Player) this.PlayerSpots[this.selectedPlayer].myPlayer).modelID, ((PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player).get_ID());
        if (GUI.Button(new Rect(120f, (float) (150 + this.PlayerSpots.Count * 25), 200f, 20f), "Set Master"))
          PhotonNetwork.SetMasterClient((PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player);
        if (GUI.Button(new Rect(120f, (float) (175 + this.PlayerSpots.Count * 25), 200f, 20f), "Freeze Game"))
          PhotonNetwork.DestroyPlayerObjects((PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player);
        if (this.showabusiveoptions)
        {
          if (GUI.Button(new Rect(120f, (float) (200 + this.PlayerSpots.Count * 25), 200f, 20f), "[!] Give Items [!]"))
          {
            using (List<InventoryItem>.Enumerator enumerator = Cheat.items.GetEnumerator())
            {
              while (enumerator.MoveNext())
                enumerator.Current.ChangeTotalAmount(((PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player).get_ID(), -5000000);
            }
          }
          if (GUI.Button(new Rect(120f, (float) (225 + this.PlayerSpots.Count * 25), 200f, 20f), "[!] Give Money (loses items) [!]"))
          {
            using (List<InventoryItem>.Enumerator enumerator = Cheat.items.GetEnumerator())
            {
              while (enumerator.MoveNext())
                enumerator.Current.ChangeTotalAmount(((PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player).get_ID(), 5000000);
            }
          }
          if (GUI.Button(new Rect(120f, (float) (250 + this.PlayerSpots.Count * 25), 200f, 20f), "[!] Destroy Stats [!]"))
          {
            using (List<InventoryItem>.Enumerator enumerator = Cheat.items.GetEnumerator())
            {
              while (enumerator.MoveNext())
                enumerator.Current.ChangeTotalAmount(((PhotonPlayer) this.PlayerSpots[this.selectedPlayer].player).get_ID(), int.MaxValue);
            }
          }
        }
        if (GUI.Toggle(new Rect(120f, (float) (275 + this.PlayerSpots.Count * 25), 200f, 20f), this.showabusiveoptions, "Show Abusive Options") != this.showabusiveoptions)
          this.showabusiveoptions = !this.showabusiveoptions;
      }
      if (Object.op_Equality((Object) Cheat.levelController, (Object) null))
      {
        GUI.SetNextControlName("changename");
        this.Name = GUI.TextArea(new Rect(320f, 25f, 200f, 20f), this.Name);
        if (GUI.Button(new Rect(320f, 45f, 200f, 20f), "Change Name"))
        {
          GUI.FocusControl("changename");
          PhotonNetwork.get_player().set_NickName(this.Name);
        }
        if (GUI.Button(new Rect(320f, 70f, 200f, 20f), "Kick All"))
        {
          using (List<PlayerServerSpot>.Enumerator enumerator = this.PlayerSpots.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              PlayerServerSpot current = enumerator.Current;
              if (((PhotonPlayer) current.player).IsLocal == null)
                ((PhotonView) Cheat.serverManager.view).RPC("LeaveServer", (PhotonPlayer) current.player, new object[1]
                {
                  (object) true
                });
            }
          }
        }
        if (GUI.Button(new Rect(320f, 95f, 200f, 20f), "Fill Lobby w/ Boxes"))
        {
          for (int index = 0; index < 50; ++index)
          {
            if (PhotonNetwork.get_inRoom())
              PhotonNetwork.InstantiateSceneObject("BoxFlashPrefab", ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().get_position(), Quaternion.get_identity(), (byte) 0, (object[]) null);
          }
        }
        if (GUI.Button(new Rect(320f, 120f, 200f, 20f), "Spawn Random Ghost"))
        {
          if (Random.Range(0, 2) == 0)
          {
            string maleGhostName = (string) Constants.maleGhostNames[Random.Range(0, Constants.maleGhostNames.Length)];
            if (PhotonNetwork.get_inRoom())
              ((GhostAI) PhotonNetwork.InstantiateSceneObject(maleGhostName, ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<GhostAI>()).Appear(false);
          }
          else
          {
            string femaleGhostName = (string) Constants.femaleGhostNames[Random.Range(0, Constants.femaleGhostNames.Length)];
            if (PhotonNetwork.get_inRoom())
              ((GhostAI) PhotonNetwork.InstantiateSceneObject(femaleGhostName, ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<GhostAI>()).Appear(false);
          }
        }
        if (GUI.Button(new Rect(320f, 145f, 200f, 20f), "Force Start"))
          Cheat.serverManager.StartGame();
        if (GUI.Button(new Rect(320f, 170f, 200f, 20f), "Set Contracts Professional"))
        {
          for (int index = 0; index < ((List<Contract>) Cheat.levelSelectionManager.currentContracts).Count; ++index)
            ((List<Contract>) Cheat.levelSelectionManager.currentContracts)[index].levelDiffulty = (__Null) 2;
        }
        if (GUI.Button(new Rect(320f, 195f, 200f, 20f), "Max Equipment"))
        {
          using (List<InventoryItem>.Enumerator enumerator = Cheat.items.GetEnumerator())
          {
            while (enumerator.MoveNext())
              enumerator.Current.ChangeTotalAmount(-1337, 10);
          }
        }
        if (GUI.Toggle(new Rect(320f, 220f, 200f, 20f), this.antikick, "Anti Kick [not stable]") != this.antikick)
        {
          this.antikick = true;
          ((List<string>) ((ServerSettings) PhotonNetwork.PhotonServerSettings).RpcList).Remove("LeaveServer");
        }
        if (GUI.Toggle(new Rect(320f, 245f, 200f, 20f), this.forcehost, "Force Host") != this.forcehost)
          this.forcehost = !this.forcehost;
        GUI.Label(new Rect(520f, 0.0f, 100f, 20f), "Money: $" + FileBasedPrefs.GetInt("PlayersMoney", 0).ToString());
        GUI.Label(new Rect(520f, 25f, 125f, 20f), "Level: " + (FileBasedPrefs.GetInt("myTotalExp", 0) / 100).ToString());
        if (GUI.Button(new Rect(520f, 50f, 200f, 20f), "Add 100$"))
          FileBasedPrefs.SetInt("PlayersMoney", FileBasedPrefs.GetInt("PlayersMoney", 0) + 100);
        if (GUI.Button(new Rect(520f, 75f, 200f, 20f), "Add 1 Level"))
          FileBasedPrefs.SetInt("myTotalExp", FileBasedPrefs.GetInt("myTotalExp", 0) + 100);
        if (GUI.Button(new Rect(520f, 150f, 200f, 20f), "Reset Daily Challenges"))
          DailyChallengesController.get_Instance().ForceReset();
        if (!PhotonNetwork.get_inRoom())
        {
          GUI.Label(new Rect(720f, 0.0f, 200f, 20f), "Custom Room Creator:");
          this.serverName = GUI.TextArea(new Rect(720f, 25f, 200f, 20f), this.serverName);
          this.serverSlots = GUI.HorizontalSlider(new Rect(720f, 50f, 200f, 20f), (float) (int) this.serverSlots, 4f, 90f);
          GUI.Label(new Rect(720f, 65f, 200f, 20f), "Slots: " + ((int) this.serverSlots).ToString());
          if (GUI.Toggle(new Rect(720f, 80f, 200f, 20f), this.isPrivateServer, "Private Room") != this.isPrivateServer)
            this.isPrivateServer = !this.isPrivateServer;
          if (GUI.Button(new Rect(720f, 105f, 200f, 20f), "Create Custom Room"))
          {
            int num;
            if (this.isPrivateServer)
            {
              PlayerPrefs.SetInt("isPublicServer", 0);
              RoomOptions roomOptions1 = new RoomOptions();
              roomOptions1.set_IsOpen(true);
              roomOptions1.set_IsVisible(false);
              roomOptions1.MaxPlayers = (__Null) (int) Convert.ToByte((int) this.serverSlots);
              roomOptions1.PlayerTtl = (__Null) 2000;
              RoomOptions roomOptions2 = roomOptions1;
              num = Random.Range(0, 999999);
              PhotonNetwork.CreateRoom(num.ToString("000000"), roomOptions2, (TypedLobby) TypedLobby.Default);
            }
            if (!this.isPrivateServer)
            {
              PlayerPrefs.SetInt("isPublicServer", 1);
              RoomOptions roomOptions1 = new RoomOptions();
              roomOptions1.set_IsOpen(true);
              roomOptions1.set_IsVisible(true);
              roomOptions1.MaxPlayers = (__Null) (int) Convert.ToByte((int) this.serverSlots);
              roomOptions1.PlayerTtl = (__Null) 2000;
              RoomOptions roomOptions2 = roomOptions1;
              string serverName = this.serverName;
              num = Random.Range(0, 999999);
              string str = num.ToString("000000");
              PhotonNetwork.CreateRoom(serverName + "#" + str, roomOptions2, (TypedLobby) TypedLobby.Default);
            }
          }
          if (GUI.Button(new Rect(720f, 130f, 200f, 20f), "Set Red Name"))
            this.serverName = "<color=#FF0000>" + this.serverName + "</color>";
          if (GUI.Button(new Rect(720f, 155f, 200f, 20f), "Set Blue Name"))
            this.serverName = "<color=#0000FF>" + this.serverName + "</color>";
          if (GUI.Button(new Rect(720f, 180f, 200f, 20f), "Set Green Name"))
            this.serverName = "<color=#008000>" + this.serverName + "</color>";
          GUI.Label(new Rect(920f, 0.0f, 200f, 20f), "Join Room:");
          this.roomName = GUI.TextArea(new Rect(920f, 25f, 200f, 20f), this.roomName);
          this.steamID = GUI.TextArea(new Rect(920f, 50f, 200f, 20f), this.steamID);
          if (GUI.Button(new Rect(920f, 75f, 200f, 20f), "Join Room by Name"))
            PhotonNetwork.JoinRoom(this.roomName);
          if (GUI.Button(new Rect(920f, 100f, 200f, 20f), "Join Room by ID"))
          {
            PhotonNetwork.FindFriends(new string[1]
            {
              this.steamID
            }, (FindFriendsOptions) null);
            using (List<FriendInfo>.Enumerator enumerator = PhotonNetwork.get_Friends().GetEnumerator())
            {
              while (enumerator.MoveNext())
                PhotonNetwork.JoinRoom(enumerator.Current.get_Room());
            }
          }
        }
        if (PhotonNetwork.get_inRoom())
        {
          if (GUI.Toggle(new Rect(520f, 250f, 200f, 20f), this.noclip2, "NoClip") != this.noclip2)
          {
            this.noclip2 = !this.noclip2;
            if (this.noclip2)
            {
              if (PhotonNetwork.get_inRoom())
              {
                ((Rigidbody) ((Component) ((MainManager) MainManager.instance).localPlayer).GetComponent<Rigidbody>()).set_useGravity(false);
                ((Collider) ((Player) ((MainManager) MainManager.instance).localPlayer).charController).set_enabled(false);
              }
            }
            else if (PhotonNetwork.get_inRoom())
            {
              ((Rigidbody) ((Component) ((MainManager) MainManager.instance).localPlayer).GetComponent<Rigidbody>()).set_useGravity(true);
              ((Collider) ((Player) ((MainManager) MainManager.instance).localPlayer).charController).set_enabled(true);
            }
          }
          if (GUI.Toggle(new Rect(520f, 275f, 200f, 20f), this.SpeedHack2, "Speedhack") != this.SpeedHack2)
          {
            this.SpeedHack2 = !this.SpeedHack2;
            if (this.SpeedHack2)
            {
              if (PhotonNetwork.get_inRoom())
              {
                ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_WalkSpeed = (__Null) 3.59999990463257;
                ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_RunSpeed = (__Null) 4.80000019073486;
              }
            }
            else if (PhotonNetwork.get_inRoom())
            {
              ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_WalkSpeed = (__Null) 1.20000004768372;
              ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_RunSpeed = (__Null) 1.60000002384186;
            }
          }
          if (this.ShowItemList)
          {
            GUI.Label(new Rect(720f, 0.0f, 200f, 300f), "Item Spawner:");
            this.scrollViewVector = GUI.BeginScrollView(new Rect(((Rect) ref this.dropDownRect2).get_x() - 100f, ((Rect) ref this.dropDownRect2).get_y() + 25f, ((Rect) ref this.dropDownRect2).get_width(), ((Rect) ref this.dropDownRect2).get_height()), this.scrollViewVector, new Rect(0.0f, 0.0f, ((Rect) ref this.dropDownRect2).get_width(), Mathf.Max(((Rect) ref this.dropDownRect2).get_height(), (float) (this.allitems.Length * 25))));
            GUI.Box(new Rect(0.0f, 0.0f, ((Rect) ref this.dropDownRect2).get_width(), Mathf.Max(((Rect) ref this.dropDownRect2).get_height(), (float) (this.allitems.Length * 25))), "");
            for (int index = 0; index < this.allitems.Length; ++index)
            {
              if (GUI.Button(new Rect(0.0f, (float) (index * 25), ((Rect) ref this.dropDownRect2).get_height(), 25f), ""))
              {
                this.selecteditem = index;
                if (PhotonNetwork.get_inRoom())
                  PhotonNetwork.InstantiateSceneObject(this.allitems[this.selecteditem], ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().get_position(), Quaternion.get_identity(), (byte) 0, (object[]) null);
              }
              GUI.Label(new Rect(5f, (float) (index * 25), ((Rect) ref this.dropDownRect2).get_height(), 25f), this.allitems[index]);
            }
            GUI.EndScrollView();
          }
          GUI.Label(new Rect(920f, 0.0f, 200f, 20f), "Keybinds:");
          if (GUI.Toggle(new Rect(920f, 25f, 200f, 20f), this.KeybindSpeed, "F1 - Speedhack") != this.KeybindSpeed)
            this.KeybindSpeed = !this.KeybindSpeed;
          if (GUI.Toggle(new Rect(920f, 50f, 200f, 20f), this.KeybindNoclip, "F2 - NoClip") != this.KeybindNoclip)
            this.KeybindNoclip = !this.KeybindNoclip;
        }
        if (GUI.Toggle(new Rect(520f, 175f, 200f, 20f), this.ActivateStats, "Show Stats Buttons") != this.ActivateStats)
          this.ActivateStats = !this.ActivateStats;
        if (PhotonNetwork.get_inRoom())
        {
          if (GUI.Toggle(new Rect(520f, 200f, 200f, 20f), this.Showtalkingplayers, "Show Talking Players") != this.Showtalkingplayers)
            this.Showtalkingplayers = !this.Showtalkingplayers;
          if (GUI.Toggle(new Rect(520f, 225f, 200f, 20f), this.ShowItemList, "Show Item Spawner") != this.ShowItemList)
            this.ShowItemList = !this.ShowItemList;
          if (this.Showtalkingplayers && Object.op_Inequality((Object) Cheat.serverManager, (Object) null))
          {
            for (int index = 0; index < this.PlayerSpots.Count; ++index)
            {
              GUI.Label(new Rect(1120f, 0.0f, 200f, 20f), "Talking Players:");
              int num = ((AudioSource) ((VoiceOcclusion) ((Player) this.PlayerSpots[index].myPlayer).voiceOcclusion).source).get_isPlaying() ? 1 : 0;
              bool isTransmitting = ((PhotonVoiceRecorder) ((Player) ((MainManager) MainManager.instance).localPlayer).myVoiceRecorder).get_IsTransmitting();
              if (num != 0)
                GUI.Label(new Rect(1120f, (float) (30 + index * 25), 200f, 20f), ((PhotonPlayer) this.PlayerSpots[index].player).get_NickName());
              if (isTransmitting)
                GUI.Label(new Rect(1120f, 15f, 200f, 20f), "You");
            }
          }
        }
        if (this.ActivateStats)
        {
          if (GUI.Button(new Rect(520f, 100f, 200f, 20f), "Max All Stats"))
            PlayerStats.SetMax();
          if (GUI.Button(new Rect(520f, 125f, 200f, 20f), "Reset All Stats"))
            PlayerStats.ResetAll();
        }
      }
      float num1;
      if (this.ShowInfoPlayer)
      {
        GUI.Label(new Rect(10f, 105f, 150f, 20f), "Name: " + PhotonNetwork.get_player().get_NickName().ToString());
        if (!PhotonNetwork.get_isMasterClient())
          GUI.Label(new Rect(10f, 90f, 150f, 20f), "Master: " + PhotonNetwork.get_masterClient().get_NickName().ToString());
        if (PhotonNetwork.get_isMasterClient())
          GUI.Label(new Rect(10f, 90f, 150f, 20f), "Master: You");
        if (Object.op_Inequality((Object) Cheat.gameController, (Object) null))
        {
          // ISSUE: explicit non-virtual call
          GUI.Label(new Rect(10f, 120f, 150f, 20f), "Model ID: " + __nonvirtual (this.MyPlayer.modelID.ToString()));
          // ISSUE: explicit non-virtual call
          GUI.Label(new Rect(10f, 135f, 150f, 20f), "Hunted: " + __nonvirtual (this.MyPlayer.beingHunted.ToString()));
          Rect rect = new Rect(10f, 150f, 150f, 20f);
          num1 = Mathf.Round((float) this.MyPlayer.insanity);
          string str = "Insanity: " + num1.ToString() + "%";
          GUI.Label(rect, str);
        }
      }
      if (Object.op_Inequality((Object) Cheat.levelController, (Object) null) && this.ShowInfoRoom)
      {
        GUI.Label(new Rect(10f, 165f, 150f, 20f), "Room: " + ((object) ((LevelRoom) Cheat.levelController.currentPlayerRoom).roomName).ToString());
        Rect rect = new Rect(10f, 180f, 150f, 20f);
        num1 = Mathf.Round((float) ((LevelRoom) Cheat.levelController.currentPlayerRoom).temperature);
        string str = "Temperature: " + num1.ToString() + "C";
        GUI.Label(rect, str);
      }
      if (Cheat.gameController.allPlayersAreConnected != null && Object.op_Inequality((Object) Cheat.ghostAI, (Object) null) && this.ShowInfoGhost)
      {
        // ISSUE: explicit non-virtual call
        GUI.Label(new Rect(10f, 340f, 150f, 20f), "Can Hunt: " + __nonvirtual (Cheat.ghostAI.canEnterHuntingMode.ToString()));
        GUI.Label(new Rect(10f, 355f, 150f, 20f), "State: " + Cheat.ghostAI.state.ToString());
        // ISSUE: explicit non-virtual call
        GUI.Label(new Rect(10f, 370f, 150f, 20f), "Hunting: " + __nonvirtual (Cheat.ghostAI.isHunting.ToString()));
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        // ISSUE: explicit non-virtual call
        GUI.Label(new Rect(10f, 385f, 150f, 20f), "Age: " + __nonvirtual ((^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostAge.ToString()));
        // ISSUE: cast to a reference type
        // ISSUE: explicit reference operation
        if ((^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostName != null && Object.op_Inequality((Object) Cheat.levelController.currentGhostRoom, (Object) null))
        {
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          GUI.Label(new Rect(10f, 400f, 150f, 20f), "Name: " + ((object) (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostName).ToString());
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          GUI.Label(new Rect(10f, 415f, 150f, 20f), "Type: " + (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostType.ToString());
          GUI.Label(new Rect(10f, 430f, 150f, 20f), "Current Room: " + ((object) Cheat.levelController.currentGhostRoom).ToString());
        }
        if (Object.op_Inequality((Object) ((GhostInfo) Cheat.ghostAI.ghostInfo).favouriteRoom, (Object) null))
          GUI.Label(new Rect(10f, 445f, 150f, 20f), "Favourite Room: " + ((object) ((GhostInfo) Cheat.ghostAI.ghostInfo).favouriteRoom).ToString());
      }
      if (!this.showGUI && this.ShowGUIKey)
      {
        this.guiStyle.get_normal().set_textColor(Color.get_white());
        this.guiStyle.set_fontSize(15);
        GUI.Label(new Rect(10f, 260f, 400f, 20f), "GUI Key: INSERT", this.guiStyle);
      }
      if (Object.op_Inequality((Object) Cheat.levelController, (Object) null) && this.showGUI)
      {
        GUI.set_color(Color.get_white());
        GUI.Label(new Rect(520f, 0.0f, 200f, 20f), "Custom Item Spawner:");
        this.textArea = GUI.TextArea(new Rect(520f, 25f, 200f, 20f), this.textArea);
        if (GUI.Button(new Rect(520f, 45f, 200f, 20f), "Spawn Custom Item"))
          PhotonNetwork.InstantiateSceneObject(this.textArea, ((Component) this.MyPlayer).get_transform().get_position(), Quaternion.get_identity(), (byte) 0, (object[]) null);
        GUI.Label(new Rect(520f, 70f, 200f, 20f), "Ghost:");
        if (GUI.Button(new Rect(520f, 95f, 200f, 20f), "Random Event") && Object.op_Inequality((Object) Cheat.ghostAI, (Object) null))
        {
          ((GhostActivity) Cheat.ghostAI.ghostActivity).InteractWithARandomDoor();
          ((GhostActivity) Cheat.ghostAI.ghostActivity).InteractWithARandomProp();
          ((GhostActivity) Cheat.ghostAI.ghostActivity).Interact();
          Cheat.ghostAI.RandomEvent();
        }
        if (GUI.Button(new Rect(520f, 120f, 200f, 20f), "Sound"))
        {
          Cheat.ghostAudio.PlaySound(1, false, false);
          Cheat.ghostAudio.PlaySound(0, false, false);
          ((PhotonView) ((Component) Cheat.ghostInteraction).GetComponent<PhotonView>()).RPC("SpawnFootstepNetworked", (PhotonTargets) 0, new object[3]
          {
            (object) ((Component) this.MyPlayer).get_transform().get_position(),
            (object) ((Component) this.MyPlayer).get_transform().get_rotation(),
            (object) Random.Range(0, 2)
          });
        }
        if (GUI.Button(new Rect(520f, 145f, 200f, 20f), "Wander"))
        {
          Cheat.ghostAI.canWander = (__Null) 1;
          ((Animator) Cheat.ghostAI.anim).SetBool("isIdle", false);
          Vector3 vector3 = Vector3.get_zero();
          NavMeshHit navMeshHit;
          if (NavMesh.SamplePosition(Vector3.op_Addition(Vector3.op_Multiply(Random.get_insideUnitSphere(), 3f), ((Component) Cheat.ghostAI).get_transform().get_position()), ref navMeshHit, 3f, 1))
            vector3 = ((NavMeshHit) ref navMeshHit).get_position();
          ((NavMeshAgent) Cheat.ghostAI.agent).set_destination(vector3);
          Cheat.ghostAI.ChangeState((GhostAI.States) 1, (PhotonObjectInteract) null, (PhotonObjectInteract[]) null);
          ((PhotonView) Cheat.ghostAI.view).RPC("Hunting", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
          ((PhotonView) Cheat.ghostAI.view).RPC("SyncChasingPlayer", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
        }
        if (GUI.Button(new Rect(520f, 170f, 200f, 20f), "Hunt"))
        {
          ((SetupPhaseController) SetupPhaseController.instance).isSetupPhase = (__Null) 0;
          Cheat.ghostAI.canAttack = (__Null) 1;
          Cheat.ghostAI.canEnterHuntingMode = (__Null) 1;
          ((Animator) Cheat.ghostAI.anim).SetBool("isIdle", false);
          ((Animator) Cheat.ghostAI.anim).SetInteger("WalkType", 1);
          ((NavMeshAgent) Cheat.ghostAI.agent).set_speed((float) Cheat.ghostAI.defaultSpeed);
          ((GhostInteraction) Cheat.ghostAI.ghostInteraction).CreateAppearedEMF(((Component) Cheat.ghostAI).get_transform().get_position());
          Vector3.get_zero();
          float num2 = Random.Range(2f, 15f);
          NavMeshHit navMeshHit;
          Vector3 vector3 = !NavMesh.SamplePosition(Vector3.op_Addition(Vector3.op_Multiply(Random.get_insideUnitSphere(), num2), ((Component) Cheat.ghostAI).get_transform().get_position()), ref navMeshHit, num2, 1) ? Vector3.get_zero() : ((NavMeshHit) ref navMeshHit).get_position();
          ((NavMeshAgent) Cheat.ghostAI.agent).SetDestination(vector3);
          ((SetupPhaseController) SetupPhaseController.instance).ForceEnterHuntingPhase();
          Cheat.ghostAI.ChangeState((GhostAI.States) 2, (PhotonObjectInteract) null, (PhotonObjectInteract[]) null);
          ((PhotonView) Cheat.ghostAI.view).RPC("Hunting", (PhotonTargets) 0, new object[1]
          {
            (object) true
          });
          ((PhotonView) Cheat.ghostAI.view).RPC("SyncChasingPlayer", (PhotonTargets) 0, new object[1]
          {
            (object) true
          });
        }
        if (GUI.Button(new Rect(520f, 195f, 200f, 20f), "Idle"))
        {
          ((Animator) Cheat.ghostAI.anim).SetInteger("IdleNumber", Random.Range(0, 2));
          ((Animator) Cheat.ghostAI.anim).SetBool("isIdle", true);
          Cheat.ghostAI.UnAppear(false);
          ((GhostAudio) Cheat.ghostAI.ghostAudio).TurnOnOrOffAppearSource(false);
          ((GhostAudio) Cheat.ghostAI.ghostAudio).PlayOrStopAppearSource(false);
          Cheat.ghostAI.ChangeState((GhostAI.States) 0, (PhotonObjectInteract) null, (PhotonObjectInteract[]) null);
          ((PhotonView) Cheat.ghostAI.view).RPC("Hunting", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
          ((PhotonView) Cheat.ghostAI.view).RPC("SyncChasingPlayer", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
        }
        if (GUI.Button(new Rect(520f, 220f, 200f, 20f), "Appear"))
          ((PhotonView) Cheat.ghostAI.view).RPC("MakeGhostAppear", (PhotonTargets) 0, new object[2]
          {
            (object) true,
            (object) Random.Range(0, 3)
          });
        if (GUI.Button(new Rect(520f, 245f, 200f, 20f), "Unappear"))
          ((PhotonView) Cheat.ghostAI.view).RPC("MakeGhostAppear", (PhotonTargets) 0, new object[2]
          {
            (object) false,
            (object) Random.Range(0, 3)
          });
        GUI.Label(new Rect(520f, 270f, 200f, 20f), "Ouija Board:");
        this.textArea2 = GUI.TextArea(new Rect(520f, 295f, 200f, 20f), this.textArea2);
        if (GUI.Button(new Rect(520f, 315f, 200f, 20f), "Custom Answer"))
          Cheat.ouijaBoard.Answer(this.textArea2);
        this.textArea3 = GUI.TextArea(new Rect(520f, 340f, 200f, 20f), this.textArea3);
        if (GUI.Button(new Rect(520f, 360f, 200f, 20f), "Custom Ghost Name"))
        {
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          ((MonoBehaviour) MissionManager.instance).get_photonView().RPC("SetMissionDescriptionSynced", (PhotonTargets) 0, new object[2]
          {
            (object) (bool) (^(GhostTraits&) ref ((GhostInfo) ((GhostAI) ((LevelController) LevelController.instance).currentGhost).ghostInfo).ghostTraits).isShy,
            (object) this.textArea3
          });
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          ((PhotonView) Cheat.ghostInfo.view).RPC("SyncValuesNetworked", (PhotonTargets) 3, new object[7]
          {
            (object) (int) (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostType,
            (object) (int) (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostAge,
            (object) (bool) (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).isMale,
            (object) this.textArea3,
            (object) (bool) (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).isShy,
            (object) (int) (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).deathLength,
            (object) (int) (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).favouriteRoomID
          });
        }
        GUI.Label(new Rect(720f, 0.0f, 200f, 20f), "Lights:");
        if (GUI.Button(new Rect(720f, 25f, 200f, 20f), "All Lights On"))
        {
          using (List<LightSwitch>.Enumerator enumerator = Cheat.lightSwitches.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              LightSwitch current = enumerator.Current;
              current.TurnOn(true);
              current.TurnOnNetworked(true);
            }
          }
        }
        if (GUI.Button(new Rect(720f, 50f, 200f, 20f), "All Lights Off"))
        {
          using (List<LightSwitch>.Enumerator enumerator = Cheat.lightSwitches.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              LightSwitch current = enumerator.Current;
              current.TurnOff();
              current.TurnOffNetworked(true);
            }
          }
        }
        if (GUI.Button(new Rect(720f, 75f, 200f, 20f), "Start Lights Blinking"))
        {
          using (List<LightSwitch>.Enumerator enumerator = Cheat.lightSwitches.GetEnumerator())
          {
            while (enumerator.MoveNext())
              ((PhotonView) enumerator.Current.view).RPC("FlickerNetworked", (PhotonTargets) 0, Array.Empty<object>());
          }
        }
        if (GUI.Button(new Rect(720f, 100f, 200f, 20f), "Stop Lights Blinking"))
        {
          using (List<LightSwitch>.Enumerator enumerator = Cheat.lightSwitches.GetEnumerator())
          {
            while (enumerator.MoveNext())
              enumerator.Current.StopBlinking();
          }
        }
        if (GUI.Button(new Rect(720f, 125f, 200f, 20f), "Fusebox Use"))
          Cheat.fuseBox.Use();
        if (GUI.Button(new Rect(720f, 150f, 200f, 20f), "Random Light Use"))
        {
          LightSwitch lightSwitch = Cheat.lightSwitches[new Random().Next(0, Cheat.lightSwitches.Count)];
          if (Object.op_Inequality((Object) lightSwitch, (Object) null))
            lightSwitch.UseLight();
        }
        GUI.Label(new Rect(720f, 175f, 200f, 20f), "Doors:");
        if (GUI.Button(new Rect(720f, 200f, 200f, 20f), "Knock"))
        {
          ((PhotonView) ((SoundController) SoundController.instance).view).RPC("PlayDoorKnockingSound", (PhotonTargets) 0, Array.Empty<object>());
          ((GhostInteraction) Cheat.ghostAI.ghostInteraction).CreateInteractionEMF(((Component) ((SoundController) SoundController.instance).doorAudioSource).get_transform().get_position());
        }
        if (GUI.Button(new Rect(720f, 225f, 200f, 20f), "Close All Doors"))
        {
          using (List<Door>.Enumerator enumerator = Cheat.doors.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              Door current = enumerator.Current;
              current.GrabbedDoor();
              current.TrailerCloseDoor();
              current.UnGrabbedDoor();
            }
          }
        }
        if (GUI.Button(new Rect(720f, 250f, 200f, 20f), "Disable Exit Doors"))
        {
          for (int index = 0; index < ((LevelController) LevelController.instance).exitDoors.Length; ++index)
          {
            ((Door) ((LevelController) LevelController.instance).exitDoors[index]).TrailerCloseDoor();
            ((Door) ((LevelController) LevelController.instance).exitDoors[index]).DisableOrEnableDoor(false);
          }
        }
        if (GUI.Button(new Rect(720f, 275f, 200f, 20f), "Enable Exit Doors"))
        {
          for (int index = 0; index < ((LevelController) LevelController.instance).exitDoors.Length; ++index)
            ((Door) ((LevelController) LevelController.instance).exitDoors[index]).DisableOrEnableDoor(true);
        }
        if (GUI.Button(new Rect(720f, 300f, 200f, 20f), "Close Random Door"))
        {
          Door door = Cheat.doors[new Random().Next(0, Cheat.doors.Count)];
          if (Object.op_Inequality((Object) door, (Object) null))
          {
            door.GrabbedDoor();
            door.TrailerCloseDoor();
            door.UnGrabbedDoor();
          }
        }
        if (GUI.Toggle(new Rect(720f, 325f, 200f, 20f), this.noclip, "NoClip") != this.noclip)
        {
          this.noclip = !this.noclip;
          if (this.noclip)
          {
            ((Rigidbody) ((Component) this.MyPlayer).GetComponent<Rigidbody>()).set_useGravity(false);
            ((Collider) this.MyPlayer.charController).set_enabled(false);
          }
          else
          {
            ((Rigidbody) ((Component) this.MyPlayer).GetComponent<Rigidbody>()).set_useGravity(true);
            ((Collider) this.MyPlayer.charController).set_enabled(true);
          }
        }
        if (GUI.Toggle(new Rect(720f, 350f, 200f, 20f), this.SpeedHack, "Speedhack") != this.SpeedHack)
        {
          this.SpeedHack = !this.SpeedHack;
          if (this.SpeedHack)
          {
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_WalkSpeed = (__Null) 3.59999990463257;
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_RunSpeed = (__Null) 4.80000019073486;
          }
          else
          {
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_WalkSpeed = (__Null) 1.20000004768372;
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_RunSpeed = (__Null) 1.60000002384186;
          }
        }
        if (GUI.Toggle(new Rect(720f, 375f, 200f, 20f), this.NoFog, "No Fog") != this.NoFog)
        {
          this.NoFog = !this.NoFog;
          if (this.NoFog)
          {
            ((PostProcessVolume) this.MyPlayer.postProcessingVolume).set_profile(this.mainProfile);
            RenderSettings.set_fog(false);
          }
          if (!this.NoFog && FileBasedPrefs.GetInt("PlayerDied", 0) == 1)
            RenderSettings.set_fog(true);
        }
        if (GUI.Toggle(new Rect(720f, 400f, 200f, 20f), this.Fullbright, "Fullbright") != this.Fullbright)
        {
          this.Fullbright = !this.Fullbright;
          Transform boneTransform = ((Animator) this.MyPlayer.charAnim).GetBoneTransform((HumanBodyBones) 10);
          Light component = (Light) ((Component) boneTransform).GetComponent<Light>();
          if (this.Fullbright)
          {
            Light light = (Light) ((Component) boneTransform).get_gameObject().AddComponent<Light>();
            light.set_color(Color.get_white());
            light.set_type((LightType) 0);
            light.set_shadows((LightShadows) 0);
            light.set_range(99f);
            light.set_spotAngle(9999f);
            light.set_intensity(0.3f);
          }
          else
            Object.Destroy((Object) component);
        }
        GUI.Label(new Rect(920f, 0.0f, 200f, 20f), "Other:");
        if (GUI.Button(new Rect(920f, 25f, 200f, 20f), "Car Alarm"))
        {
          if (this.carAlarmOn)
          {
            ((PhotonView) ((Car) ((LevelController) LevelController.instance).car).view).RPC("TurnAlarmOff", (PhotonTargets) 0, Array.Empty<object>());
            ((GhostInteraction) Cheat.ghostAI.ghostInteraction).CreateInteractionEMF(((Transform) ((Car) ((LevelController) LevelController.instance).car).raycastSpot).get_position());
            this.carAlarmOn = false;
          }
          else
          {
            ((PhotonView) ((Car) ((LevelController) LevelController.instance).car).view).RPC("TurnAlarmOn", (PhotonTargets) 0, Array.Empty<object>());
            ((GhostInteraction) Cheat.ghostAI.ghostInteraction).CreateInteractionEMF(((Transform) ((Car) ((LevelController) LevelController.instance).car).raycastSpot).get_position());
            this.carAlarmOn = true;
          }
        }
        if (GUI.Button(new Rect(920f, 50f, 200f, 20f), "Play Lightning"))
          ((LightningController) LightningController.instance).PlayLightning();
        if (GUI.Button(new Rect(920f, 75f, 200f, 20f), "Exit Mission (everyone)"))
          ((PhotonView) ((Component) Cheat.exitLevel).GetComponent<PhotonView>()).RPC("Exit", (PhotonTargets) 6, Array.Empty<object>());
        this.textArea4 = GUI.TextArea(new Rect(920f, 100f, 200f, 20f), this.textArea4);
        if (GUI.Button(new Rect(920f, 120f, 200f, 20f), "Journal Photo w/ Custom Title"))
          ((PhotonView) ((Component) Cheat.handCamera).GetComponent<PhotonView>()).RPC("AddPhotoToJournal", (PhotonTargets) 0, new object[2]
          {
            (object) this.textArea4,
            (object) 1
          });
        if (GUI.Button(new Rect(920f, 145f, 200f, 20f), "Clone Ghost"))
        {
          object maleGhostName = Constants.maleGhostNames[0];
          ((GhostInfo) ((GhostAI) PhotonNetwork.InstantiateSceneObject((string) Constants.maleGhostNames[Random.Range(0, Constants.maleGhostNames.Length)], ((Component) this.MyPlayer).get_transform().get_position(), ((Component) this.MyPlayer).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<GhostAI>()).ghostInfo).ghostTraits = ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits;
        }
        if (GUI.Button(new Rect(920f, 170f, 200f, 20f), "Spawn Random Ghost"))
        {
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostType = (__Null) Random.Range(1, 13);
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).deathLength = (__Null) Random.Range(50, 1000);
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostAge = (__Null) Random.Range(10, 90);
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).isMale = (__Null) (Random.Range(0, 2) == 0 ? 1 : 0);
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).favouriteRoomID = (__Null) Random.Range(0, ((LevelController) LevelController.instance).rooms.Length);
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).isShy = (__Null) (Random.Range(0, 2) == 1 ? 1 : 0);
          string maleGhostName = (string) Constants.maleGhostNames[0];
          string str;
          // ISSUE: cast to a reference type
          // ISSUE: explicit reference operation
          if ((^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).isMale != null)
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostName = (__Null) ((string) ((LevelController) LevelController.instance).possibleMaleFirstNames[Random.Range(0, ((LevelController) LevelController.instance).possibleMaleFirstNames.Length)] + " " + (string) ((LevelController) LevelController.instance).possibleLastNames[Random.Range(0, ((LevelController) LevelController.instance).possibleLastNames.Length)]);
            str = (string) Constants.maleGhostNames[Random.Range(0, Constants.maleGhostNames.Length)];
          }
          else
          {
            // ISSUE: cast to a reference type
            // ISSUE: explicit reference operation
            (^(GhostTraits&) ref ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits).ghostName = (__Null) ((string) ((LevelController) LevelController.instance).possibleFemaleFirstNames[Random.Range(0, ((LevelController) LevelController.instance).possibleFemaleFirstNames.Length)] + " " + (string) ((LevelController) LevelController.instance).possibleLastNames[Random.Range(0, ((LevelController) LevelController.instance).possibleLastNames.Length)]);
            str = (string) Constants.femaleGhostNames[Random.Range(0, Constants.femaleGhostNames.Length)];
          }
          GhostAI component = (GhostAI) PhotonNetwork.InstantiateSceneObject(str, ((Component) this.MyPlayer).get_transform().get_position(), ((Component) this.MyPlayer).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<GhostAI>();
          ((GhostInfo) component.ghostInfo).ghostTraits = ((GhostInfo) Cheat.ghostAI.ghostInfo).ghostTraits;
          component.canWander = (__Null) 1;
          ((Animator) component.anim).SetBool("isIdle", false);
          Vector3 vector3 = Vector3.get_zero();
          NavMeshHit navMeshHit;
          if (NavMesh.SamplePosition(Vector3.op_Addition(Vector3.op_Multiply(Random.get_insideUnitSphere(), 3f), ((Component) component).get_transform().get_position()), ref navMeshHit, 3f, 1))
            vector3 = ((NavMeshHit) ref navMeshHit).get_position();
          ((NavMeshAgent) component.agent).set_destination(vector3);
          component.ChangeState((GhostAI.States) 1, (PhotonObjectInteract) null, (PhotonObjectInteract[]) null);
        }
        if (GUI.Button(new Rect(920f, 195f, 200f, 20f), "Interact While Dead"))
        {
          ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).isDead = (__Null) 0;
          for (int index = 0; index < ((List<GameObject>) ((LevelController) LevelController.instance).doors).Count; ++index)
          {
            if (Object.op_Inequality((Object) ((List<GameObject>) ((LevelController) LevelController.instance).doors)[index], (Object) null) && Object.op_Inequality((Object) ((List<GameObject>) ((LevelController) LevelController.instance).doors)[index].GetComponent<Door>(), (Object) null) && Object.op_Inequality((Object) ((Door) ((List<GameObject>) ((LevelController) LevelController.instance).doors)[index].GetComponent<Door>()).rend, (Object) null))
              ((Renderer) ((Door) ((List<GameObject>) ((LevelController) LevelController.instance).doors)[index].GetComponent<Door>()).rend).set_enabled(true);
          }
          for (int index1 = 0; index1 < ((LevelController) LevelController.instance).rooms.Length; ++index1)
          {
            for (int index2 = 0; index2 < ((List<LightSwitch>) ((LevelRoom) ((LevelController) LevelController.instance).rooms[index1]).lightSwitches).Count; ++index2)
            {
              for (int index3 = 0; index3 < ((List<ReflectionProbe>) ((List<LightSwitch>) ((LevelRoom) ((LevelController) LevelController.instance).rooms[index1]).lightSwitches)[index2].probes).Count; ++index3)
              {
                ((List<ReflectionProbe>) ((List<LightSwitch>) ((LevelRoom) ((LevelController) LevelController.instance).rooms[index1]).lightSwitches)[index2].probes)[index3].Reset();
                ((List<LightSwitch>) ((LevelRoom) ((LevelController) LevelController.instance).rooms[index1]).lightSwitches)[index2].ResetReflectionProbes();
              }
            }
          }
        }
        if (GUI.Button(new Rect(920f, 220f, 200f, 20f), "Set Dead Again"))
          ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).isDead = (__Null) 1;
        if (GUI.Button(new Rect(920f, 245f, 200f, 20f), "Use Radios") && ((LevelController) LevelController.instance).radiosInLevel.Length != 0)
        {
          for (int index = 0; index < ((LevelController) LevelController.instance).radiosInLevel.Length; ++index)
          {
            ((PhotonView) ((Radio) ((LevelController) LevelController.instance).radiosInLevel[index]).view).RPC("NetworkedUse", (PhotonTargets) 0, Array.Empty<object>());
            Cheat.ghostInteraction.CreateInteractionEMF(((Component) ((LevelController) LevelController.instance).radiosInLevel[index]).get_transform().get_position());
          }
        }
        if (GUI.Button(new Rect(920f, 270f, 200f, 20f), "Use Truck Door [!]"))
          ((PhotonView) ((Component) Cheat.liftButton).GetComponent<PhotonView>()).RPC("NetworkedUse", (PhotonTargets) 6, new object[1]
          {
            (object) false
          });
        GUI.Label(new Rect(920f, 295f, 200f, 20f), "ESP:");
        if (GUI.Toggle(new Rect(920f, 320f, 200f, 20f), this.GhostESP, "Ghost") != this.GhostESP)
          this.GhostESP = !this.GhostESP;
        if (GUI.Toggle(new Rect(920f, 345f, 200f, 20f), this.ghostold, "Old Ghost ESP") != this.ghostold)
          this.ghostold = !this.ghostold;
        if (GUI.Toggle(new Rect(920f, 370f, 200f, 20f), this.PlayerESP, "Player") != this.PlayerESP)
          this.PlayerESP = !this.PlayerESP;
        if (GUI.Toggle(new Rect(920f, 395f, 200f, 20f), this.OuijaESP, "Ouija Board") != this.OuijaESP)
          this.OuijaESP = !this.OuijaESP;
        if (GUI.Toggle(new Rect(920f, 420f, 200f, 20f), this.KeyESP, "Key") != this.KeyESP)
          this.KeyESP = !this.KeyESP;
        if (GUI.Toggle(new Rect(920f, 445f, 200f, 20f), this.EvidenceESP, "Evidence") != this.EvidenceESP)
          this.EvidenceESP = !this.EvidenceESP;
        GUI.Label(new Rect(1120f, 0.0f, 200f, 20f), "Keybinds:");
        if (GUI.Toggle(new Rect(1120f, 25f, 200f, 20f), this.KeybindSpeed, "F1 - Speedhack") != this.KeybindSpeed)
          this.KeybindSpeed = !this.KeybindSpeed;
        if (GUI.Toggle(new Rect(1120f, 50f, 200f, 20f), this.KeybindNoclip, "F2 - NoClip") != this.KeybindNoclip)
          this.KeybindNoclip = !this.KeybindNoclip;
        if (GUI.Toggle(new Rect(1120f, 75f, 200f, 20f), this.KeybindRandom, "F3 - Random Event") != this.KeybindRandom)
          this.KeybindRandom = !this.KeybindRandom;
        if (GUI.Toggle(new Rect(1120f, 100f, 200f, 20f), this.KeybindHunt, "F4 - Ghost Hunt") != this.KeybindHunt)
          this.KeybindHunt = !this.KeybindHunt;
        if (GUI.Toggle(new Rect(1120f, 125f, 200f, 20f), this.KeybindIdle, "F5 - Ghost Idle") != this.KeybindIdle)
          this.KeybindIdle = !this.KeybindIdle;
        if (GUI.Toggle(new Rect(1120f, 150f, 200f, 20f), this.KeybindWander, "F6 - Ghost Wander") != this.KeybindWander)
          this.KeybindWander = !this.KeybindWander;
        GUI.Label(new Rect(1120f, 175f, 200f, 20f), "Show/Hide:");
        if (GUI.Toggle(new Rect(1120f, 200f, 200f, 20f), this.ShowWatermark, "Show Watermark") != this.ShowWatermark)
          this.ShowWatermark = !this.ShowWatermark;
        if (GUI.Toggle(new Rect(1120f, 225f, 200f, 20f), this.ShowMaster, "Show Master Button") != this.ShowMaster)
          this.ShowMaster = !this.ShowMaster;
        if (GUI.Toggle(new Rect(1120f, 250f, 200f, 20f), this.ShowInfoPlayer, "Show Player Info") != this.ShowInfoPlayer)
          this.ShowInfoPlayer = !this.ShowInfoPlayer;
        if (GUI.Toggle(new Rect(1120f, 275f, 200f, 20f), this.ShowInfoRoom, "Show Room Info") != this.ShowInfoRoom)
          this.ShowInfoRoom = !this.ShowInfoRoom;
        if (GUI.Toggle(new Rect(1120f, 300f, 200f, 20f), this.ShowInfoGhost, "Show Ghost Info") != this.ShowInfoGhost)
          this.ShowInfoGhost = !this.ShowInfoGhost;
        if (GUI.Toggle(new Rect(1120f, 325f, 200f, 20f), this.ShowItemList, "Show Item Spawner") != this.ShowItemList)
          this.ShowItemList = !this.ShowItemList;
        if (GUI.Toggle(new Rect(1120f, 350f, 200f, 20f), this.ShowGUIKey, "Show GUI Key Info") != this.ShowGUIKey)
          this.ShowGUIKey = !this.ShowGUIKey;
        if (GUI.Toggle(new Rect(1120f, 375f, 200f, 20f), this.Showtalkingplayers, "Show Talking Players") != this.Showtalkingplayers)
          this.Showtalkingplayers = !this.Showtalkingplayers;
        if (this.ShowItemList)
        {
          GUI.Label(new Rect(1320f, 0.0f, 200f, 300f), "Item Spawner:");
          this.scrollViewVector = GUI.BeginScrollView(new Rect(((Rect) ref this.dropDownRect).get_x() - 100f, ((Rect) ref this.dropDownRect).get_y() + 25f, ((Rect) ref this.dropDownRect).get_width(), ((Rect) ref this.dropDownRect).get_height()), this.scrollViewVector, new Rect(0.0f, 0.0f, ((Rect) ref this.dropDownRect).get_width(), Mathf.Max(((Rect) ref this.dropDownRect).get_height(), (float) (this.allitems.Length * 25))));
          GUI.Box(new Rect(0.0f, 0.0f, ((Rect) ref this.dropDownRect).get_width(), Mathf.Max(((Rect) ref this.dropDownRect).get_height(), (float) (this.allitems.Length * 25))), "");
          for (int index = 0; index < this.allitems.Length; ++index)
          {
            if (GUI.Button(new Rect(0.0f, (float) (index * 25), ((Rect) ref this.dropDownRect).get_height(), 25f), ""))
            {
              this.selecteditem = index;
              PhotonNetwork.InstantiateSceneObject(this.allitems[this.selecteditem], ((Component) this.MyPlayer).get_transform().get_position(), Quaternion.get_identity(), (byte) 0, (object[]) null);
            }
            GUI.Label(new Rect(5f, (float) (index * 25), ((Rect) ref this.dropDownRect).get_height(), 25f), this.allitems[index]);
          }
          GUI.EndScrollView();
        }
      }
      if (Object.op_Inequality((Object) Cheat.gameController, (Object) null) && Object.op_Inequality((Object) this.MyPlayer, (Object) null) && this.showGUI)
      {
        GUI.set_color(Color.get_white());
        if (this.selectedPlayer >= this.Players.Count)
          this.selectedPlayer = 0;
        if (this.Players[this.selectedPlayer].photonPlayer == null)
          GUI.Label(new Rect(120f, 0.0f, 200f, 20f), "Selected: None");
        if (this.Players[this.selectedPlayer].photonPlayer != null)
          GUI.Label(new Rect(120f, 0.0f, 200f, 20f), "Selected: " + ((PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer).get_NickName().ToString());
        for (int index = 0; index < this.Players.Count; ++index)
        {
          if (GUI.Button(new Rect(120f, (float) (25 + index * 25), 200f, 20f), ((PhotonPlayer) this.Players[index].photonPlayer).get_NickName() ?? ""))
            this.selectedPlayer = index;
        }
        if (GUI.Button(new Rect(120f, (float) (50 + this.Players.Count * 25), 200f, 20f), "Teleport To Player"))
          ((Component) this.MyPlayer.firstPersonController).get_transform().set_position(((Component) this.Players[this.selectedPlayer].player).get_transform().get_position());
        if (GUI.Button(new Rect(120f, (float) (75 + this.Players.Count * 25), 200f, 20f), "Remove 1 Sanity Pill"))
          ((MonoBehaviour) Cheat.itemSpawner).get_photonView().RPC("RemoveSanityPillFromOwner", (PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer, Array.Empty<object>());
        if (GUI.Button(new Rect(120f, (float) (100 + this.Players.Count * 25), 200f, 20f), "Teleport to Death Room"))
          ((PhotonView) ((Component) DeadZoneController.instance).GetComponent<PhotonView>()).RPC("SpawnDeathRoomNetworked", (PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer, Array.Empty<object>());
        if (GUI.Button(new Rect(120f, (float) (125 + this.Players.Count * 25), 200f, 20f), "Teleport Back (will die)"))
          ((PhotonView) ((Component) DeadZoneController.instance).GetComponent<PhotonView>()).RPC("DespawnDeathRoomNetworked", (PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer, Array.Empty<object>());
        if (GUI.Button(new Rect(120f, (float) (150 + this.Players.Count * 25), 200f, 20f), "Kill Player"))
        {
          (!Object.op_Inequality((Object) ((Player) this.Players[this.selectedPlayer].player).VRIKObj, (Object) null) ? (DeadPlayer) PhotonNetwork.InstantiateSceneObject("DeadPlayerRagdoll", ((Component) this).get_transform().get_position(), ((Component) ((LevelController) LevelController.instance).currentGhost).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<DeadPlayer>() : (DeadPlayer) PhotonNetwork.InstantiateSceneObject("DeadPlayerRagdoll", ((GameObject) ((Player) this.Players[this.selectedPlayer].player).headObject).get_transform().get_position(), ((Component) ((LevelController) LevelController.instance).currentGhost).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<DeadPlayer>()).Spawn((int) ((Player) this.Players[this.selectedPlayer].player).modelID, (int) this.Players[this.selectedPlayer].actorID);
          ((PhotonView) ((Component) DeadZoneController.instance).GetComponent<PhotonView>()).RPC("SpawnDeathRoomNetworked", (PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer, Array.Empty<object>());
          ((PhotonView) ((Component) DeadZoneController.instance).GetComponent<PhotonView>()).RPC("DespawnDeathRoomNetworked", (PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer, Array.Empty<object>());
        }
        if (GUI.Button(new Rect(120f, (float) (175 + this.Players.Count * 25), 200f, 20f), "Reset Insanity"))
        {
          float num2 = 0.0f;
          ((MonoBehaviour) GhostController.instance).get_photonView().RPC("NetworkedUpdatePlayerSanity", (PhotonTargets) 0, new object[2]
          {
            (object) num2,
            (object) (int) this.Players[this.selectedPlayer].actorID
          });
        }
        if (GUI.Button(new Rect(120f, (float) (200 + this.Players.Count * 25), 200f, 20f), "Force Exit Mission"))
          ((PhotonView) ((Component) Cheat.exitLevel).GetComponent<PhotonView>()).RPC("Exit", (PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer, Array.Empty<object>());
        if (GUI.Button(new Rect(120f, (float) (225 + this.Players.Count * 25), 200f, 20f), "Freeze Game"))
          PhotonNetwork.DestroyPlayerObjects((PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer);
        if (GUI.Button(new Rect(120f, (float) (250 + this.Players.Count * 25), 200f, 20f), "Teleport Ghost To Him"))
        {
          Vector3 position = ((Component) this.Players[this.selectedPlayer].player).get_transform().get_position();
          ((NavMeshAgent) Cheat.ghostAI.agent).Warp(position);
        }
        if (GUI.Button(new Rect(120f, (float) (275 + this.Players.Count * 25), 200f, 20f), "Spawn Dead Ragdoll"))
          (!Object.op_Inequality((Object) ((Player) this.Players[this.selectedPlayer].player).VRIKObj, (Object) null) ? (DeadPlayer) PhotonNetwork.InstantiateSceneObject("DeadPlayerRagdoll", ((Component) this).get_transform().get_position(), ((Component) this.Players[this.selectedPlayer].player).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<DeadPlayer>() : (DeadPlayer) PhotonNetwork.InstantiateSceneObject("DeadPlayerRagdoll", ((GameObject) ((Player) this.Players[this.selectedPlayer].player).headObject).get_transform().get_position(), ((Component) this.Players[this.selectedPlayer].player).get_transform().get_rotation(), (byte) 0, (object[]) null).GetComponent<DeadPlayer>()).Spawn((int) ((Player) this.Players[this.selectedPlayer].player).modelID, 7);
        if (GUI.Button(new Rect(120f, (float) (300 + this.Players.Count * 25), 200f, 20f), "Set Master"))
          PhotonNetwork.SetMasterClient((PhotonPlayer) this.Players[this.selectedPlayer].photonPlayer);
      }
      if (this.Showtalkingplayers && Object.op_Inequality((Object) Cheat.levelController, (Object) null))
      {
        for (int index = 0; index < this.Players.Count; ++index)
        {
          GUI.Label(new Rect(1520f, 0.0f, 200f, 20f), "Talking Players:");
          int num2 = ((AudioSource) ((VoiceOcclusion) ((Player) this.Players[index].player).voiceOcclusion).source).get_isPlaying() ? 1 : 0;
          bool isTransmitting = ((PhotonVoiceRecorder) this.MyPlayer.myVoiceRecorder).get_IsTransmitting();
          if (num2 != 0)
            GUI.Label(new Rect(1520f, (float) (30 + index * 25), 200f, 20f), ((PhotonPlayer) this.Players[index].photonPlayer).get_NickName());
          if (isTransmitting)
            GUI.Label(new Rect(1520f, 15f, 200f, 20f), "You");
        }
      }
      if (Object.op_Inequality((Object) Cheat.gameController, (Object) null) && Object.op_Inequality((Object) Cheat.ghostAI, (Object) null) && Object.op_Inequality((Object) this.MyPlayer, (Object) null))
      {
        if (this.GhostESP)
        {
          using (List<GhostAI>.Enumerator enumerator = Cheat.ghosts.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              GhostAI current = enumerator.Current;
              Vector3 screenPoint = Camera.get_main().WorldToScreenPoint(((Component) current).get_transform().get_position());
              if (screenPoint.z > 0.0)
              {
                screenPoint.y = (__Null) ((double) Screen.get_height() - (screenPoint.y + 1.0));
                GUI.set_color(Color.get_red());
                GUI.DrawTexture(new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(5f, 5f)), (Texture) Texture2D.get_whiteTexture(), (ScaleMode) 0);
                double num2;
                if (!this.ghostold)
                {
                  Rect rect = new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(100f, 100f));
                  // ISSUE: cast to a reference type
                  // ISSUE: explicit reference operation
                  string str1 = (^(GhostTraits&) ref ((GhostInfo) current.ghostInfo).ghostTraits).ghostType.ToString();
                  num2 = Math.Round((double) Vector3.Distance(((Component) current).get_transform().get_position(), ((Component) this.MyPlayer.firstPersonController).get_transform().get_position()), 2);
                  string str2 = num2.ToString();
                  string str3 = str1 + " [" + str2 + "]";
                  GUI.Label(rect, str3);
                }
                if (this.ghostold)
                {
                  Rect rect = new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(100f, 100f));
                  num2 = Math.Round((double) Vector3.Distance(((Component) current).get_transform().get_position(), ((Component) this.MyPlayer.firstPersonController).get_transform().get_position()), 2);
                  string str = "Ghost | " + num2.ToString() + "m";
                  GUI.Label(rect, str);
                }
              }
            }
          }
        }
        if (this.PlayerESP)
        {
          using (List<PlayerData>.Enumerator enumerator = ((List<PlayerData>) ((GameController) GameController.instance).playersData).GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              PlayerData current = enumerator.Current;
              Vector3 screenPoint = Camera.get_main().WorldToScreenPoint(((Component) current.player).get_transform().get_position());
              if (screenPoint.z > 0.0)
              {
                screenPoint.y = (__Null) ((double) Screen.get_height() - (screenPoint.y + 1.0));
                GUI.set_color(Color.get_green());
                GUI.DrawTexture(new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(5f, 5f)), (Texture) Texture2D.get_whiteTexture(), (ScaleMode) 0);
                GUI.Label(new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(100f, 100f)), (string) current.playerName);
              }
            }
          }
        }
      }
      if (Cheat.keys != null && this.KeyESP)
      {
        using (List<Key>.Enumerator enumerator = Cheat.keys.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            Key current = enumerator.Current;
            Vector3 screenPoint = Camera.get_main().WorldToScreenPoint(((Component) current).get_transform().get_position());
            if (screenPoint.z > 0.0)
            {
              screenPoint.y = (__Null) ((double) Screen.get_height() - (screenPoint.y + 1.0));
              GUI.set_color(Color.get_cyan());
              GUI.Label(new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(100f, 100f)), current.type.ToString() + " Key");
            }
          }
        }
      }
      if (Cheat.dNAEvidences != null && this.EvidenceESP)
      {
        using (List<DNAEvidence>.Enumerator enumerator = Cheat.dNAEvidences.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            DNAEvidence current = enumerator.Current;
            Vector3 screenPoint = Camera.get_main().WorldToScreenPoint(((Component) current).get_transform().get_position());
            if (screenPoint.z > 0.0)
            {
              screenPoint.y = (__Null) ((double) Screen.get_height() - (screenPoint.y + 1.0));
              GUI.set_color(Color.get_magenta());
              GUI.Label(new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(100f, 100f)), "Evidence");
            }
          }
        }
      }
      if (!Object.op_Inequality((Object) Cheat.ouijaBoard, (Object) null) || !this.OuijaESP)
        return;
      using (List<OuijaBoard>.Enumerator enumerator = Cheat.ouijaBoards.GetEnumerator())
      {
        while (enumerator.MoveNext())
        {
          OuijaBoard current = enumerator.Current;
          Vector3 screenPoint = Camera.get_main().WorldToScreenPoint(((Component) current).get_transform().get_position());
          if (screenPoint.z > 0.0)
          {
            screenPoint.y = (__Null) ((double) Screen.get_height() - (screenPoint.y + 1.0));
            GUI.set_color(Color.get_yellow());
            GUI.Label(new Rect(new Vector2((float) screenPoint.x, (float) screenPoint.y), new Vector2(100f, 100f)), "Ouija Board");
          }
        }
      }
    }

    private IEnumerator CollectGameObjects()
    {
      Cheat.gameController = (GameController) Object.FindObjectOfType<GameController>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.levelController = (LevelController) Object.FindObjectOfType<LevelController>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.levelSelectionManager = (LevelSelectionManager) Object.FindObjectOfType<LevelSelectionManager>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.walkieTalkie = (WalkieTalkie) Object.FindObjectOfType<WalkieTalkie>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.handCamera = (HandCamera) Object.FindObjectOfType<HandCamera>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.inventoryManager = (InventoryManager) Object.FindObjectOfType<InventoryManager>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.liftButton = (LiftButton) Object.FindObjectOfType<LiftButton>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.contract = (Contract) Object.FindObjectOfType<Contract>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.pCMenu = (PCMenu) Object.FindObjectOfType<PCMenu>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.exitLevel = (ExitLevel) Object.FindObjectOfType<ExitLevel>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.ghostAI = (GhostAI) Object.FindObjectOfType<GhostAI>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.lightSwitch = (LightSwitch) Object.FindObjectOfType<LightSwitch>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.light = (Light) Object.FindObjectOfType<Light>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.dNAEvidences = ((IEnumerable<DNAEvidence>) Object.FindObjectsOfType<DNAEvidence>()).ToList<DNAEvidence>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.contracts = ((IEnumerable<Contract>) Object.FindObjectsOfType<Contract>()).ToList<Contract>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.items = ((IEnumerable<InventoryItem>) Object.FindObjectsOfType<InventoryItem>()).ToList<InventoryItem>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.photonView = (PhotonView) Object.FindObjectOfType<PhotonView>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.ghostInfo = (GhostInfo) Object.FindObjectOfType<GhostInfo>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.deadPlayer = (DeadPlayer) Object.FindObjectOfType<DeadPlayer>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.player = (Player) Object.FindObjectOfType<Player>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.rigidbody = (Rigidbody) Object.FindObjectOfType<Rigidbody>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.itemSpawner = (ItemSpawner) Object.FindObjectOfType<ItemSpawner>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.ghostInteraction = (GhostInteraction) Object.FindObjectOfType<GhostInteraction>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.baseController = (BaseController) Object.FindObjectOfType<BaseController>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.ouijaBoard = (OuijaBoard) Object.FindObjectOfType<OuijaBoard>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.ouijaBoards = ((IEnumerable<OuijaBoard>) Object.FindObjectsOfType<OuijaBoard>()).ToList<OuijaBoard>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.keys = ((IEnumerable<Key>) Object.FindObjectsOfType<Key>()).ToList<Key>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.ghosts = ((IEnumerable<GhostAI>) Object.FindObjectsOfType<GhostAI>()).ToList<GhostAI>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.serverManager = (ServerManager) Object.FindObjectOfType<ServerManager>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.torches = ((IEnumerable<Torch>) Object.FindObjectsOfType<Torch>()).ToList<Torch>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.ghostAudio = (GhostAudio) Object.FindObjectOfType<GhostAudio>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.fuseBox = (FuseBox) Object.FindObjectOfType<FuseBox>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.doors = ((IEnumerable<Door>) Object.FindObjectsOfType<Door>()).ToList<Door>();
      yield return (object) new WaitForSeconds(0.15f);
      Cheat.lightSwitches = ((IEnumerable<LightSwitch>) Object.FindObjectsOfType<LightSwitch>()).ToList<LightSwitch>();
      yield return (object) null;
    }

    private IEnumerator KeyHandler()
    {
      Keyboard current = Keyboard.get_current();
      if (Object.op_Inequality((Object) Cheat.levelController, (Object) null))
      {
        if (((ButtonControl) current.get_insertKey()).get_wasPressedThisFrame())
        {
          this.showGUI = !this.showGUI;
          if (!this.showGUI)
          {
            Cursor.set_lockState((CursorLockMode) 2);
            Cursor.set_visible(false);
            ((Behaviour) this.MyPlayer.firstPersonController).set_enabled(true);
            ((Animator) this.MyPlayer.charAnim).SetFloat("speed", 0.0f);
          }
          if (this.showGUI)
          {
            Cursor.set_lockState((CursorLockMode) 0);
            Cursor.set_visible(true);
            ((Behaviour) this.MyPlayer.firstPersonController).set_enabled(false);
            ((Animator) this.MyPlayer.charAnim).SetFloat("speed", 0.0f);
          }
        }
        if (((ButtonControl) current.get_f1Key()).get_wasPressedThisFrame() && this.KeybindSpeed)
        {
          this.SpeedHack = !this.SpeedHack;
          if (this.SpeedHack)
          {
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_WalkSpeed = (__Null) 3.59999990463257;
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_RunSpeed = (__Null) 4.80000019073486;
          }
          else
          {
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_WalkSpeed = (__Null) 1.20000004768372;
            ((FirstPersonController) this.MyPlayer.firstPersonController).m_RunSpeed = (__Null) 1.60000002384186;
          }
        }
        if (((ButtonControl) current.get_f2Key()).get_wasPressedThisFrame() && this.KeybindNoclip)
        {
          this.noclip = !this.noclip;
          if (this.noclip)
          {
            ((Rigidbody) ((Component) this.MyPlayer).GetComponent<Rigidbody>()).set_useGravity(false);
            ((Collider) this.MyPlayer.charController).set_enabled(false);
          }
          else
          {
            ((Rigidbody) ((Component) this.MyPlayer).GetComponent<Rigidbody>()).set_useGravity(true);
            ((Collider) this.MyPlayer.charController).set_enabled(true);
          }
        }
        if (((ButtonControl) current.get_f3Key()).get_wasPressedThisFrame() && this.KeybindRandom && Object.op_Inequality((Object) Cheat.ghostAI, (Object) null))
        {
          ((GhostActivity) Cheat.ghostAI.ghostActivity).InteractWithARandomDoor();
          ((GhostActivity) Cheat.ghostAI.ghostActivity).InteractWithARandomProp();
          ((GhostActivity) Cheat.ghostAI.ghostActivity).Interact();
          Cheat.ghostAI.RandomEvent();
        }
        if (((ButtonControl) current.get_f4Key()).get_wasPressedThisFrame() && this.KeybindHunt && Object.op_Inequality((Object) Cheat.ghostAI, (Object) null))
        {
          ((SetupPhaseController) SetupPhaseController.instance).isSetupPhase = (__Null) 0;
          Cheat.ghostAI.canAttack = (__Null) 1;
          Cheat.ghostAI.canEnterHuntingMode = (__Null) 1;
          ((Animator) Cheat.ghostAI.anim).SetBool("isIdle", false);
          ((Animator) Cheat.ghostAI.anim).SetInteger("WalkType", 1);
          ((NavMeshAgent) Cheat.ghostAI.agent).set_speed((float) Cheat.ghostAI.defaultSpeed);
          ((GhostInteraction) Cheat.ghostAI.ghostInteraction).CreateAppearedEMF(((Component) Cheat.ghostAI).get_transform().get_position());
          Vector3.get_zero();
          float num = Random.Range(2f, 15f);
          NavMeshHit navMeshHit;
          Vector3 vector3 = !NavMesh.SamplePosition(Vector3.op_Addition(Vector3.op_Multiply(Random.get_insideUnitSphere(), num), ((Component) Cheat.ghostAI).get_transform().get_position()), ref navMeshHit, num, 1) ? Vector3.get_zero() : ((NavMeshHit) ref navMeshHit).get_position();
          ((NavMeshAgent) Cheat.ghostAI.agent).SetDestination(vector3);
          ((SetupPhaseController) SetupPhaseController.instance).ForceEnterHuntingPhase();
          Cheat.ghostAI.ChangeState((GhostAI.States) 2, (PhotonObjectInteract) null, (PhotonObjectInteract[]) null);
          ((PhotonView) Cheat.ghostAI.view).RPC("Hunting", (PhotonTargets) 0, new object[1]
          {
            (object) true
          });
          ((PhotonView) Cheat.ghostAI.view).RPC("SyncChasingPlayer", (PhotonTargets) 0, new object[1]
          {
            (object) true
          });
        }
        if (((ButtonControl) current.get_f5Key()).get_wasPressedThisFrame() && this.KeybindIdle && Object.op_Inequality((Object) Cheat.ghostAI, (Object) null))
        {
          ((Animator) Cheat.ghostAI.anim).SetInteger("IdleNumber", Random.Range(0, 2));
          ((Animator) Cheat.ghostAI.anim).SetBool("isIdle", true);
          Cheat.ghostAI.UnAppear(false);
          ((GhostAudio) Cheat.ghostAI.ghostAudio).TurnOnOrOffAppearSource(false);
          ((GhostAudio) Cheat.ghostAI.ghostAudio).PlayOrStopAppearSource(false);
          Cheat.ghostAI.ChangeState((GhostAI.States) 0, (PhotonObjectInteract) null, (PhotonObjectInteract[]) null);
          ((PhotonView) Cheat.ghostAI.view).RPC("Hunting", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
          ((PhotonView) Cheat.ghostAI.view).RPC("SyncChasingPlayer", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
        }
        if (((ButtonControl) current.get_f6Key()).get_wasPressedThisFrame() && this.KeybindWander && Object.op_Inequality((Object) Cheat.ghostAI, (Object) null))
        {
          Cheat.ghostAI.canWander = (__Null) 1;
          ((Animator) Cheat.ghostAI.anim).SetBool("isIdle", false);
          Vector3 vector3 = Vector3.get_zero();
          NavMeshHit navMeshHit;
          if (NavMesh.SamplePosition(Vector3.op_Addition(Vector3.op_Multiply(Random.get_insideUnitSphere(), 3f), ((Component) Cheat.ghostAI).get_transform().get_position()), ref navMeshHit, 3f, 1))
            vector3 = ((NavMeshHit) ref navMeshHit).get_position();
          ((NavMeshAgent) Cheat.ghostAI.agent).set_destination(vector3);
          Cheat.ghostAI.ChangeState((GhostAI.States) 1, (PhotonObjectInteract) null, (PhotonObjectInteract[]) null);
          ((PhotonView) Cheat.ghostAI.view).RPC("Hunting", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
          ((PhotonView) Cheat.ghostAI.view).RPC("SyncChasingPlayer", (PhotonTargets) 0, new object[1]
          {
            (object) false
          });
        }
        if (this.noclip)
        {
          if (((ButtonControl) current.get_wKey()).get_isPressed())
          {
            float num1 = 1f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            Transform transform = ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform();
            transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform().TransformDirection(vector3)));
          }
          if (((ButtonControl) current.get_sKey()).get_isPressed())
          {
            float num1 = -1f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            Transform transform = ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform();
            transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform().TransformDirection(vector3)));
          }
          if (((ButtonControl) current.get_aKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = -1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            Transform transform = ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform();
            transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform().TransformDirection(vector3)));
          }
          if (((ButtonControl) current.get_dKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            Transform transform = ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform();
            transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform().TransformDirection(vector3)));
          }
          if (((ButtonControl) current.get_qKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            float num3 = 1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, num3, num1);
            Transform transform = ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform();
            transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform().TransformDirection(vector3)));
          }
          if (((ButtonControl) current.get_eKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            float num3 = -1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, num3, num1);
            Transform transform = ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform();
            transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player).firstPersonController).get_transform().TransformDirection(vector3)));
          }
        }
      }
      if (PhotonNetwork.get_inRoom() && Object.op_Equality((Object) Cheat.levelController, (Object) null))
      {
        if (((ButtonControl) current.get_insertKey()).get_wasPressedThisFrame())
        {
          this.showGUI2 = !this.showGUI2;
          if (this.showGUI2)
          {
            Cursor.set_lockState((CursorLockMode) 0);
            Cursor.set_visible(true);
            if (PhotonNetwork.get_inRoom())
            {
              ((Behaviour) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).set_enabled(false);
              ((Animator) ((Player) ((MainManager) MainManager.instance).localPlayer).charAnim).SetFloat("speed", 0.0f);
            }
          }
          if (!this.showGUI2)
          {
            Cursor.set_lockState((CursorLockMode) 2);
            Cursor.set_visible(false);
            if (PhotonNetwork.get_inRoom())
            {
              ((Behaviour) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).set_enabled(true);
              ((Animator) ((Player) ((MainManager) MainManager.instance).localPlayer).charAnim).SetFloat("speed", 0.0f);
            }
          }
        }
        if (((ButtonControl) current.get_f1Key()).get_wasPressedThisFrame() && this.KeybindSpeed)
        {
          this.SpeedHack2 = !this.SpeedHack2;
          if (this.SpeedHack2)
          {
            if (PhotonNetwork.get_inRoom())
            {
              ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_WalkSpeed = (__Null) 3.59999990463257;
              ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_RunSpeed = (__Null) 4.80000019073486;
            }
          }
          else if (PhotonNetwork.get_inRoom())
          {
            ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_WalkSpeed = (__Null) 1.20000004768372;
            ((FirstPersonController) ((Player) ((MainManager) MainManager.instance).localPlayer).firstPersonController).m_RunSpeed = (__Null) 1.60000002384186;
          }
        }
        if (((ButtonControl) current.get_f2Key()).get_wasPressedThisFrame() && this.KeybindNoclip)
        {
          this.noclip2 = !this.noclip2;
          if (this.noclip2)
          {
            if (PhotonNetwork.get_inRoom())
            {
              ((Rigidbody) ((Component) ((MainManager) MainManager.instance).localPlayer).GetComponent<Rigidbody>()).set_useGravity(false);
              ((Collider) ((Player) ((MainManager) MainManager.instance).localPlayer).charController).set_enabled(false);
            }
          }
          else if (PhotonNetwork.get_inRoom())
          {
            ((Rigidbody) ((Component) ((MainManager) MainManager.instance).localPlayer).GetComponent<Rigidbody>()).set_useGravity(true);
            ((Collider) ((Player) ((MainManager) MainManager.instance).localPlayer).charController).set_enabled(true);
          }
        }
        if (this.noclip2)
        {
          if (((ButtonControl) current.get_wKey()).get_isPressed())
          {
            float num1 = 1f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            if (PhotonNetwork.get_inRoom())
            {
              Transform transform = ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform();
              transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().TransformDirection(vector3)));
            }
          }
          if (((ButtonControl) current.get_sKey()).get_isPressed())
          {
            float num1 = -1f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            if (PhotonNetwork.get_inRoom())
            {
              Transform transform = ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform();
              transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().TransformDirection(vector3)));
            }
          }
          if (((ButtonControl) current.get_aKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = -1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            if (PhotonNetwork.get_inRoom())
            {
              Transform transform = ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform();
              transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().TransformDirection(vector3)));
            }
          }
          if (((ButtonControl) current.get_dKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, 0.0f, num1);
            if (PhotonNetwork.get_inRoom())
            {
              Transform transform = ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform();
              transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().TransformDirection(vector3)));
            }
          }
          if (((ButtonControl) current.get_qKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            float num3 = 1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, num3, num1);
            if (PhotonNetwork.get_inRoom())
            {
              Transform transform = ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform();
              transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().TransformDirection(vector3)));
            }
          }
          if (((ButtonControl) current.get_eKey()).get_isPressed())
          {
            float num1 = 0.0f * this.movementForwardMultiplier * Time.get_deltaTime();
            float num2 = 0.0f * this.movementSideMultiplier * Time.get_deltaTime();
            float num3 = -1f * this.movementSideMultiplier * Time.get_deltaTime();
            Vector3 vector3;
            ((Vector3) ref vector3).\u002Ector(num2, num3, num1);
            if (PhotonNetwork.get_inRoom())
            {
              Transform transform = ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform();
              transform.set_position(Vector3.op_Addition(transform.get_position(), ((Component) ((MainManager) MainManager.instance).localPlayer).get_transform().TransformDirection(vector3)));
            }
          }
        }
      }
      yield return (object) new WaitForEndOfFrame();
    }

    private Player MyPlayer => (Player) ((PlayerData) ((GameController) GameController.instance).myPlayer).player;

    private PhotonPlayer MyPlayer2 => (PhotonPlayer) ((PlayerData) ((GameController) GameController.instance).myPlayer).photonPlayer;

    private List<PlayerData> Players => (List<PlayerData>) ((GameController) GameController.instance).playersData;

    private List<PlayerServerSpot> PlayerSpots => (List<PlayerServerSpot>) Cheat.serverManager.players;

    public Cheat() => base.\u002Ector();
  }
}
