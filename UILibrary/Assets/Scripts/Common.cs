using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    // �x�������֐�
    public static IEnumerator WaitForSecond(float _sec)
    {
        // �w�肵���b���҂�
        yield return new WaitForSeconds(_sec);
    }

}
