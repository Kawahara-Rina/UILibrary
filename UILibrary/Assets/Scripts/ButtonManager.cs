/*
    ButtonManager.cs
    2024/10/09  Kawahara Rina

    �{�^���̃A�j���[�V�����𐧌䂷��N���X
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // �A�j���[�^�[�擾�p
    private Animator animator;

    // ���N�g�g�����X�t�H�[���擾�p
    private Vector2 rTransform;

    private float width;    // �{�^���̕�  
    private float height;   // �{�^���̍���

    // �t���O���Z�b�g����֐�
    public void SetPointerEnterBool(bool _flag)
    {
        animator.SetBool("isPointerEnter", _flag);
    }

    // �T�C�Y������������
    private void ReduceSize()
    {
        rTransform.x =width*0.8f;
        rTransform.y = height*0.8f;

        GetComponent<RectTransform>().sizeDelta = rTransform;

    }

    // �T�C�Y�����ɂ��ǂ�
    private void IncreaseSize()
    {
        rTransform.x = width;
        rTransform.y = height;

        GetComponent<RectTransform>().sizeDelta = rTransform;

    }

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�[�擾
        animator = GetComponent<Animator>();

        // ���N�g�g�����X�t�H�[���擾
        rTransform = GetComponent<RectTransform>().sizeDelta;

        // �{�^���̕��ƍ����擾
        width = rTransform.x;
        height = rTransform.y;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
