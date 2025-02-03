/*
    DialogClose.cs

    �_�C�A���O�ȊO�̕������^�b�v�Ń_�C�A���O�����@�\
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogClose : MonoBehaviour
{
    private DialogCloseManager dm;

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        dm = GameObject.Find("DialogCloseManager").GetComponent<DialogCloseManager>();
    }

    /// <summary>
    /// �_�C�A���O����鏈��
    /// </summary>
    private void Close()
    {
        if (dm.isClose)
        {
            // ��\������
            this.gameObject.SetActive(false);
            //dm.FlagReset();
        }
    }


    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        // �_�C�A���O����鏈��
        Close();
    }
}
