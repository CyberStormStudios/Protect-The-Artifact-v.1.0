using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCCHo3boDHDe_VyB5_BPvpxg/");
    }
    public void JoinDiscord()
    {
        Application.OpenURL("https://discord.gg/DnTdEsn");
    }
}
