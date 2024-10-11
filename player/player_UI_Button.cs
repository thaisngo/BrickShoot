using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_UI_Button : MonoBehaviour
{
    public List<GameObject> arrButton = new List<GameObject>();
    private void Start()
    {
        ButtonUI();
    }

    public void ButtonUI() //chiều dọc màn hình chia làm 4 là 4 button ấn để gạch bắn lên
    {
        float t = 0;
        for (int i = 0; i < 4; i++)
        {
            arrButton[i].GetComponent<RectTransform>().sizeDelta = new Vector2(SinhHangGach.instance.sizeScreen.x * (1f / 4), SinhHangGach.instance.sizeScreen.y);
            arrButton[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * ((-3f / 8) + t), 0);
            t += (1f / 4);
        }
    }
}
