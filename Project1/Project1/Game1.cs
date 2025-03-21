﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
private Player sokoban;

namespace Project1;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private int nrLinhas = 0;
    private int nrColunas = 0;
    private SpriteFont font; // Variavel de fonte 
    private char[,] level;
    private Texture2D player, dot, box, wall; //Load imagens Texture
    int tileSize = 64; //potencias de 2 (operações binárias)

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        LoadLevel("level1.txt");

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        font = Content.Load<SpriteFont>("File"); // Use the name of the sprite file insetad of 'File'
        player = Content.Load<Texture2D>("Character4");
        dot = Content.Load<Texture2D>("EndPoint_Blue");
        box = Content.Load<Texture2D>("Crate_Beige");
        wall = Content.Load<Texture2D>("Wall_Brown");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        //_spriteBatch.DrawString(font, "O texto que quiser", new Vector2(100, 100), Color.White);
        //_spriteBatch.DrawString(font, "O texto que quiser", new Vector2(100, 300), Color.Black);
        Rectangle position = new Rectangle(0, 0, tileSize, tileSize); //calculo do retangulo a depender do tileSize
        for (int x = 0; x < level.GetLength(0); x++)  //pega a primeira dimensão
        {
            for (int y = 0; y < level.GetLength(1); y++) //pega a segunda dimensão
            {
                position.X = x * tileSize; // define o position
                position.Y = y * tileSize; // define o position

                switch (level[x, y])
                {
                    //case 'Y':
                    //    _spriteBatch.Draw(player, position, Color.White);
                    //    break;
                    case '#':
                        _spriteBatch.Draw(box, position, Color.White);
                        break;
                    case '.':
                        _spriteBatch.Draw(dot, position, Color.White);
                        break;
                    case 'X':
                        _spriteBatch.Draw(wall, position, Color.White);
                        break;
                }
            }
        }

        position.X = sokoban.Position.X * tileSize; //posição do Player
        position.Y = sokoban.Position.Y * tileSize; //posição do Player
        _spriteBatch.Draw(player, position, Color.White); //desenha o Player

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    void LoadLevel(string levelFile)
    {
        string[] linhas = File.ReadAllLines($"Content/{levelFile}"); // "Content/" + level
        nrLinhas = linhas.Length;
        nrColunas = linhas[0].Length;

        level = new char[nrColunas, nrLinhas]

         for (int x = 0; x < nrColunas; x++)
        {
            for (int y = 0; y < nrLinhas; y++)
            {
                if (linhas[y][x] == 'Y')
                {
                    sokoban = new Player(x, y);
                    level[x, y] = ' '; // put a blank instead of the sokoban 'Y'
                }
                else
                {
                    level[x, y] = linhas[y][x];
                }
            }
        }

    }
}
