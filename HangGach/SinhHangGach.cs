using System.Collections.Generic;
using UnityEngine;
public class SinhHangGach : HangGach
{
    public static SinhHangGach instance;
    public Canvas cv;
    public Vector2 sizeScreen;

    public List<HangGach> arr_hang_Gach;
    public List<HangGach> arr_Hang_Gach_Day;
    public HangGach HangGachPrefabs;

    public float vanTocMoveHangXuong;
    private float time = 0;
    public bool check_lan_dau = false;

    public int combo_1lan = 0;
    public int dem_So_Combo = 0;

    public AudioSource audio_nen;
    public AudioSource audio_ThemHangGach;
    public AudioSource audio_PhaHangGach;

    private void Awake()
    {
        instance = this;
        audio_nen.Play();
    }
    void Start()
    {
        Application.targetFrameRate = 60;
        sizeScreen = cv.GetComponent<RectTransform>().sizeDelta;
        Sinh_Hang_Gach();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 1)
        {
            vanTocMoveHangXuong += 0.05f;
            time = 0;
        }
    }

    public void Sinh_Hang_Gach()  // Sinh hàng gạch random move từ trên xuống
    {
        HangGach hg = Instantiate(HangGachPrefabs, this.transform);
        hg.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 1000f);
        hg.Check_KhoiTao(false);
        hg.HangGachMacDinh();
        arr_hang_Gach.Add(hg);
    }

    public void Sinh_Hang_Gach_Duoi_Cung(int idCol)
    {
        HangGach hg = Instantiate(HangGachPrefabs, this.transform);
        arr_hang_Gach.Insert(0, hg);
        hg.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, arr_hang_Gach[1].transform.GetComponent<RectTransform>().anchoredPosition.y - (sizeScreen.y * (1.01f / 10))); 
        hg.Check_KhoiTao(true);
        hg.HangGachCoThemMotVienGach(idCol);
    }
}
