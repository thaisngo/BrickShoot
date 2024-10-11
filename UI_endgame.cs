using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_endgame : MonoBehaviour
{
    public TextMeshProUGUI diemText_endGame;
    public TextMeshProUGUI diemText_HighScore;
    public Vector2 sizeScreen;
    public GameObject button_Home;
    public GameObject button_PlayAgain;
    public Canvas cv;

    void Start()
    {
         sizeScreen = cv.GetComponent<RectTransform>().sizeDelta;
         UI_start_Endgame();
         DiemUI();
         ButtonUI();
    }

    public void UI_start_Endgame()
    {
        diemText_endGame.text = "" + Save_PlayerPrefabs.GetDiem();
        diemText_HighScore.text = "High Score: " + Save_PlayerPrefabs.Set_diemCao();
    }
    public void DiemUI()
    {
        diemText_endGame.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (1f/3), sizeScreen.y * (1f/ 3));
        diemText_endGame.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, sizeScreen.y * (3.7f / 9));
        
        diemText_HighScore.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (1f / 3), sizeScreen.y * (1f / 3));
        diemText_HighScore.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, sizeScreen.y * (1f/3));
    }

    public void ButtonUI() 
    {
        button_Home.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (1f / 3), sizeScreen.y * (1f / 10));
        button_Home.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * (-1f / 4), sizeScreen.y * (-1f / 4));

        button_PlayAgain.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeScreen.x * (1f / 3), sizeScreen.y * (1f / 10));
        button_PlayAgain.GetComponent<RectTransform>().anchoredPosition = new Vector2(sizeScreen.x * (1f / 4), sizeScreen.y * (-1f / 4));
    }
}
