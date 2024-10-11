using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void BatDauChoi()
    {
        SceneManager.LoadScene("manChoi");
    }

    public void ThoatManChoi()
    {
        SceneManager.LoadScene("gioiThieu");
    }

    public void endGame()
    {
        SceneManager.LoadScene("overGame");
    }

    public void Home()
    {
        SceneManager.LoadScene("gioiThieu");
    }
}
