﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace spel_test;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Hink hink;
    private Texture2D player;
    private Texture2D Muggar;
    
    private List<Muggar> enemies = new List<Muggar>();


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        player = Content.Load<Texture2D>("bucket-clipart-design-illustration-free-png");
        Muggar = Content.Load<Texture2D>("pngtree-plain-white-mug-png-image_9949524");
        hink = new Hink (player, new Vector2(380,400), 50);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        hink.Update();
        foreach(Muggar muggar in enemies){
            muggar.Update();
        }  
        SpawnMuggar();
         
        
       
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        GraphicsDevice.Clear(Color.SkyBlue );
        _spriteBatch.Begin();
        foreach(Muggar muggar in enemies){
            muggar.Draw(_spriteBatch);
        }
        
        hink.Draw(_spriteBatch);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
    private void SpawnMuggar(){
        Random rand = new Random();
        int value = rand.Next(1, 101);
        double spawnChancePercent = 1;
        if(value<=spawnChancePercent){
            enemies.Add(new Muggar(Muggar));   
        }
    }
    
}
