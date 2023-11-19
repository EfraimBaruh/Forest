using UnityEngine;

namespace CommandPattern
{
    public class RotateVertical : Command
    {
        private float pitch = 0.0f;

        public RotateVertical(float speed) : base(speed) { }

        public override void Execute(Transform objTransform)
        {
            float yaw = objTransform.localEulerAngles.y;
            pitch -= Speed * Input.GetAxis("Mouse Y");

            Rotate(objTransform, new Vector3(pitch, yaw, 0.0f));
        }
    }
}
