using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.VFX;

public class SpellBehavior : MonoBehaviour
{
    public VisualEffect orb;
    public Image wand;
    public GameObject orbObject;

    Vector3 default_wandPostionRot = new Vector3(0, 0, -15f);
    Vector3 default_wandPostionPos = new Vector3(516, -967, -17280f);

    Vector3 spell_1_wandPostion = new Vector3(0, 0, -30f);
    Vector3 spell_2_wandPostion = new Vector3(0, 0, 0f);

    Vector3 spell_4_wandPostion = new Vector3(450, -967, -17280f);
    Vector3 spell_6_wandPostion = new Vector3(600, -967, -17280f);

    public void spell_1()
    {
        Sequence Zoom = DOTween.Sequence();
        Zoom.Append(orb.transform.DOScale(new Vector3(0f, 0f, 0f), 0.25f));
        Zoom.Append(orb.transform.DOScale(new Vector3(10f, 10f, 10f), 0.25f).SetDelay(1f));
        wand.transform.DORotate(spell_2_wandPostion, 1f).onComplete = reset;

    }

    public void spell_2()
    {
        orb.transform.DOLocalMove(new Vector3(0f, 10f, 20f), 1f).SetEase(Ease.InBack).onComplete = reset;
        wand.transform.DORotate(spell_1_wandPostion, 0.5f);
    }

    public void spell_3()
    {
        Sequence Bounce = DOTween.Sequence();
        Bounce.Append(orb.transform.DOLocalMove(new Vector3(0f, 0.35f, 20f), 0.25f));
        Bounce.Append(orb.transform.DOLocalMove(new Vector3(0f, 0.0f, 20f), 1f).SetEase(Ease.OutBounce));
        wand.transform.DORotate(spell_1_wandPostion, 1f).onComplete = appear;
    }

    public void spell_4()
    {
        orb.transform.DOLocalMove(new Vector3(-10f, 0f, 20f), 1f).SetEase(Ease.InBack).onComplete = reset;
        wand.transform.DOLocalMove(spell_4_wandPostion, 0.5f);
        wand.transform.DORotate(spell_2_wandPostion, 0.5f);
    }

    public void spell_5()
    {
        orb.transform.DOLocalMove(new Vector3(0f, -10f, 20f), 1f).SetEase(Ease.InBack).onComplete = reset;
        wand.transform.DORotate(spell_2_wandPostion, 0.5f);
    }

    public void spell_6()
    {
        orb.transform.DOLocalMove(new Vector3(10f, 0f, 20f), 1f).SetEase(Ease.InBack).onComplete = reset;
        wand.transform.DOLocalMove(spell_6_wandPostion, 0.5f);
        wand.transform.DORotate(spell_1_wandPostion, 0.5f);
    }

    void reset()
    {
        orbObject.SetActive(false);
        orb.transform.DOLocalMove(new Vector3(0f, 0f, 20f), 0.01f).SetDelay(1f).onComplete = appear;
    }

    void appear()
    {
        orbObject.SetActive(true);
        wand.transform.DORotate(default_wandPostionRot, 0.5f);
        wand.transform.DOLocalMove(default_wandPostionPos, 0.5f);
    }
}
