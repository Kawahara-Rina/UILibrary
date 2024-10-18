using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapEffectManager : MonoBehaviour
{
    #region - �g�p����摜���i�[����z��
    [Header("�g�p����摜(�A�j���[�V������)")]
    [Tooltip("2�`5���H")]
    #endregion
    [SerializeField] public Sprite[] sprites;

    #region - �A�j���[�V�����̑��x
    [Header("�A�j���[�V�����̑��x")]
    [Tooltip("0.1�`2.0�̒l�B0���x��")]
    [Range(Common.MIN_SAMPLES, Common.MAX_SAMPLES)]
    #endregion
    [SerializeField] public float samples;

    #region - �^�b�v�G�t�F�N�g�v���t�@�u
    [Header("�v���t�@�u �hTapEffect�h���i�[")]
    [Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    [SerializeField] GameObject tapEffectPrefab;

    #region - �^�b�v�G�t�F�N�g��\������L�����o�X
    [Header("�^�b�v�G�t�F�N�g��\������L�����o�X")]
    //[Tooltip("Assets/Resources/Prefabs/TapEffect")]
    #endregion
    // �\������L�����o�X
    [SerializeField] GameObject canvas;
    

    // ����������
    private void Init()
    {
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        // �^�b�v�G�t�F�N�g�v���t�@�u�𐶐�
        var obj = Instantiate(tapEffectPrefab);
        obj.transform.SetParent(canvas.transform, false);

        //var tapEffect = tapEffectPrefab.GetComponent<TapEffect>();

        //StartCoroutine(tapEffect.EffectAnimation(sprites, samples,1.0f));

    }

    // Update is called once per frame
    void Update()
    {
    }
}
