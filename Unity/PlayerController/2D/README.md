Player Controller (2D)
======================

Top-down 2D player controller used in Unity examples.

Files:
- `Player_controller.cs` - movement and input handling for a top-down player.

Details & Usage:
- `Player_controller.cs` implements a simple top-down controller using `Rigidbody2D.MovePosition` and reads `Horizontal` / `Vertical` input axes.
- Attach the script to the Player GameObject (tagged `Player`) and ensure a `Rigidbody2D` component is present.

Notes:
- The repository contains a `TopDown` variant under `PlayerController/2D/TopDown/Player_controller.cs` — the parent README covers the 2D family; see the `TopDown` folder for the exact implementation.
