/*
    TapEffectAnimation.cs

    �^�b�v�G�t�F�N�g�E�����O�^�b�v�G�t�F�N�g�A�j���[�V�����N���X
*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TapEffectAnimation : MonoBehaviour
{
    // �X�v���C�g�z��̓Y�����w��p
    private int spritesNum;

    /// <summary>
    /// �C�ӂ̕b���҂�����ɃX�v���C�g��؂�ւ��鏈��
    /// </summary>
    /// <param name="_sprites">�g�p����X�v���C�g���i�[���ꂽ�z��</param>
    /// <param name="_samples">�҂b��</param>
    /// <returns></returns>
    public IEnumerator EffectAnimation(Sprite[] _sprites, float _samples)
    {
        // �w�肵���b���҂�
        yield return new WaitForSeconds(_samples);

        // �X�v���C�g���i�[����Ă���z��̓Y������ύX
        if (spritesNum < _sprites.Length - 1)
        {
            spritesNum++;
        }
        else
        {
            // �Y�����A�X�v���C�g�̃��Z�b�g
            spritesNum = 0;
            this.gameObject.GetComponent<Image>().sprite = _sprites[spritesNum];

            // �I�u�W�F�N�g���\��
            this.gameObject.SetActive(false);

            // �����I��肽���Ƃ��� yield break
            yield break;
        }

        // �X�v���C�g��ύX���A�j���[�V����
        this.gameObject.GetComponent<Image>().sprite = _sprites[spritesNum];

        // �҂�����ɂ�����x�Ăԁ@�ċA����
        StartCoroutine(EffectAnimation(_sprites, _samples));
    }

}
