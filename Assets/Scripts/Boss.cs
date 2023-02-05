using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    enum BossType {
        MAJOR,
        SKELETON,
        SLIME
    }

    private BossType bossType;

    private string bossName;
}
