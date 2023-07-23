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

    private void AssignRandomStartVelocity()
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
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AssignRandomStartVelocity();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        if (Position.X > (GetViewportRect().Size.X))
        {
            EmitSignal(SignalName.ExitRight);
        }
        if (Position.X < 0)
        {
            EmitSignal(SignalName.ExitLeft);
        }
        if (Position.Y > GetViewportRect().Size.Y)
        {
            ballVelocity.Y *= -1;
        }
        if (Position.Y < 0)
        {
            ballVelocity.Y *= -1;
        }

        // Handle collision with paddles
        var collisionInfo = MoveAndCollide(ballVelocity * Speed * (float)delta);
        if (collisionInfo != null)
        {
            ballVelocity = ballVelocity.Bounce(collisionInfo.GetNormal());
        }
    }

    public void ResetPosition()
    {
        Position = new Vector2(GetViewportRect().Size.X / 2, GetViewportRect().Size.Y / 2);
        AssignRandomStartVelocity();
    }


}
