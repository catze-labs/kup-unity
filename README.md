![image](https://user-images.githubusercontent.com/65929678/202863644-a3d8c0fb-a2d9-400c-8928-2ad47cb6871a.png)

> 🎉 KUP won 1st place in The Metaverse+ NFTs Track at KlayMakers2022. 🎉  
> https://dorahacks.io/hackathon/klaymakers22/results

# kup-unity

# Klaymakers2022 KUP information <br/>
Gitbook: https://kup.gitbook.io <br/>
Website: https://kup.vercel.app/ <br/>

### **Relational Repositories**<br/>
Unity Client Repository: https://github.com/catze-labs/kup-unity<br/>
Linking Playfab with Unity Repository: https://github.com/catze-labs/kup-playfab<br/>
Demo Dapp interacting with Klaytn Repository: https://github.com/catze-labs/KUP<br/>

### Assets list in use
| Name | Range | Link |
| --- | --- | --- |
| PlayFab SDK | PlayFab Development Kit for Unity | https://learn.microsoft.com/ko-kr/gaming/playfab/sdks/unity3d/ |
| Chop Chop | Unity Open Project | https://github.com/UnityTechnologies/open-project-1 |

KUP 게임 서버는 PlayFab을 사용합니다. Unity 클라이언트에서 PlayFab과 통합하려면 PlayFab에서 제공하는 SDK를 사용해야 합니다.

Chop Chop은 Unity Technology에서 진행했었던 Open Project 입니다. 해당 오픈 소스를 활용하여 구현하였습니다.

### 사용자 로그인

PlayFab SDK에서 제공하는 PlayFabClientAPI를 사용하여 로그인 기능을 구현할 수 있습니다.

로그인 기능은 LoginWithEmailAddress 기능을 사용하여 구현되었습니다. 로그인에 성공하면 콜백에서 수신한 결과에서 PlayFabId를 수신하고 필요에 따라 다른 API에서 사용할 수 있습니다. 이 기능에 대한 자세한 내용 은 다음 페이지를 참조하십시오.

### 기록 저장 및 불러오기

KUP 게임 클라이언트에서 플레이어의 기록은 PlayFab에 저장됩니다. 기록을 저장 및 불러오기에 사용된 API는 다음과 같습니다.

| Name | Description | Link |
| --- | --- | --- |
| Update Player Statistics | 플레이어의 기록을 저장합니다. | https://learn.microsoft.com/en-us/rest/api/playfab/client/player-data-management/update-player-statistics?view=playfab-rest |
| Get Player Statistics | 플레이어의 기록을 불러옵니다. | https://learn.microsoft.com/en-us/rest/api/playfab/server/player-data-management/get-player-statistics?view=playfab-rest |
