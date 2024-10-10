using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // �Y�[���C���E�A�E�g����p�l��
    [SerializeField] private GameObject panelZoom;
    // �X���C�h�C���E�A�E�g����p�l��
    [SerializeField] private GameObject panelSlide;

    // �Y�[������p�l���̃A�N�e�B�u�t���O���Z�b�g����֐�
    public void PanelZoomSetBool(bool _flag)
    {
        // �t���O��true�̏ꍇ�̓p�l����\������
        if (_flag)
            Common.SetActive(panelZoom, _flag);

        // �A�j���[�V�����̃A�N�e�B�u�t���O�Z�b�g
        var anim = panelZoom.GetComponent<Animator>();
        anim.SetBool("isActive", _flag);
    }

    // �X���C�h����p�l���̃A�N�e�B�u�t���O���Z�b�g����֐�
    public void PanelSlideSetBool(bool _flag)
    {
        // �t���O��true�̏ꍇ�̓p�l����\������
        if (_flag)
            Common.SetActive(panelSlide, _flag);

        // �A�j���[�V�����̃A�N�e�B�u�t���O�Z�b�g
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
