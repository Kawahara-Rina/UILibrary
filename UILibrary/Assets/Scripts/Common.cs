using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    // �I�u�W�F�N�g���A�N�e�B�u�E��A�N�e�B�u�ɂ���֐�
    public static void SetActive(GameObject _gameObject,bool _bool)
    {
        _gameObject.SetActive(_bool);
    }

    // �x�������֐�
    public static IEnumerator WaitForSecond(float _sec)
    {
        // �w�肵���b���҂�
        yield return new WaitForSeconds(_sec);
    }

}
