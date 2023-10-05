using UnityEngine;

using DG.Tweening;
using UnityEngine.UI;

public class WandBehaviour : MonoBehaviour
{
    public Image wand;
    Vector3 tweenRot_ini = new Vector3(0, 0, -15f);
    Vector3 tweenRot_end = new Vector3(0, 0, -20f);

    public void wandUp()
    {
        wand.transform.DORotate(tweenRot_end, 0.5f).onComplete = wandDown;
    }

    void wandDown()
    {
        wand.transform.DORotate(tweenRot_ini, 0.5f);
        Debug.Log("Waved");
    }
}
