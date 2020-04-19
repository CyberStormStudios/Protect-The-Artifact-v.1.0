using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchivementManager : MonoBehaviour
{
    public Image SlasherImage;
    public TextMeshProUGUI SlasherLockedStateText;

    private void Update()
    {
        if(PlayerMovementController.SlasherUnlocked == true)
        {
            SlasherImage.CrossFadeAlpha(1, 0.1f, false);
            SlasherLockedStateText.text = "Kill 50+ enemies during one match Currently: Unlocked";

        }
    }
}
