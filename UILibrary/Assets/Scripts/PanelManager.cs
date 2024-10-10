using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // ズームイン・アウトするパネル
    [SerializeField] private GameObject panelZoom;

    // フラグをセットする関数
    public void SetBool(bool _flag)
    {
        // アニメーションのアクティブフラグセット
        var anim = panelZoom.GetComponent<Animator>();
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
