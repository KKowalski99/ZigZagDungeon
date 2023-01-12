using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    [SerializeField] float offsetTop, offsetBottom;
      private void Awake()
      {
          playerInputActions = new PlayerInputActions();
      }


      private void Start()
      {
          playerInputActions.Player.Touch.started += ctx => StartTouch(ctx);
          playerInputActions.Player.Touch.canceled += ctx => EndTouch(ctx);
      }

      private void OnEnable()
      {
          playerInputActions.Enable();
      }


      private void OnDisable()
      {
          playerInputActions.Disable();
      }


      private void StartTouch(InputAction.CallbackContext context)
      {

       /* Vector2 touchPosition = playerInputActions.Player.TouchPosition.ReadValue<Vector2>();
        
        if(touchPosition.y > offsetBottom && touchPosition.y < offsetTop)
        {
            Debug.Log("Touch started" + playerInputActions.Player.Touch.ReadValue<Vector2>());
        }
       */
        
         // Debug.Log("Touch started" + playerInputActions.Player.Touch.ReadValue<Vector2>());
      }
      private void EndTouch(InputAction.CallbackContext context)
      {
       //   Debug.Log("Touch ended" + context.ReadValue<float>());
      }
    


  
}
