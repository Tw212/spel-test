using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpDX.Direct2D1.Effects;


namespace spel_test;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Hink hink;
    private Texture2D player;
    private Texture2D Muggar;
    private int points = 0;
    SpriteFont fontScore;
    Song theme;
    SpriteFont font;
    
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
        fontScore = Content.Load<SpriteFont>("fontScore");
        hink = new Hink (player, new Vector2(380,400), 50);
        theme = Content.Load<Song>("stone fortress");
        MediaPlayer.Play(theme);
        font = Content.Load<SpriteFont>("File");

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
        Samlamuggar();
        
       
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        GraphicsDevice.Clear(Color.SkyBlue );
        _spriteBatch.Begin();
        _spriteBatch.DrawString(font,"samla muggarna!",new Vector2(310,70),Color.Black);
        foreach(Muggar muggar in enemies){
            muggar.Draw(_spriteBatch);
        }
        _spriteBatch.DrawString(fontScore, Convert.ToString(points), new Vector2(50,50), Color.Black);
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
    private void Samlamuggar(){
        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i].Hitbox.Intersects(hink.Hitbox)){
                enemies.RemoveAt(i);
                points++;
            }
        }
    }
    
}
