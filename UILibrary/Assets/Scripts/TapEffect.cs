using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapEffect : MonoBehaviour
{

    // �X�v���C�g�z��̓Y�����w��p
    private int spritesNum;

    // �^�b�v�G�t�F�N�g�}�l�[�W���[�擾
    private TapEffectManager tapEffectManager;

    public IEnumerator EffectAnimation(Sprite[] _sprites, float _samples, float _sec)
    {
        // �w�肵���b���҂�
        yield return new WaitForSeconds(_sec);

        // �X�v���C�g���i�[����Ă���z��̓Y������ύX
        if (spritesNum < _sprites.Length - 1)
        {
            spritesNum++;
        }
        else
        {
            // �Y�����̃��Z�b�g
            spritesNum = 0;
            // �I�u�W�F�N�g���폜
            Destroy(gameObject);

            // �����I��肽���Ƃ��� yield break
            yield break;
        }

        // �X�v���C�g��ύX���A�j���[�V����
        this.gameObject.GetComponent<Image>().sprite = _sprites[spritesNum];

        // �҂�����ɂ�����x�Ăԁ@�ċA����
        StartCoroutine(EffectAnimation(_sprites, _samples, _sec));
    }



    // Start is called before the first frame update
    void Start()
    {
        tapEffectManager =GameObject.Find("TapEffectManager").GetComponent<TapEffectManager>();

        StartCoroutine(EffectAnimation(tapEffectManager.sprites, tapEffectManager.samples,1.0f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
