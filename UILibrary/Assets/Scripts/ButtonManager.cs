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
    #region - �X�P�[���̍ő�l
    [Header("�X�P�[���̍ő�l(�g�厞)")][Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_SCALE,Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float maxScale;

    #region - �X�P�[���̍ŏ��l
    [Header("�X�P�[���̍ŏ��l(�k����)")][Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float minScale;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")][Tooltip("0.0�`1.0�̒l�B0��������")]
    [Range(Common.MIN_SCALE, Common.MAX_SCALE)]
    #endregion
    [SerializeField] private float samples;

    // �X�P�[����ύX����֐�
    /// <summary>
    /// �X�P�[�����w�肵���l�ɕύX����֐�
    /// </summary>
    /// <param name="_x">�X�P�[����x����</param>
    /// <param name="_y">�X�P�[����y����</param>
    private void SetScale(float _x,float _y)
    {
        // �X�P�[���������̒l�ɕύX
        var newScale=new Vector3(0,0,0);
        newScale.x =_x;
        newScale.y =_y;

        // �q�I�u�W�F�N�g�̃X�P�[����ύX
        this.gameObject.transform.GetChild(0).localScale = newScale;
    }


    // �T�C�Y������������
    public void ReduceSize()
    {
        // �X�P�[����ύX
        SetScale(minScale,minScale);
    }

    // �T�C�Y�����ɂ��ǂ�
    public void IncreaseSize()
    {
        // �X�P�[����ύX
        SetScale(maxScale, maxScale);
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
