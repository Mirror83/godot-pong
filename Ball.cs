using Godot;
using System;

public partial class Ball : CharacterBody2D
{
    [Signal]
    public delegate void ExitLeftEventHandler();
    [Signal]
    public delegate void ExitRightEventHandler();

    [Export]
    public int Speed = 200;
    private bool hasLeftScreen = false;

    private Vector2 ballVelocity;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ballVelocity = new Vector2(GD.RandRange(-1, 1), GD.RandRange(-1, 1));
        while (
            ballVelocity == Vector2.Zero ||
            ballVelocity == Vector2.Up ||
            ballVelocity == Vector2.Down ||
            ballVelocity == Vector2.Left ||
            ballVelocity == Vector2.Right
          )
        {
            ballVelocity = new Vector2(GD.RandRange(-1, 1), GD.RandRange(-1, 1));
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        if (Position.X > (GetViewportRect().Size.X))
        {
            if (!hasLeftScreen)
            {
                EmitSignal(SignalName.ExitRight);
                GD.Print("Just left the viewport from the right side");
                hasLeftScreen = true;
            }
        }
        if (Position.X < 0)
        {
            if (!hasLeftScreen)
            {
                EmitSignal(SignalName.ExitLeft);
                GD.Print("Just left the viewport from the left side");
                hasLeftScreen = true;
            }
        }
        if (Position.Y > GetViewportRect().Size.Y)
        {
            ballVelocity.Y *= -1;
        }
        if (Position.Y < 0)
        {
            ballVelocity.Y *= -1;
        }

        var collisionInfo = MoveAndCollide(ballVelocity * Speed * (float)delta);
        if (collisionInfo != null)
        {
            ballVelocity = ballVelocity.Bounce(collisionInfo.GetNormal());
        }
    }


}
