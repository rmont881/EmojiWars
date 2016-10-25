using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
		static int controller_count = 1;
		public int controller_id;
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
			controller_id = controller_count++;
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
				m_Jump = CrossPlatformInputManager.GetButtonDown("Jump "+controller_id.ToString());
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
			float h = CrossPlatformInputManager.GetAxis("Horizontal "+controller_id.ToString());
			m_Jump = CrossPlatformInputManager.GetButton("Jump "+controller_id.ToString());
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
        }
    }
}
