/*
    TextTest.cs
    2024/10/07  Kawahara Rina

    �uHellow World�v����ʂɕ\������N���X
    �p�b�P�[�W�����đ��v���W�F�N�g�ł��g�p�ł��邩�̃e�X�g
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTest : MonoBehaviour
{
    // �g�p����e�L�X�g
    [SerializeField] private Text testText;  // �uHellow World�v��\������e�L�X�g 

    // �uHellow World�v��\������֐�
    // TODO Common�Ɉڍs
    /// <summary>
    /// �e�L�X�g��\������֐�
    /// </summary>
    /// <param name="_msg"> �\�����������e</param>
    /// <param name="_text">�g�p����e�L�X�g</param>
    private void ShowText(string _msg,Text _text)
    {
        // �w�肵���e�L�X�g��\��
        _text.text = _msg;
    }

    // ����������
    private void Init() {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        // �uHellow World�v��\������
        ShowText("Hello World",testText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
