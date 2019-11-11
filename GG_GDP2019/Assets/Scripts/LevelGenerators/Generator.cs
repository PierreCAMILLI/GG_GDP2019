using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generator : MonoBehaviour
{

    public abstract float Generate(float expectedDifficulty);

    public float maxDifficulty;

}
