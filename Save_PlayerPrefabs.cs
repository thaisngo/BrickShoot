using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Save_PlayerPrefabs : MonoBehaviour
{
    public static void SaveDiem(int score)
    {
        PlayerPrefs.SetInt("tongDiem", score);
        PlayerPrefs.Save();
    }   

    public static int GetDiem()
    {
        if (PlayerPrefs.HasKey("tongDiem"))
        {
            int diemSo = PlayerPrefs.GetInt("tongDiem");
            return diemSo;
        }
        return 0;
    }


    public static int Set_diemCao()
    {
        if(GetDiem() > Get_High_Score())
        {
            PlayerPrefs.SetInt("high_Score", GetDiem());
            return GetDiem();
        }
        else
        {
            PlayerPrefs.SetInt("high_Score", Get_High_Score());
            return Get_High_Score();
        }
    }

    public static int Get_High_Score()
    {
        if (PlayerPrefs.HasKey("high_Score"))
        {
            int diemSoCao = PlayerPrefs.GetInt("high_Score");
            return diemSoCao;
        }
        return 0;
    }

    public static void Save_SoCombo()
    {
        PlayerPrefs.SetInt("so_Combo", SinhHangGach.instance.dem_So_Combo);
        PlayerPrefs.Save();
    }

    public static int Get_SoCombo()
    {
        if (PlayerPrefs.HasKey("so_Combo"))
        {
            int soComBo = PlayerPrefs.GetInt("so_Combo");
            return soComBo;
        }
        return 0;
    }

    public static void Set_hightCombo()
    {
        PlayerPrefs.SetInt("high_combo", SinhHangGach.instance.max_combo_1lan);
        PlayerPrefs.Save();
    }

    public static int Get_Hight_Combo()
    {
        if (PlayerPrefs.HasKey("high_combo"))
        {
            int hightCombo = PlayerPrefs.GetInt("high_combo");
            return hightCombo;
        }
        return 0;
    }
}
