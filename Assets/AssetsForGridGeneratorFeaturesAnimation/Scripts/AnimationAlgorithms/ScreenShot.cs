using UnityEngine;

namespace GridGeneratorFeaturesAnimation {
    public class ScreenShot : MonoBehaviour {
    // Saves a screenshot when a button is pressed
        public KeyCode screenShotButton;
        void Update() {
            if (Input.GetKeyDown(screenShotButton))
            {
                ScreenCapture.CaptureScreenshot("screenshot.png");
                Debug.Log("A screenshot was taken!");
            }
        }
    }
}