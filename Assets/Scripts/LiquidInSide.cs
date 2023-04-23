using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Liquid { NULL = 0, RON, GIN, VODKA,
                     LICOR_MELOCOTON, LICOR_FRAMBUESA,
                     COCKTELERA, ZUMO_NARANJA, ZUMO_ARANDANOS, ZUMO_LIMA, NORELLENABLE };
public class LiquidInSide : MonoBehaviour{
    public Liquid Inside;
}
