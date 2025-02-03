/*
    DialogCloseManager.cs

    �_�C�A���O����邩�����m����}�l�[�W���[
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCloseManager : MonoBehaviour
{
    // �萔
    private const int GAMEOBJECT_PANEL = 1;

    // �_�C�A���O����邩�ǂ����̃t���O
    public bool isClose;

    // �q�I�u�W�F�N�g(�p�l��)�擾
    private GameObject child;

    /// <summary>
    /// ����������
    /// </summary>
    private void Init()
    {
        isClose = false;

        // �q�I�u�W�F�N�g(�p�l��)�擾
        child = gameObject.transform.GetChild(GAMEOBJECT_PANEL).gameObject;
    }

    /// <summary>
    /// �_�C�A���O�����^�C�~���O�ŌĂ΂��֐�
    /// </summary>
    public void CloseDialog()
    {
        isClose = true;
    }

    /// <summary>
    /// �p�l�������\���ɂ��鏈��
    /// </summary>
    private void PanelAnActive()
    {
        child.SetActive(false);
        this.gameObject.SetActive(false);
        isClose = false;
    }

    /// <summary>
    /// �p�l������\�����鏈��
    /// </summary>
    public void PanelActive()
    {
        isClose = false;
        this.gameObject.SetActive(true);
        child.SetActive(true);

    }

    private void Awake()
    {
        // ����������
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (isClose)
        {
            PanelAnActive();
        }
    }
}
