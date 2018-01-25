namespace VRTK.Examples
{
    using UnityEngine;

    public class VRTK_Teleport_Destination : VRTK_DestinationMarker
    {
        private Transform destination;
        private bool lastUsePressedState = false;
        public void teleportToDestination(VRTK_ControllerEvents controller)
        {
            destination = this.gameObject.transform;
            var distance = Vector3.Distance(transform.position, destination.position);
            var controllerIndex = VRTK_DeviceFinder.GetControllerIndex(controller.gameObject);
//            OnDestinationMarkerSet(SetDestinationMarkerEvent(distance, destination, new RaycastHit(), destination.position, controllerIndex));

        }

    }
}