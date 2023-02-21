using Godot;
using System;

public class Player : KinematicBody2D
{
	[Export]
	public int Speed = 200;
	
	public bool IsLocalPlayer = false;

	public Vector2 velocity = new Vector2();
	
	public override void _Ready()
	{
		
	}

	public override void _PhysicsProcess(float delta)
	{
		if (IsLocalPlayer) {
			velocity = new Vector2();

			if (Input.IsActionPressed("right")) 	velocity.x += 1;
			if (Input.IsActionPressed("left")) 		velocity.x -= 1;
			if (Input.IsActionPressed("down")) 		velocity.y += 1;
			if (Input.IsActionPressed("up")) 		velocity.y -= 1;

			velocity = velocity.Normalized() * Speed;

			velocity = MoveAndSlide(velocity);

			for (int i = 0; i < GetSlideCount(); i++)
			{
				KinematicCollision2D collision = GetSlideCollision(i);

				if (collision != null)
				{
					GD.Print(collision.Collider);

					if (collision.Collider is StaticBody2D)
					{
						StaticBody2D other = (StaticBody2D)collision.Collider;

						if (other.GetParent() != null && other.GetParent() is Food)
						{
							// TODO: Process food client side
						}
					}
					else if (collision.Collider is KinematicBody2D)
					{
						KinematicBody2D other = (KinematicBody2D)collision.Collider;

						if (other.GetParent() != null && other.GetParent() is Player)
						{
							// TODO: Process player client side
						}
					}
				}
			}
		}
		
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}
