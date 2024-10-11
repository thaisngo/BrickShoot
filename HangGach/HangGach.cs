using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HangGach : HangGach_XuLyVaCham
{
    public GameObject enemy;
    public List<GameObject> points = new List<GameObject>();
   
    private bool check_khoi_tao = false;
    private Vector2 viTriToi;

    private bool check = false;
    private bool check_Hang_Gach_Clone_Them = false;

    public void Check_KhoiTao(bool check_Hang_Gach_Them)
    {
        check_Hang_Gach_Clone_Them = check_Hang_Gach_Them;
        check_khoi_tao = true;
    }

    void Update()  //move hàng gạch xuống
    {
        if (check_Hang_Gach_Clone_Them == false)
        {
            if (check_khoi_tao == false) return;

            if (gameObject.GetComponent<RectTransform>().anchoredPosition.y <= (1000f - (SinhHangGach.instance.sizeScreen.y * (1.01f / 10))) && check == false)
            {
                SinhHangGach.instance.Sinh_Hang_Gach();
                check = true;
            }            
            HangGachOverGame();
        }

        else
        {
            if (check_khoi_tao == false) return;           
            HangGachOverGame();
        }
    }

    private void HangGachOverGame() // hàng gạch không ở vị trí trong màn hình
    {
        viTriToi = new Vector2(GetComponent<RectTransform>().anchoredPosition.x, SinhHangGach.instance.sizeScreen.y * (-1f / 2) - SinhHangGach.instance.sizeScreen.y * (1f / 20));
        GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(GetComponent<RectTransform>().anchoredPosition, viTriToi, SinhHangGach.instance.vanTocMoveHangXuong);

        if (gameObject.GetComponent<RectTransform>().anchoredPosition.y <= (297f - (SinhHangGach.instance.sizeScreen.y * (1f / 2) - (SinhHangGach.instance.sizeScreen.y * (1f / 20)))))
        {
            SinhHangGach.instance.dem_So_Combo++;
            SinhHangGach.instance.arr_Combo_1lan.Add(SinhHangGach.instance.combo_1lan);

            SinhHangGach.instance.max_Combo_1Lan();
            Save_PlayerPrefabs.Set_hightCombo();
            Save_PlayerPrefabs.Save_SoCombo();
            SinhHangGach.instance.combo_1lan = 0;
            SceneManager.LoadScene("overGame");
        }
    }

    public void HangGachMacDinh() // Hàng gạch tạo ra để move xuống từ hệ thống (khi chưa va chạm)
    {       
        int rd = Random.Range(0, 4);
        arr_oTrong.Add(rd);
        for (int i = 0; i < 4; i++)
        {
            if (i != rd)
            {
                HangGachChiCoMotVienGach(i);
            }           
        }
    }

    public void HangGachCoThemMotVienGach(int id) // Hàng gạch găm vào vị trí thiếu của hàng gạch chưa đầy
    {
        for (int i = 0; i < 4; i++)
        {
            if (i != id)
            {
                arr_oTrong.Add(i);
            }
        }
        HangGachChiCoMotVienGach(id);
    }

    public void HangGachChiCoMotVienGach(int idCol) // Hàng gạch được tạo từ 1 viên gạch đầu tiên
    {
        GameObject enemy0 = Instantiate(enemy, this.transform);
        enemy0.transform.position = points[idCol].transform.position;
        enemy0.GetComponent<BoxCollider2D>().size = new Vector2(SinhHangGach.instance.sizeScreen.x / (1.2f * 4), SinhHangGach.instance.sizeScreen.y / (1f * 10));
        enemy0.GetComponent<RectTransform>().sizeDelta = new Vector2(SinhHangGach.instance.sizeScreen.x / 4, SinhHangGach.instance.sizeScreen.y * (1f / 10));

        if (idCol == 0)
        {
            enemy0.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (-3f / 8), 0);
        }

        else if (idCol == 1)
        {
            enemy0.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (-1f / 8), 0);
        }

        else if (idCol == 2)
        {
            enemy0.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (1f / 8), 0);
        }

        else
        {
            enemy0.GetComponent<RectTransform>().anchoredPosition = new Vector2(SinhHangGach.instance.sizeScreen.x * (3f / 8), 0);
        }
    }
}
