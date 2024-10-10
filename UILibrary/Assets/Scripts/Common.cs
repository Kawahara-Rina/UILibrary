using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common
{
    // ’x‰„ˆ—ŠÖ”
    public static IEnumerator WaitForSecond(float _sec)
    {
        // w’è‚µ‚½•b”‘Ò‚Â
        yield return new WaitForSeconds(_sec);
    }

}
