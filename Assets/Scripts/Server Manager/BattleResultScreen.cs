using UnityEngine.SceneManagement;

public class BattleResultScreen : ServerDisconnection
{
    public void LoadingMainMenu() => LeaveRoom();

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
