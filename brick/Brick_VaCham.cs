using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick_VaCham : MonoBehaviour
{
    public GameObject hieu_Ung;
    public GameObject text_combo_1lan;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Brick_Move br_move = gameObject.GetComponent<Brick_Move>();
        HangGach hangGachVaCham = col.transform.parent.GetComponent<HangGach>();
        int index = SinhHangGach.instance.arr_hang_Gach.IndexOf(hangGachVaCham);

        if (col.gameObject.tag == "tagBoxVaCham")
        {
            Destroy(gameObject);

            if (index > 1 && SinhHangGach.instance.arr_hang_Gach[index - 1].HangGachDay() && br_move.idCol == SinhHangGach.instance.arr_hang_Gach[index - 1].Check_OTrong_HangGachday())
            {
                for (int i = 0; i < index - 1; i++)
                {
                    SinhHangGach.instance.arr_hang_Gach[i].transform.GetComponent<RectTransform>().anchoredPosition = SinhHangGach.instance.arr_hang_Gach[i + 1].transform.GetComponent<RectTransform>().anchoredPosition;
                }
                
                Status_PhaHangGach(index - 1, index - 2);
                HieuUngVaCham(index - 2);
            }

            else if (index == 1 && SinhHangGach.instance.arr_hang_Gach[0].HangGachDay() && br_move.idCol == SinhHangGach.instance.arr_hang_Gach[0].Check_OTrong_HangGachday())
            {                
                Status_PhaHangGach(index - 1, 0);
                HieuUngVaCham(0);
            }

            else if ((index >= 1 && SinhHangGach.instance.arr_hang_Gach[index - 1].HangGachDay() == false))
            {
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                Status_ThemHangGachMoi();

                SinhHangGach.instance.arr_hang_Gach[index - 1].GetComponent<HangGach>().HangGachChiCoMotVienGach(br_move.idCol);
                SinhHangGach.instance.arr_hang_Gach[index - 1].GetComponent<HangGach>().arr_oTrong.Remove(br_move.idCol);
            }

            else if (index == 0)
            {
                col.transform.GetComponent<BoxCollider2D>().enabled = false;
                Status_ThemHangGachMoi();

                SinhHangGach.instance.Sinh_Hang_Gach_Duoi_Cung(br_move.idCol);
            }
        }
    }

    private void HieuUngVaCham(int j)
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject hieuUng0 = Instantiate(hieu_Ung);
            hieuUng0.GetComponent<Transform>().position = new Vector2(SinhHangGach.instance.arr_hang_Gach[j].GetComponent<Transform>().position.x, SinhHangGach.instance.arr_hang_Gach[j].GetComponent<Transform>().position.y);
        }
    }

    private void Status_PhaHangGach(int i, int j) // Khi bắn brick vào hàng gạch đầy
    {
        Destroy(SinhHangGach.instance.arr_hang_Gach[i].gameObject);
        SinhHangGach.instance.arr_hang_Gach.RemoveAt(i);

        SinhHangGach.instance.audio_PhaHangGach.Play();
        SinhHangGach.instance.TinhDiem(5);
        Save_PlayerPrefabs.SaveDiem(SinhHangGach.instance.tong);

        SinhHangGach.instance.combo_1lan++;
        SinhHangGach.instance.check_lan_dau = false;

        GameObject text_combo_1lan_0 = Instantiate(text_combo_1lan, SinhHangGach.instance.cv.transform);  // Sinh text combo_1lan ra man hinh
        text_combo_1lan_0.GetComponent<Transform>().position = new Vector2(0f, SinhHangGach.instance.arr_hang_Gach[j].GetComponent<Transform>().position.y);
        text_combo_1lan_0.transform.GetChild(0).GetComponent<Text>().text = " +" + SinhHangGach.instance.combo_1lan;
        Destroy(text_combo_1lan_0, 1f);
    }

    private void Status_ThemHangGachMoi() //Khi bắn brick vào hàng gạch chưa đầy hoặc sinh thêm hàng mới
    {
        if (SinhHangGach.instance.combo_1lan > 0 && SinhHangGach.instance.check_lan_dau == false)
        {
            SinhHangGach.instance.dem_So_Combo++;
            SinhHangGach.instance.arr_Combo_1lan.Add(SinhHangGach.instance.combo_1lan);
            SinhHangGach.instance.check_lan_dau = true;

            SinhHangGach.instance.max_Combo_1Lan();
            SinhHangGach.instance.combo_1lan = 0;

            text_combo_1lan.transform.GetChild(0).GetComponent<Text>().text = " +" + SinhHangGach.instance.combo_1lan;
            Save_PlayerPrefabs.Set_hightCombo();
            Save_PlayerPrefabs.Save_SoCombo();
        }
        SinhHangGach.instance.audio_ThemHangGach.Play();
    }
}
