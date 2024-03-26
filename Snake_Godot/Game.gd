extends Node2D

onready var map = $TileMap
onready var timer = $Timer

var snek = []

var game_over = false
var last_dir = Vector2.ZERO
var next_dir = Vector2.ZERO
var head_direction = 2

func _ready():
	snek = [Vector2(5,5)]
	map.set_cellv(snek[0], 2)
	spawn_apple()
	
func _process(delta):
	var temp = Vector2.ZERO
	if Input.is_action_just_pressed("ui_right"):
		temp = Vector2(1,0)
		head_direction = 2
	elif Input.is_action_just_pressed("ui_left"):
		temp = Vector2(-1,0)
		head_direction = 3
	elif Input.is_action_just_pressed("ui_up"):
		temp = Vector2(0,-1)
		head_direction = 4
	elif Input.is_action_just_pressed("ui_down"):
		temp = Vector2(0,1)
		head_direction = 5
	
	if temp != Vector2.ZERO and last_dir != temp*-1 and not game_over:
		next_dir = temp
		$Timer.stop()
		$Timer.start()
		_on_Timer_timeout()
		
func _on_Timer_timeout():
	if next_dir == Vector2.ZERO:
		$Timer.stop()
		return
	
	var head = snek[-1]
	var last = snek[0]
	
	var next = head+next_dir
	snek.append(next)
	
	var next_cell = map.get_cellv(next)
	
	match next_cell:
		0:
			map.set_cellv(last, 0)
			map.set_cellv(next, head_direction)
			if(snek.size()>2):
				map.set_cellv(head, 6)
			snek.remove(0)
		1:
			map.set_cellv(next, head_direction)
			map.set_cellv(head, 6)
			spawn_apple()
		_:
			modulate.a = 0.5
			game_over = true
			timer.stop()
	
	last_dir = next_dir
	
func spawn_apple():
	var greens = []
	for i in range(12):
		for j in range(12):
			if map.get_cell(i+1, j+1) == 0:
				greens.append(Vector2(i+1,j+1))
	map.set_cellv(greens[randi()%len(greens)], 1)
