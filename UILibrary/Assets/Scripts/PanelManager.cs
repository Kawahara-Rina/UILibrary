using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // �Y�[���C���E�A�E�g����p�l��
    [SerializeField] private GameObject panelZoom;

    // �t���O���Z�b�g����֐�
    public void SetBool(bool _flag)
    {
        // �A�j���[�V�����̃A�N�e�B�u�t���O�Z�b�g
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
