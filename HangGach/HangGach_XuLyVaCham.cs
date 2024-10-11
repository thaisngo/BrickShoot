using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HangGach_XuLyVaCham : MonoBehaviour
{
    public int tong = 0;
    public TextMeshProUGUI diemText;

    public List<int> arr_Combo_1lan;
    public List<int> arr_oTrong = new List<int>();
    public int max_combo_1lan;

    public void TinhDiem(int diem)
    {
        tong = tong + diem;
        diemText.text = " Score: " + tong;
    }

    public int max_Combo_1Lan()
    {
        max_combo_1lan = arr_Combo_1lan[0];
        for (int i = 0; i < arr_Combo_1lan.Count; i++)
        {
            if (arr_Combo_1lan[i] > max_combo_1lan)
            {
                max_combo_1lan = arr_Combo_1lan[i];
            }
        }
        return max_combo_1lan;
    }

    public bool HangGachDay()
    {
        if (arr_oTrong.Count == 1)
        {
            return true;
        }
        return false;
    }

    public int Check_OTrong_HangGachday()
    {
        if (HangGachDay())
            return arr_oTrong[0];
        return -1;
    }
}
