using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // ズームイン・アウトするパネル
    [SerializeField] private GameObject panelZoom;
    // スライドイン・アウトするパネル
    [SerializeField] private GameObject panelSlide;

    // ズームするパネルのアクティブフラグをセットする関数
    public void PanelZoomSetBool(bool _flag)
    {
        // フラグがtrueの場合はパネルを表示する
        if (_flag)
            Common.SetActive(panelZoom, _flag);

        // アニメーションのアクティブフラグセット
        var anim = panelZoom.GetComponent<Animator>();
        anim.SetBool("isActive", _flag);
    }

    // スライドするパネルのアクティブフラグをセットする関数
    public void PanelSlideSetBool(bool _flag)
    {
        // フラグがtrueの場合はパネルを表示する
        if (_flag)
            Common.SetActive(panelSlide, _flag);

        // アニメーションのアクティブフラグセット
        var anim = panelSlide.GetComponent<Animator>();
        anim.SetBool("isActive", _flag);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
