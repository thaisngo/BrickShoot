using System.Collections.Generic;
using UnityEngine;

public class player_shoot : MonoBehaviour
{
    public Brick_Move ban_Gach_Duoi_Len;   
    public List<GameObject> points = new List<GameObject>();

    public void ButtonPlayerClick(int id)   // Gạch được bắn lên khi player bấm 1 trong 4 Button.
    {
        Brick_Move bg = Instantiate(ban_Gach_Duoi_Len, SinhHangGach.instance.cv.transform);
        bg.GetComponent<RectTransform>().anchoredPosition = points[id].GetComponent<RectTransform>().anchoredPosition;
        bg.GetComponent<RectTransform>().sizeDelta = new Vector2(SinhHangGach.instance.sizeScreen.x / 4, SinhHangGach.instance.sizeScreen.y * (1f / 10));

        if (id < 0 || id > 3) return;
        else
        {
            if (id == 0)
            {
                bg.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (-3f / 8), SinhHangGach.instance.sizeScreen.y * (-1f / 2));
            }
            else if (id == 1)
            {
                bg.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (-1f / 8), SinhHangGach.instance.sizeScreen.y * (-1f / 2));
            }
            else if (id == 2)
            {
                bg.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (1f / 8), SinhHangGach.instance.sizeScreen.y * (-1f / 2));
            }

            else if (id == 3)
            {
                bg.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (3f / 8), SinhHangGach.instance.sizeScreen.y * (-1f / 2));
            }

            bg.idCol = id;
        }
    }
}
