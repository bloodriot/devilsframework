/*
*
* 	Devils Inc Studios
* 	// Copyright DEVILS INC. STUDIOS LIMITED 2015
*	
*	TODO: Include a description of the file here.
*
*/

namespace DI.Core.Helpers
{
	static public class MathLib
	{
		// Helper to wrap angles greater than 360
		static public float wrapAngle(float angle)
		{
			if (angle < 0) {
				angle += 360;
			}
			if (angle < -360F) {
				while (angle < -360F) {
					angle += 360F;
				}
			}
			if (angle > 360F) {
				while (angle > 360F) {
					angle -= 360F;
				}
			}
			if (angle == 360f) {
				angle = 0f;
			}
			return angle;
		}
	}
}