TopDown Player Controller
=========================

Description: Top-down 2D player controller implementation for Unity.

File: `Player_controller.cs`

Details & Usage:
- Simple controller that reads `Horizontal`/`Vertical` input axes and moves a `Rigidbody2D` via `MovePosition`.
- Requires the Player GameObject to be tagged `Player` and to have a `Rigidbody2D` component.

Notes:
- The script also updates the main camera position to follow the player.