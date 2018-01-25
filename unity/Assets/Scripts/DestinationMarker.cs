using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DestinationMarker : VRTK_DestinationMarker
{
    public void SetDestination(GameObject stance)
    {
        // Emit a destination at the location/rotation of the stance
        OnDestinationMarkerSet(SetDestinationMarkerEvent(1, stance.transform, new RaycastHit(), stance.transform.position, null)); // ???
    }
}