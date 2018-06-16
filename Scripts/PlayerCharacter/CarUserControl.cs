using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
	[RequireComponent(typeof(TurboDash))]
	public class CarUserControl : MonoBehaviour
    {
		[Range(1,4)]
		public int playerNumber = 1;
        private CarController m_Car; // the car controller we want to use
		private TurboDash turboDash;


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
			turboDash = GetComponent<TurboDash>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("HorizontalP" + playerNumber);
            float v = CrossPlatformInputManager.GetAxis("VerticalP" + playerNumber);
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("BrakeP" + playerNumber);
            m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
			if (CrossPlatformInputManager.GetButtonDown("TurboDashP" + playerNumber))
			{
				turboDash.Launch();
			}
        }
    }
}
