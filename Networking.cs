using Godot;
using System;

public class Networking : Node2D
{
	[Export]
	public string ServerUrl = "ws://localhost:8070";

	private WebSocketClient _client = new WebSocketClient();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PackedScene playerPrefab = GD.Load<PackedScene>("res://Player.tscn");
		Player player = playerPrefab.Instance<Player>();

		player.IsLocalPlayer = true;

		AddChild(player);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
