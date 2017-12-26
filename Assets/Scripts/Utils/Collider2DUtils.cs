using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2DUtils {

    public static bool HasParent(Collider2D col) {
        return col.transform.parent != null;
    }
}
