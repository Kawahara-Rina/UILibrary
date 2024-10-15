/*
    Common.cs
    2024/10/11�@Kawahara Rina

    �����̃X�N���v�g����g�p����萔��ėp�֐��Ȃǂ��܂Ƃ߂��N���X
*/using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Common
{
    // ���ʒ萔
    public const float MAX_SCALE = 1.0f;
    public const float MIN_SCALE = 0.0f;

    /*
    // �񋓑̃V���A���C�Y����ƃC���X�y�N�^���烊�X�g�őI�ׂ�
    [SerializeField] test testa;

    enum test
    {
        a,
        b
    }

    // Header�F�C���X�y�N�^�ɕϐ��̐����o�Ă���
    // Tooltip�F�ϐ��ɃJ�[�\�����킹�����ɕϐ��̐����o�Ă���
    
    [Header("�R�����g")]
    [SerializeField] private GameObject a;

    [Header("bbb")]
    [SerializeField] private GameObject b;

    [Tooltip("bbb")]
    [SerializeField] private GameObject b;
    */



    /// <summary>
    /// �I�u�W�F�N�g���A�N�e�B�u�E��A�N�e�B�u�ɂ���֐�
    /// </summary>
    /// <param name="_gameObject">�A�N�e�B�u�E��A�N�e�B�u�ɂ���I�u�W�F�N�g</param>
    /// <param name="_bool">�A�N�e�B�u����A�N�e�B�u���̃u�[���l</param>
    public static void SetActive(GameObject _gameObject,bool _bool)
    {
        _gameObject.SetActive(_bool);
    }

    /// <summary>
    /// �e�L�X�g��\������֐�
    /// </summary>
    /// <param name="_msg"> �\�����������e</param>
    /// <param name="_text">�g�p����e�L�X�g</param>
    private void ShowText(string _msg, Text _text)
    {
        // �w�肵���e�L�X�g��\��
        _text.text = _msg;
    }

    // �x�������֐�
    /*
    public static IEnumerator WaitForSecond(float _sec)
    {
        // �w�肵���b���҂�
        yield return new WaitForSeconds(_sec);
    }
    */
}
