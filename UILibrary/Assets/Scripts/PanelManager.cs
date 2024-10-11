/*
    PanelManager.cs
    2024/10/11  Kawahara Rina

    �p�l���̃A�j���[�V�����������Ǘ�����N���X 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    // Animator�擾�p
    private Animator animator;

    // �Y�[������p�l���̃A�N�e�B�u�t���O���Z�b�g����֐�
    public void SetBool(bool _flag)
    {
        // �t���O��true�̏ꍇ�̓p�l����\������
        if (_flag)
            Common.SetActive(gameObject, _flag);

        // �A�j���[�V�����̃A�N�e�B�u�t���O�Z�b�g
        animator.SetBool("isActive", _flag);
    }

    // ����������
    // �I�u�W�F�N�g����A�N�e�B�u��Ԃł����s�������̂�Awake�֐����g��
    private void Awake()
    {
        // Animator�擾
        animator = GetComponent<Animator>();
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
