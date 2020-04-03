using System.Collections;
using System.Collections.Generic;
using Tobii.G2OM;
using Tobii.XR.Examples;
using UnityEngine;

[RequireComponent(typeof(UIGazeButtonGraphics))]
public class GazeButton : MonoBehaviour, IGazeFocusable
{
    // Event called when the button is clicked.
    public UIButtonEvent OnButtonClicked;

    // The state the button is currently  in.
    private ButtonState _currentButtonState = ButtonState.Idle;

    // Private fields.
    private bool _hasFocus;
    private UIGazeButtonGraphics _uiGazeButtonGraphics;

    [SerializeField]private float _gazeTime = 1.5f;
    private bool _isCounting;
    private float _time;

    public void GazeFocusChanged(bool hasFocus)
    {
        if (!_isCounting && hasFocus)
        {
            _time = _gazeTime;
            _isCounting = true;
        }
        else if (_isCounting && !hasFocus)
        {
            _isCounting = false;
            GazeRing.Instance.Hide();
        }

        _hasFocus = hasFocus;
        UpdateState(_hasFocus ? ButtonState.Focused : ButtonState.Idle);
    }

    IEnumerator ResetButton()
    {
        yield return new WaitForSecondsRealtime(.1f);
        UpdateState(_hasFocus ? ButtonState.Focused : ButtonState.Idle);
    }

    private void Click()
    {
        UpdateState(ButtonState.PressedDown);
        // Invoke click event.
        if (OnButtonClicked != null)
        {
            OnButtonClicked.Invoke(gameObject);
        }

        StartCoroutine(ResetButton());
    }

    private void Start()
    {
        // Store the graphics class.
        _uiGazeButtonGraphics = GetComponent<UIGazeButtonGraphics>();

        // Initialize click event.
        if (OnButtonClicked == null)
        {
            OnButtonClicked = new UIButtonEvent();
        }
    }

    private void Update()
    {
        if (_isCounting)
        {
            _time -= Time.deltaTime;
            if (_time > 0)
            {
                GazeRing.Instance.SetProgress((_gazeTime - _time) / _gazeTime);
            }
            else
            {
                _isCounting = false;
                Click();
                GazeRing.Instance.Hide();
            }
        }
    }

    /// <summary>
    /// Updates the button state and starts an animation of the button.
    /// </summary>
    /// <param name="newState">The state the button should transition to.</param>
    private void UpdateState(ButtonState newState)
    {
        var oldState = _currentButtonState;
        _currentButtonState = newState;

        // Variables for when the button is pressed or clicked.
        var buttonPressed = newState == ButtonState.PressedDown;
        var buttonClicked = (oldState == ButtonState.PressedDown && newState == ButtonState.Focused);

        // If the button is being pressed down or clicked, animate the button click.
        if (buttonPressed || buttonClicked)
        {
            _uiGazeButtonGraphics.AnimateButtonPress(_currentButtonState);
        }
        // In all other cases, animate the visual feedback.
        else
        {
            _uiGazeButtonGraphics.AnimateButtonVisualFeedback(_currentButtonState);
        }
    }
}
