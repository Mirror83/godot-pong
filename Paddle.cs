using Godot;
using System;

public struct PaddleKeyMaps
{
    public static string PlayerOneDown = "player_one_down";
    public static string PlayerOneUp = "player_one_up";
    public static string PlayerTwoDown = "player_two_down";
    public static string PlayerTwoUp = "player_two_up";

}


public partial class Paddle : StaticBody2D
{

    [Export]
    public int Speed = 10;
    [Signal]
    public delegate void BallContactEventHandler();
    public Vector2 ScreenSize;
    protected bool canMove = true;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    protected void MoveOnKeyPress(string up, string down)
    {
        if (canMove)
        {
            var velocity = Vector2.Zero;
            if (Input.IsActionPressed(up))
            {
                velocity.Y = -1;
                Position += velocity * Speed;
                // Position = new Vector2(
                //     Math.Clamp(Position.X, 0, ScreenSize.X),
                //     Math.Clamp(Position.Y, 0, ScreenSize.Y)
                // );
            }
            else if (Input.IsActionPressed(down))
            {
                velocity.Y = 1;
                Position += velocity * Speed;
                // Position = new Vector2(
                //     Math.Clamp(Position.X, 0, ScreenSize.X),
                //     Math.Clamp(Position.Y, 0, ScreenSize.Y)
                // );
            }
        }
    }


}
