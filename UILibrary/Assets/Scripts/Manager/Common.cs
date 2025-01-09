/*
    Common.cs
    2024/10/11�@Kawahara Rina

    �����̃X�N���v�g����g�p����萔��ėp�֐��Ȃǂ��܂Ƃ߂��N���X
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Common
{
    // ���ʒ萔
    // �X�P�[���̍ő�l�E�ŏ��l
    public const float MAX_SCALE = 1.0f;
    public const float MIN_SCALE = 0.0f;

    // �����x�̍ő�l�E�ŏ��l
    public const float MAX_ALPHA = 1.0f;
    public const float MIN_ALPHA = 0.0f;

    // ���̑����̍ő�l�E�ŏ��l
    public const float MAX_THICKNESS = 10.0f;
    public const float MIN_THICKNESS = 0.1f;

    // �Đ����x�̍ő�l�E�ŏ��l
    public const float MAX_SAMPLES = 4.0f;
    public const float MIN_SAMPLES = 0.1f;

    // �^�b�v�G�t�F�N�g�֘A
    public const int GENERATE_COUNT = 120;   // �v���t�@�u�����������̌�
    public const float GENERATE_POS = 100;   // �v���t�@�u�����������̍��W

    // �����_�ȉ��̌����w��p
    public enum DecimalPlace
    {
        None,
        First,
        Second
    };

    /// <summary>
    /// �����_�ʒu��Ԃ��֐�
    /// </summary>
    /// <returns></returns>
    public static string SetDecimalPlace(DecimalPlace _place)
    {
        var format = "";

        // �����_�ʒu�w��
        switch (_place)
        {
            // �����_�Ȃ�
            case DecimalPlace.None:
                format = "F0";
                break;

            // �����_��1�ʂ܂ŕ\��
            case DecimalPlace.First:
                format = "F1";
                break;

            // �����_��2�ʂ܂ŕ\��
            case DecimalPlace.Second:
                format = "F2";
                break;
        }

        return format;
    }

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
