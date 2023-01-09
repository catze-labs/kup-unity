![image](https://user-images.githubusercontent.com/65929678/202863644-a3d8c0fb-a2d9-400c-8928-2ad47cb6871a.png)

> 🎉 KUP won 1st place in The Metaverse+ NFTs Track at KlayMakers2022. 🎉  
> https://dorahacks.io/hackathon/klaymakers22/results

# kup-unity

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

KUP game server uses PlayFab. To integrate with PlayFab in the Unity client, you need to use the SDK provided by PlayFab. 

Chop Chop was an Open Project conducted by Unity Technology. We implemented it using the open source.

### User login

You can use PlayFabClientAPI provided by PlayFab SDK to implement login functionality. The login feature is implemented using the LoginWithEmailAddress function. If the login is successful, you can receive the PlayFabId from the results in the callback, and use it in other APIs if necessary. For more information about this function, please refer to the following page.

### Statistics Save & Load

In the KUP game client, the player's records are stored in PlayFab. The APIs used to save and load records are as follows.

| Name | Description | Link |
| --- | --- | --- |
| Update Player Statistics | Updates the values of the specified title-specific statistics for the user. By default, clients are not permitted to update statistics. | https://learn.microsoft.com/en-us/rest/api/playfab/client/player-data-management/update-player-statistics?view=playfab-rest |
| Get Player Statistics | Retrieves the current version and values for the indicated statistics, for the local player. | https://learn.microsoft.com/en-us/rest/api/playfab/server/player-data-management/get-player-statistics?view=playfab-rest |
