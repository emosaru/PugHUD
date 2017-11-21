using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Windows;
using System.IO;

namespace PugHUD
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 33*7+3; // 7 slots wide, +3 pixels of extra space
            graphics.PreferredBackBufferHeight = 33*6+4+20; //6 slots down, +4 pixels of extra space +20 for top bar
            
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        public Texture2D ZeroPic, MiniMushPic, NoMiniMushPic;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            for (int i = 0; i < 55; i++)
            {
                BlockID[i] = new HUDBlock();
            }
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    HUDGrid[x, y] = new Square();
                }
            }
            //pngs
            DeclareBlockIDs();
            BlockID[0].sprite[0] = Content.Load<Texture2D>("Resources/NoBow");
            BlockID[0].sprite[1] = Content.Load<Texture2D>("Resources/Bow");
            BlockID[0].sprite[2] = Content.Load<Texture2D>("Resources/BowSilver");
            BlockID[0].sprite[3] = Content.Load<Texture2D>("Resources/ArrowSilver");
            BlockID[1].sprite[0] = Content.Load<Texture2D>("Resources/NoBoom");
            BlockID[1].sprite[1] = Content.Load<Texture2D>("Resources/Boom");
            BlockID[2].sprite[0] = Content.Load<Texture2D>("Resources/NoRedBoom");
            BlockID[2].sprite[1] = Content.Load<Texture2D>("Resources/RedBoom");
            BlockID[3].sprite[0] = Content.Load<Texture2D>("Resources/NoHookshot");
            BlockID[3].sprite[1] = Content.Load<Texture2D>("Resources/Hookshot");
            BlockID[4].sprite[0] = Content.Load<Texture2D>("Resources/NoMushroom");
            BlockID[4].sprite[1] = Content.Load<Texture2D>("Resources/Mushroom");
            BlockID[5].sprite[0] = Content.Load<Texture2D>("Resources/NoMagicPowder");
            BlockID[5].sprite[1] = Content.Load<Texture2D>("Resources/MagicPowder");
            BlockID[6].sprite[0] = Content.Load<Texture2D>("Resources/NoFireRod");
            BlockID[6].sprite[1] = Content.Load<Texture2D>("Resources/FireRod");
            BlockID[7].sprite[0] = Content.Load<Texture2D>("Resources/NoIceRod");
            BlockID[7].sprite[1] = Content.Load<Texture2D>("Resources/IceRod");
            BlockID[8].sprite[0] = Content.Load<Texture2D>("Resources/NoBombos");
            BlockID[8].sprite[1] = Content.Load<Texture2D>("Resources/Bombos");
            BlockID[9].sprite[0] = Content.Load<Texture2D>("Resources/NoEther");
            BlockID[9].sprite[1] = Content.Load<Texture2D>("Resources/Ether");
            BlockID[10].sprite[0] = Content.Load<Texture2D>("Resources/NoQuake");
            BlockID[10].sprite[1] = Content.Load<Texture2D>("Resources/Quake");
            BlockID[11].sprite[0] = Content.Load<Texture2D>("Resources/NoLamp");
            BlockID[11].sprite[1] = Content.Load<Texture2D>("Resources/Lamp");
            BlockID[12].sprite[0] = Content.Load<Texture2D>("Resources/NoHammer");
            BlockID[12].sprite[1] = Content.Load<Texture2D>("Resources/Hammer");
            BlockID[13].sprite[0] = Content.Load<Texture2D>("Resources/NoOcarina");
            BlockID[13].sprite[1] = Content.Load<Texture2D>("Resources/Ocarina");
            BlockID[14].sprite[0] = Content.Load<Texture2D>("Resources/NoShovel");
            BlockID[14].sprite[1] = Content.Load<Texture2D>("Resources/Shovel");
            BlockID[15].sprite[0] = Content.Load<Texture2D>("Resources/NoNet");
            BlockID[15].sprite[1] = Content.Load<Texture2D>("Resources/Net");
            BlockID[16].sprite[0] = Content.Load<Texture2D>("Resources/NoBook");
            BlockID[16].sprite[1] = Content.Load<Texture2D>("Resources/Book");
            BlockID[17].sprite[0] = Content.Load<Texture2D>("Resources/NoBottle");
            BlockID[17].sprite[1] = Content.Load<Texture2D>("Resources/Bottle");
            BlockID[18].sprite[0] = Content.Load<Texture2D>("Resources/NoRedCane");
            BlockID[18].sprite[1] = Content.Load<Texture2D>("Resources/RedCane");
            BlockID[19].sprite[0] = Content.Load<Texture2D>("Resources/NoBlueCane");
            BlockID[19].sprite[1] = Content.Load<Texture2D>("Resources/BlueCane");
            BlockID[20].sprite[0] = Content.Load<Texture2D>("Resources/NoCape");
            BlockID[20].sprite[1] = Content.Load<Texture2D>("Resources/Cape");
            BlockID[21].sprite[0] = Content.Load<Texture2D>("Resources/NoMirror");
            BlockID[21].sprite[1] = Content.Load<Texture2D>("Resources/Mirror");
            BlockID[22].sprite[0] = Content.Load<Texture2D>("Resources/NoPearl");
            BlockID[22].sprite[1] = Content.Load<Texture2D>("Resources/Pearl");
            BlockID[23].sprite[0] = Content.Load<Texture2D>("Resources/NoPegasus");
            BlockID[23].sprite[1] = Content.Load<Texture2D>("Resources/Pegasus");
            BlockID[24].sprite[0] = Content.Load<Texture2D>("Resources/NoPowerGlove");
            BlockID[24].sprite[1] = Content.Load<Texture2D>("Resources/PowerGlove");
            BlockID[24].sprite[2] = Content.Load<Texture2D>("Resources/TitanMitt");
            BlockID[25].sprite[0] = Content.Load<Texture2D>("Resources/NoFlippers");
            BlockID[25].sprite[1] = Content.Load<Texture2D>("Resources/Flippers");
            BlockID[26].sprite[0] = Content.Load<Texture2D>("Resources/NoHalfMagic");
            BlockID[26].sprite[1] = Content.Load<Texture2D>("Resources/HalfMagic");
            BlockID[26].sprite[2] = Content.Load<Texture2D>("Resources/QuarterMagic");
            BlockID[27].sprite[0] = Content.Load<Texture2D>("Resources/NoSword");
            BlockID[27].sprite[1] = Content.Load<Texture2D>("Resources/Sword");
            BlockID[27].sprite[2] = Content.Load<Texture2D>("Resources/MasterSword");
            BlockID[27].sprite[3] = Content.Load<Texture2D>("Resources/TemperedSword");
            BlockID[27].sprite[4] = Content.Load<Texture2D>("Resources/GoldenSword");
            BlockID[28].sprite[0] = Content.Load<Texture2D>("Resources/NoShield");
            BlockID[28].sprite[1] = Content.Load<Texture2D>("Resources/Shield");
            BlockID[28].sprite[2] = Content.Load<Texture2D>("Resources/FireShield");
            BlockID[28].sprite[3] = Content.Load<Texture2D>("Resources/MirrorShield");
            BlockID[29].sprite[0] = Content.Load<Texture2D>("Resources/GreenTunic");
            BlockID[29].sprite[1] = Content.Load<Texture2D>("Resources/BlueTunic");
            BlockID[29].sprite[2] = Content.Load<Texture2D>("Resources/RedTunic");
            BlockID[30].sprite[0] = Content.Load<Texture2D>("Resources/NoCrystal");
            BlockID[30].sprite[1] = Content.Load<Texture2D>("Resources/Crystal");
            BlockID[30].sprite[2] = Content.Load<Texture2D>("Resources/NoPendant");
            BlockID[30].sprite[3] = Content.Load<Texture2D>("Resources/Pendant");
            BlockID[30].sprite[4] = Content.Load<Texture2D>("Resources/NoFFCrystal");
            BlockID[30].sprite[5] = Content.Load<Texture2D>("Resources/FFCrystal");
            BlockID[30].sprite[6] = Content.Load<Texture2D>("Resources/NoGreenPendant");
            BlockID[30].sprite[7] = Content.Load<Texture2D>("Resources/GreenPendant");
            BlockID[30].sprite[8] = Content.Load<Texture2D>("Resources/NoQuestionMark");
            BlockID[31].sprite[0] = Content.Load<Texture2D>("Resources/NoEP");
            BlockID[31].sprite[1] = Content.Load<Texture2D>("Resources/EP");
            BlockID[32].sprite[0] = Content.Load<Texture2D>("Resources/NoDP");
            BlockID[32].sprite[1] = Content.Load<Texture2D>("Resources/DP");
            BlockID[33].sprite[0] = Content.Load<Texture2D>("Resources/NoTH");
            BlockID[33].sprite[1] = Content.Load<Texture2D>("Resources/TH");
            BlockID[34].sprite[0] = Content.Load<Texture2D>("Resources/NoPD");
            BlockID[34].sprite[1] = Content.Load<Texture2D>("Resources/PD");
            BlockID[35].sprite[0] = Content.Load<Texture2D>("Resources/NoSP");
            BlockID[35].sprite[1] = Content.Load<Texture2D>("Resources/SP");
            BlockID[36].sprite[0] = Content.Load<Texture2D>("Resources/NoSW");
            BlockID[36].sprite[1] = Content.Load<Texture2D>("Resources/SW");
            BlockID[37].sprite[0] = Content.Load<Texture2D>("Resources/NoTT");
            BlockID[37].sprite[1] = Content.Load<Texture2D>("Resources/TT");
            BlockID[38].sprite[0] = Content.Load<Texture2D>("Resources/NoIP");
            BlockID[38].sprite[1] = Content.Load<Texture2D>("Resources/IP");
            BlockID[39].sprite[0] = Content.Load<Texture2D>("Resources/NoMM");
            BlockID[39].sprite[1] = Content.Load<Texture2D>("Resources/MM");
            BlockID[40].sprite[0] = Content.Load<Texture2D>("Resources/NoTR");
            BlockID[40].sprite[1] = Content.Load<Texture2D>("Resources/TR");
            BlockID[41].sprite[0] = Content.Load<Texture2D>("Resources/NoHC");
            BlockID[41].sprite[1] = Content.Load<Texture2D>("Resources/HC");
            BlockID[42].sprite[0] = Content.Load<Texture2D>("Resources/NoAT");
            BlockID[42].sprite[1] = Content.Load<Texture2D>("Resources/AT");
            BlockID[43].sprite[0] = Content.Load<Texture2D>("Resources/NoGT");
            BlockID[43].sprite[1] = Content.Load<Texture2D>("Resources/GT");
            BlockID[44].sprite[0] = Content.Load<Texture2D>("Resources/NoAga1");
            BlockID[44].sprite[1] = Content.Load<Texture2D>("Resources/Aga1");
            BlockID[45].sprite[0] = Content.Load<Texture2D>("Resources/NoHeartP");
            BlockID[45].sprite[1] = Content.Load<Texture2D>("Resources/HeartP");
            BlockID[46].sprite[0] = Content.Load<Texture2D>("Resources/NoHeartC");
            BlockID[46].sprite[1] = Content.Load<Texture2D>("Resources/HeartC");
            BlockID[47].sprite[0] = Content.Load<Texture2D>("Resources/NoBigKey");
            BlockID[47].sprite[1] = Content.Load<Texture2D>("Resources/BigKey");
            BlockID[48].sprite[0] = Content.Load<Texture2D>("Resources/No0");
            BlockID[48].sprite[1] = Content.Load<Texture2D>("Resources/1");
            BlockID[48].sprite[2] = Content.Load<Texture2D>("Resources/2");
            BlockID[48].sprite[3] = Content.Load<Texture2D>("Resources/3");
            BlockID[48].sprite[4] = Content.Load<Texture2D>("Resources/4");
            BlockID[48].sprite[5] = Content.Load<Texture2D>("Resources/5");
            BlockID[48].sprite[6] = Content.Load<Texture2D>("Resources/6");
            BlockID[48].sprite[7] = Content.Load<Texture2D>("Resources/7");
            BlockID[48].sprite[8] = Content.Load<Texture2D>("Resources/8");
            BlockID[48].sprite[9] = Content.Load<Texture2D>("Resources/9");
            //BlockID[49].sprite[0] = Content.Load<Texture2D>("Resources/NoBombs");
            //BlockID[49].sprite[1] = Content.Load<Texture2D>("Resources/Bombs");
            //BlockID[50].sprite[0] = Content.Load<Texture2D>("Resources/NoMSPed");
            //BlockID[50].sprite[1] = Content.Load<Texture2D>("Resources/MSPed");
            //BlockID[51].sprite[0] = Content.Load<Texture2D>("Resources/NoBigBomb");
            //BlockID[51].sprite[1] = Content.Load<Texture2D>("Resources/BigBomb");
            BlockID[53].sprite[0] = Content.Load<Texture2D>("Resources/ArrowSilver");
            BlockID[53].sprite[1] = Content.Load<Texture2D>("Resources/BowSilver");
            BlockID[54].sprite[0] = Content.Load<Texture2D>("Resources/NoSmallKey");
            BlockID[54].sprite[1] = Content.Load<Texture2D>("Resources/SmallKey");
            pinkPic = Content.Load<Texture2D>("Resources/pink");
            tealPic = Content.Load<Texture2D>("Resources/teal");
            checkPic = Content.Load<Texture2D>("Resources/check");
            purplePic = Content.Load<Texture2D>("Resources/purple");
            brownPic = Content.Load<Texture2D>("Resources/brown");
            XPic = Content.Load<Texture2D>("Resources/X");
            ZeroPic = Content.Load<Texture2D>("Resources/0");
            MiniMushPic = Content.Load<Texture2D>("Resources/MiniMushroom");
            NoMiniMushPic = Content.Load<Texture2D>("Resources/NoMiniMushroom");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            SetupApp();//initializes all variables
            mouse_Where();
            if (this.IsActive)
                windowIsActive = true;
            else
                windowIsActive = false;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            HUD();//Draws the HUD
            spriteBatch.End();
            base.Draw(gameTime);
        }
        
        public string[] configContents = new string[1];
        public string[] winpos = new string[8];

        public void fixFile() //a txt file holds the coords of the window so that keeps its position between launches, this fires if theres a format error with the file
        {
            if (!File.Exists("config.txt"))
            {
                File.CreateText("config.txt").Close();
            }
            File.WriteAllText("config.txt", "");
            FileStream vs = new FileStream("config.txt", FileMode.Open, FileAccess.ReadWrite);
            vs.Seek(0, SeekOrigin.Begin);
            StreamWriter sw = new StreamWriter(vs);
            sw.WriteLine("0");
            sw.WriteLine("{X:250 Y:250}");
            sw.Close();
            vs.Close();
            config();
        }

        public void updateFile()//updates coords of the window into the txt
        {
            if (!File.Exists("config.txt"))
            {
                fixFile();
                return;
            }
            File.WriteAllText("config.txt", "");
            FileStream vs = new FileStream("config.txt", FileMode.Open, FileAccess.ReadWrite);
            vs.Seek(0, SeekOrigin.Begin);
            StreamWriter sw = new StreamWriter(vs);
            sw.WriteLine(background);
            sw.WriteLine(location);
            sw.Close();
            vs.Close();
        }

        public void config()//gets the coords of the window upon launch, so that its in the right location
        {
            if (!File.Exists("config.txt"))
            {
                fixFile();
            }
            else
            {
                try
                {
                    configContents = File.ReadAllLines("config.txt");
                    background = Convert.ToInt32(configContents[0]);
                    configContents[1] = configContents[1].Remove(0, 3);
                    configContents[1] = configContents[1].TrimEnd('}');
                    winpos = configContents[1].Split(' ');
                    winpos[1] = winpos[1].Remove(0, 2);
                    location = new Point(Convert.ToInt16(winpos[0]), Convert.ToInt16(winpos[1]));// configContents[1]; 
                    if (background < 0 || background > 3)
                        background = 0;
                }
                catch (Exception) { fixFile(); }
            }
        }

        public int RightClick(HUDBlock Block, int step)
        {
            if (Block.name != "Nothing" && Block.name != "unknown")
            {
                if ((Block == BlockID[53] || Block == BlockID[0]) && step == 4)
                    return 1;
                else if (Block == BlockID[53] && step == 3)
                    return 2;
                else if (Block.leftSteps == 1 && Block.rightSteps == 1 && step == 2)//if left and right toggle, and toggled on
                    return 1; //toggle off
                else if (Block.rightSteps == 1 && step > 1)//else if left increasing (right will decrease)
                    return step - 1;
                else if (Block == BlockID[30] && step < 8)
                    return step + 2;
                else if (Block == BlockID[30] && step == 8)
                    return 2;
                else if (Block == BlockID[30] && step == 9)
                    return 1;
                else //if ??????? do nothing cuz this shouldnt have happened
                    return step;
            }
            else
                return step;
        }

        public int LeftClick(HUDBlock Block, int step)
        {
            if (Block.name != "Nothing" && Block.name != "unknown")
            {
                if (Block == BlockID[53] && step == 1)
                    return 4;
                else if ((Block == BlockID[53]) && step == 4)
                    return 1;
                else if ((Block == BlockID[0]) && step == 4)
                    return 3;
                else if (Block == BlockID[53] && step == 2)
                    return 3;
                else if (Block == BlockID[53] && step == 3)
                    return 2;
                else if (Block == BlockID[30] && step == 9)
                    return 2;
                else if (Block.leftSteps == 1 && step % 2 == 1)//else if left and right toggle, and step 1
                    return step + 1; //toggle on
                else if (Block.leftSteps == 1 && step % 2 == 0)//else if left and right toggle, and step 2
                    return step - 1; //toggle off
                else if (step < Block.leftSteps)//else if left increasing (right must be toggle)
                    return step + 1;
                else //if ??????? do nothing cuz this shouldnt have happened
                    return step;
            }
            else
                return step;
        }
        
        public void PicDraw(Texture2D texture, int x, int y)
        {
            spriteBatch.Draw(texture, new Rectangle(x, y, texture.Width, texture.Height), Color.White);
        }

        public void PicNumberDraw(int number, int x, int y)
        {
            if (number == 0)
                spriteBatch.Draw(BlockID[48].sprite[0], new Rectangle(x-4, y, 16, 16), Color.White);
            else if (number < 10)
                spriteBatch.Draw(BlockID[48].sprite[number], new Rectangle(x-4, y, 16, 16), Color.White);
            else
            {
                spriteBatch.Draw(BlockID[48].sprite[number / 10], new Rectangle(x - 12, y, 16, 16), Color.White);
                if (number % 10 == 0)
                    spriteBatch.Draw(ZeroPic, new Rectangle(x-4, y, 16, 16), Color.White);
                else
                    spriteBatch.Draw(BlockID[48].sprite[number % 10], new Rectangle(x-4, y, 16, 16), Color.White);
            }
        }

        public void HUD()
        {
            if (background == 0)
                spriteBatch.Draw(pinkPic, new Rectangle(0, 0, 33 * 7 + 4, 33 * 6 + 6 + 20), Color.White);
            else if (background == 1)
                spriteBatch.Draw(purplePic, new Rectangle(0, 0, 33 * 7 + 4, 33 * 6 + 6 + 20), Color.White);
            else if (background == 2)
                spriteBatch.Draw(tealPic, new Rectangle(0, 0, 33 * 7 + 4, 33 * 6 + 6 + 20), Color.White);
            else if (background == 3)
                spriteBatch.Draw(brownPic, new Rectangle(0, 0, 33 * 7 + 4, 33 * 6 + 6 + 20), Color.White);
            if (preset == "Keysanity")
            {
                spriteBatch.Draw(BlockID[54].sprite[1], new Rectangle(204, 11, 8, 8), Color.White);
                spriteBatch.Draw(NoMiniMushPic, new Rectangle(220, 11, 8, 8), Color.White);
            }
            else if (preset == "Standard")
            {
                spriteBatch.Draw(BlockID[54].sprite[0], new Rectangle(204, 11, 8, 8), Color.White);
                spriteBatch.Draw(NoMiniMushPic, new Rectangle(220, 11, 8, 8), Color.White);
            }
            else if (preset == "Mini Keysanity")
            {
                spriteBatch.Draw(BlockID[54].sprite[1], new Rectangle(204, 11, 8, 8), Color.White);
                spriteBatch.Draw(MiniMushPic, new Rectangle(220, 11, 8, 8), Color.White);
            }
            else if (preset == "Mini")
            {
                spriteBatch.Draw(BlockID[54].sprite[0], new Rectangle(204, 11, 8, 8), Color.White);
                spriteBatch.Draw(MiniMushPic, new Rectangle(220, 11, 8, 8), Color.White);
            }

            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (HUDGrid[x, y].blockContent[0] != BlockID[52])//draw top left content if not blank
                    {
                        if (HUDGrid[x, y].blockContent[0] == BlockID[0] && HUDGrid[x, y].currentStep[0] == 4)
                            PicDraw(BlockID[0].sprite[0], HUDGrid[x, y].x, HUDGrid[x, y].y);//draw NoBow first
                        if ((HUDGrid[x, y].blockContent[0] == BlockID[17] || HUDGrid[x, y].blockContent[0] == BlockID[54] || HUDGrid[x, y].blockContent[0] == BlockID[45] || HUDGrid[x, y].blockContent[0] == BlockID[46]) && HUDGrid[x, y].currentStep[0] > 1)
                            PicDraw(HUDGrid[x, y].blockContent[0].sprite[1], HUDGrid[x, y].x, HUDGrid[x, y].y);
                        else
                            PicDraw(HUDGrid[x, y].blockContent[0].sprite[HUDGrid[x, y].currentStep[0] - 1], HUDGrid[x, y].x, HUDGrid[x, y].y);
                    }
                    if (HUDGrid[x, y].format == 2 && HUDGrid[x, y].blockContent[1] != BlockID[52])//if format is [|], draw right half content if not blank
                    {
                        if ((HUDGrid[x, y].blockContent[1] == BlockID[17] || HUDGrid[x, y].blockContent[1] == BlockID[54] || HUDGrid[x, y].blockContent[1] == BlockID[45] || HUDGrid[x, y].blockContent[1] == BlockID[46]) && HUDGrid[x, y].currentStep[1] > 1)
                            PicDraw(HUDGrid[x, y].blockContent[1].sprite[1], HUDGrid[x, y].x+16, HUDGrid[x, y].y);
                        else
                            PicDraw(HUDGrid[x, y].blockContent[1].sprite[HUDGrid[x, y].currentStep[1] - 1], HUDGrid[x, y].x + 16, HUDGrid[x, y].y);
                    }
                    else if (HUDGrid[x, y].format == 3 && HUDGrid[x, y].blockContent[1] != BlockID[52])//if format is [--], draw bottom half content if not blank
                    {
                        if ((HUDGrid[x, y].blockContent[1] == BlockID[17] || HUDGrid[x, y].blockContent[1] == BlockID[54] || HUDGrid[x, y].blockContent[1] == BlockID[45] || HUDGrid[x, y].blockContent[1] == BlockID[46]) && HUDGrid[x, y].currentStep[1] > 1)
                            PicDraw(HUDGrid[x, y].blockContent[1].sprite[1], HUDGrid[x, y].x, HUDGrid[x, y].y+16);
                        else
                            PicDraw(HUDGrid[x, y].blockContent[1].sprite[HUDGrid[x, y].currentStep[1] - 1], HUDGrid[x, y].x, HUDGrid[x, y].y + 16);
                    }
                    else if (HUDGrid[x, y].format == 4)//if [-|-] format
                    {
                        if (HUDGrid[x, y].blockContent[1] != BlockID[52])//draw top right if not blank
                        {
                            if ((HUDGrid[x, y].blockContent[1] == BlockID[17] || HUDGrid[x, y].blockContent[1] == BlockID[54] || HUDGrid[x, y].blockContent[1] == BlockID[45] || HUDGrid[x, y].blockContent[1] == BlockID[46]) && HUDGrid[x, y].currentStep[1] > 1)
                                PicDraw(HUDGrid[x, y].blockContent[1].sprite[1], HUDGrid[x, y].x+16, HUDGrid[x, y].y);
                            else
                                PicDraw(HUDGrid[x, y].blockContent[1].sprite[HUDGrid[x, y].currentStep[1] - 1], HUDGrid[x, y].x + 16, HUDGrid[x, y].y);
                        }
                        if (HUDGrid[x, y].blockContent[2] != BlockID[52])//draw bottom left if not blank
                        {
                            if ((HUDGrid[x, y].blockContent[2] == BlockID[17] || HUDGrid[x, y].blockContent[2] == BlockID[54] || HUDGrid[x, y].blockContent[2] == BlockID[45] || HUDGrid[x, y].blockContent[2] == BlockID[46]) && HUDGrid[x, y].currentStep[2] > 1)
                                PicDraw(HUDGrid[x, y].blockContent[2].sprite[1], HUDGrid[x, y].x, HUDGrid[x, y].y+16);
                            else
                                PicDraw(HUDGrid[x, y].blockContent[2].sprite[HUDGrid[x, y].currentStep[2] - 1], HUDGrid[x, y].x, HUDGrid[x, y].y + 16);
                        }
                        if (HUDGrid[x, y].blockContent[3] != BlockID[52])//draw bottom right if not blank
                        {
                            if ((HUDGrid[x, y].blockContent[3] == BlockID[17] || HUDGrid[x, y].blockContent[3] == BlockID[54] || HUDGrid[x, y].blockContent[3] == BlockID[45] || HUDGrid[x, y].blockContent[3] == BlockID[46]) && HUDGrid[x, y].currentStep[3] > 1)
                                PicDraw(HUDGrid[x, y].blockContent[3].sprite[1], HUDGrid[x, y].x+16, HUDGrid[x, y].y+16);
                            else
                                PicDraw(HUDGrid[x, y].blockContent[3].sprite[HUDGrid[x, y].currentStep[3] - 1], HUDGrid[x, y].x + 16, HUDGrid[x, y].y + 16);
                        }
                    }

                    //if a number based BlockID uses the bottom right corner for numbers, draw the number there
                    if (((HUDGrid[x, y].blockContent[0] == BlockID[17] || HUDGrid[x, y].blockContent[0] == BlockID[45] || HUDGrid[x, y].blockContent[0] == BlockID[46]) && HUDGrid[x, y].currentStep[0] > 1 || HUDGrid[x, y].blockContent[0] == BlockID[54]) && HUDGrid[x, y].format == 1)
                        PicNumberDraw(HUDGrid[x, y].currentStep[0] - 1, HUDGrid[x, y].x + 22, HUDGrid[x, y].y + 18);
                    else if (((HUDGrid[x, y].blockContent[1] == BlockID[17] || HUDGrid[x, y].blockContent[1] == BlockID[45] || HUDGrid[x, y].blockContent[1] == BlockID[46]) && HUDGrid[x, y].currentStep[1] > 1 || HUDGrid[x, y].blockContent[1] == BlockID[54]) && (HUDGrid[x, y].format == 2 || HUDGrid[x, y].format == 3))
                        PicNumberDraw(HUDGrid[x, y].currentStep[1] - 1, HUDGrid[x, y].x + 22, HUDGrid[x, y].y + 18);
                    else if (((HUDGrid[x, y].blockContent[3] == BlockID[17] || HUDGrid[x, y].blockContent[3] == BlockID[45] || HUDGrid[x, y].blockContent[3] == BlockID[46]) && HUDGrid[x, y].currentStep[3] > 1 || HUDGrid[x, y].blockContent[3] == BlockID[54]) && HUDGrid[x, y].format == 4)
                        PicNumberDraw(HUDGrid[x, y].currentStep[3] - 1, HUDGrid[x, y].x + 22, HUDGrid[x, y].y + 18);

                    //if a number based BlockID uses the bottom left corner for numbers, draw the number there
                    if (((HUDGrid[x, y].blockContent[0] == BlockID[17] || HUDGrid[x, y].blockContent[0] == BlockID[45] || HUDGrid[x, y].blockContent[0] == BlockID[46]) && HUDGrid[x, y].currentStep[0] > 1 || HUDGrid[x, y].blockContent[0] == BlockID[54]) && HUDGrid[x, y].format == 2)
                        PicNumberDraw(HUDGrid[x, y].currentStep[0] - 1, HUDGrid[x, y].x + 6, HUDGrid[x, y].y + 18);
                    else if (((HUDGrid[x, y].blockContent[2] == BlockID[17] || HUDGrid[x, y].blockContent[2] == BlockID[45] || HUDGrid[x, y].blockContent[2] == BlockID[46]) && HUDGrid[x, y].currentStep[2] > 1 || HUDGrid[x, y].blockContent[2] == BlockID[54]) && HUDGrid[x, y].format == 4)
                        PicNumberDraw(HUDGrid[x, y].currentStep[2] - 1, HUDGrid[x, y].x + 6, HUDGrid[x, y].y + 18);

                    //if a number based BlockID uses the top right corner for numbers, draw the number there
                    if (((HUDGrid[x, y].blockContent[0] == BlockID[17] || HUDGrid[x, y].blockContent[0] == BlockID[45] || HUDGrid[x, y].blockContent[0] == BlockID[46]) && HUDGrid[x, y].currentStep[0] > 1 || HUDGrid[x, y].blockContent[0] == BlockID[54]) && HUDGrid[x, y].format == 3)
                        PicNumberDraw(HUDGrid[x, y].currentStep[0] - 1, HUDGrid[x, y].x + 22, HUDGrid[x, y].y + 2);
                    else if (((HUDGrid[x, y].blockContent[1] == BlockID[17]|| HUDGrid[x, y].blockContent[1] == BlockID[45] || HUDGrid[x, y].blockContent[1] == BlockID[46]) && HUDGrid[x, y].currentStep[1] > 1 || HUDGrid[x, y].blockContent[1] == BlockID[54]) && HUDGrid[x, y].format == 4)
                        PicNumberDraw(HUDGrid[x, y].currentStep[1] - 1, HUDGrid[x, y].x + 22, HUDGrid[x, y].y + 2);

                    //if a number based BlockID uses the top left corner for numbers, draw the number there
                    else if (((HUDGrid[x, y].blockContent[0] == BlockID[17] || HUDGrid[x, y].blockContent[0] == BlockID[45] || HUDGrid[x, y].blockContent[0] == BlockID[46]) && HUDGrid[x, y].currentStep[0] > 1 || HUDGrid[x, y].blockContent[0] == BlockID[54]) && HUDGrid[x, y].format == 4)
                        PicNumberDraw(HUDGrid[x, y].currentStep[0] - 1, HUDGrid[x, y].x + 6, HUDGrid[x, y].y + 2);
                }
            }
        }

        public class HUDBlock
        {
            public string name;
            public int size; //11 = 1x1, 12 = 1x2, 21 = 2x1, 22 = 2x2
            public int leftSteps; //1 = toggle, 2+ = increasing
            public int rightSteps; //1 = toggle or decreasing, else = increasing
            public bool leftLooping; //does it loop back to step 0 from the end
            public bool rightLooping; //does it loop back to step 0 from the end
            public Texture2D[] sprite;
        }

        public class Square
        {
            public int x, y;
            public int format; // 1 [ ] 2 [|] 3 [--] 4 [-|-]
            public HUDBlock[] blockContent = new HUDBlock[4]; // TL TR BL BR
            public int[] currentStep = new int[4]; //step for each potential blockContent
        }

        //declaring the grid
        public Square[,] HUDGrid = new Square[7, 6];
        //declaring all HUDBlock items
        public HUDBlock[] BlockID = new HUDBlock[55];

        public void DeclareBlockIDs()
        {//Sets all information for each block content, and sets grids base settings
            for (int i = 0; i < 55; i++)
            {//default setting for all base IDs.
                BlockID[i].name = "unknown";BlockID[i].size = 22; BlockID[i].leftSteps = 1; BlockID[i].rightSteps = 1; BlockID[i].leftLooping = false; BlockID[i].rightLooping = false;
            }
            BlockID[0].name = "Bow"; BlockID[0].leftSteps = 3; BlockID[0].sprite = new Texture2D[4];
            BlockID[1].name = "Bluemerang"; BlockID[1].size = 12; BlockID[1].sprite = new Texture2D[2];
            BlockID[2].name = "Redmerang"; BlockID[2].size = 12; BlockID[2].sprite = new Texture2D[2];
            BlockID[3].name = "Hookshot"; BlockID[3].sprite = new Texture2D[2];
            BlockID[4].name = "Mushroom";  BlockID[4].sprite = new Texture2D[2];
            BlockID[5].name = "Powder"; BlockID[5].sprite = new Texture2D[2];
            BlockID[6].name = "FireRod"; BlockID[6].sprite = new Texture2D[2];
            BlockID[7].name = "IceRod"; BlockID[7].sprite = new Texture2D[2];
            BlockID[8].name = "Bombos"; BlockID[8].sprite = new Texture2D[2];
            BlockID[9].name = "Ether"; BlockID[9].sprite = new Texture2D[2];
            BlockID[10].name = "Quake"; BlockID[10].sprite = new Texture2D[2];
            BlockID[11].name = "Lamp"; BlockID[11].sprite = new Texture2D[2];
            BlockID[12].name = "Hammer"; BlockID[12].sprite = new Texture2D[2];
            BlockID[13].name = "Flute"; BlockID[13].sprite = new Texture2D[2];
            BlockID[14].name = "Shovel"; BlockID[14].sprite = new Texture2D[2];
            BlockID[15].name = "Net"; BlockID[15].sprite = new Texture2D[2];
            BlockID[16].name = "Book"; BlockID[16].sprite = new Texture2D[2];
            BlockID[17].name = "Bottle"; BlockID[17].leftSteps = 5; BlockID[17].sprite = new Texture2D[2];
            BlockID[18].name = "RedCane"; BlockID[18].sprite = new Texture2D[2];
            BlockID[19].name = "BlueCane"; BlockID[19].sprite = new Texture2D[2];
            BlockID[20].name = "Cape"; BlockID[20].sprite = new Texture2D[2];
            BlockID[21].name = "Mirror"; BlockID[21].sprite = new Texture2D[2];
            BlockID[22].name = "Pearl"; BlockID[22].sprite = new Texture2D[2];
            BlockID[23].name = "Boots"; BlockID[23].sprite = new Texture2D[2];
            BlockID[24].name = "Gloves"; BlockID[24].leftSteps = 3; BlockID[24].sprite = new Texture2D[3];
            BlockID[25].name = "Flippers"; BlockID[25].sprite = new Texture2D[2];
            BlockID[26].name = "Magic"; BlockID[26].leftSteps = 3; BlockID[26].sprite = new Texture2D[3];
            BlockID[27].name = "Sword"; BlockID[27].leftSteps = 5; BlockID[27].sprite = new Texture2D[5];
            BlockID[28].name = "Shield"; BlockID[28].leftSteps = 4; BlockID[28].sprite = new Texture2D[4];
            BlockID[29].name = "Tunic"; BlockID[29].leftSteps = 3; BlockID[29].sprite = new Texture2D[3];
            BlockID[30].name = "BossReward"; BlockID[30].rightSteps = 10; BlockID[30].rightLooping = true; BlockID[30].sprite = new Texture2D[9];
            BlockID[31].name = "EP"; BlockID[31].sprite = new Texture2D[2];
            BlockID[32].name = "DP"; BlockID[32].sprite = new Texture2D[2];
            BlockID[33].name = "TOH"; BlockID[33].sprite = new Texture2D[2];
            BlockID[34].name = "POD"; BlockID[34].sprite = new Texture2D[2];
            BlockID[35].name = "SP"; BlockID[35].sprite = new Texture2D[2];
            BlockID[36].name = "SW"; BlockID[36].sprite = new Texture2D[2];
            BlockID[37].name = "TT"; BlockID[37].sprite = new Texture2D[2];
            BlockID[38].name = "IP"; BlockID[38].sprite = new Texture2D[2];
            BlockID[39].name = "MM"; BlockID[39].sprite = new Texture2D[2];
            BlockID[40].name = "TR"; BlockID[40].sprite = new Texture2D[2];
            BlockID[41].name = "HC"; BlockID[41].sprite = new Texture2D[2];
            BlockID[42].name = "AT"; BlockID[42].sprite = new Texture2D[2];
            BlockID[43].name = "GT"; BlockID[43].sprite = new Texture2D[2];
            BlockID[44].name = "Agahnim"; BlockID[44].sprite = new Texture2D[2];
            BlockID[45].name = "HeartPiece"; BlockID[45].leftSteps = 25; BlockID[45].sprite = new Texture2D[2];
            BlockID[46].name = "HeartContainer"; BlockID[46].leftSteps = 12; BlockID[46].sprite = new Texture2D[2];
            BlockID[47].name = "BigKey"; BlockID[47].sprite = new Texture2D[2];
            BlockID[48].name = "Numbers"; BlockID[48].leftSteps = 10; BlockID[48].sprite = new Texture2D[10];
            BlockID[49].name = "Bombs"; BlockID[49].sprite = new Texture2D[2];
            BlockID[50].name = "MSPed"; BlockID[50].sprite = new Texture2D[2];
            BlockID[51].name = "BigBomb"; BlockID[51].sprite = new Texture2D[2];
            BlockID[52].name = "Nothing"; BlockID[52].sprite = new Texture2D[2];// BlockID 52 is the blank template
            BlockID[53].name = "Silvers"; BlockID[53].sprite = new Texture2D[2];
            BlockID[54].name = "SmallKey"; BlockID[54].leftSteps = 10; BlockID[54].sprite = new Texture2D[2];
        }

        public void PresetStandard()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    HUDGrid[x, y].format = 1;
                    HUDGrid[x, y].x = x * 33 + 1;
                    HUDGrid[x, y].y = y * 33 + 21;
                    for (int i = 0; i < 4; i++)
                    {
                        HUDGrid[x, y].blockContent[i] = BlockID[52];
                    }
                }
            }

            HUDGrid[0, 0].blockContent[0] = BlockID[0];
            HUDGrid[1, 0].format = 2;
            HUDGrid[1, 0].blockContent[0] = BlockID[1];
            HUDGrid[1, 0].blockContent[1] = BlockID[2];
            HUDGrid[2, 0].blockContent[0] = BlockID[3];
            HUDGrid[3, 0].blockContent[0] = BlockID[4];
            HUDGrid[4, 0].blockContent[0] = BlockID[5];
            HUDGrid[5, 0].blockContent[0] = BlockID[45];
            HUDGrid[6, 0].format = 4;
            HUDGrid[6, 0].blockContent[0] = BlockID[31];
            HUDGrid[6, 0].blockContent[3] = BlockID[30];
            HUDGrid[0, 1].blockContent[0] = BlockID[6];
            HUDGrid[1, 1].blockContent[0] = BlockID[7];
            HUDGrid[2, 1].blockContent[0] = BlockID[8];
            HUDGrid[3, 1].blockContent[0] = BlockID[9];
            HUDGrid[4, 1].blockContent[0] = BlockID[10];
            HUDGrid[5, 1].blockContent[0] = BlockID[46];
            HUDGrid[6, 1].format = 4;
            HUDGrid[6, 1].blockContent[0] = BlockID[32];
            HUDGrid[6, 1].blockContent[3] = BlockID[30];
            HUDGrid[0, 2].blockContent[0] = BlockID[11];
            HUDGrid[1, 2].blockContent[0] = BlockID[12];
            HUDGrid[2, 2].blockContent[0] = BlockID[13];
            HUDGrid[3, 2].blockContent[0] = BlockID[14];
            HUDGrid[4, 2].blockContent[0] = BlockID[15];
            HUDGrid[5, 2].blockContent[0] = BlockID[16];
            HUDGrid[6, 2].format = 4;
            HUDGrid[6, 2].blockContent[0] = BlockID[33];
            HUDGrid[6, 2].blockContent[3] = BlockID[30];
            HUDGrid[0, 3].blockContent[0] = BlockID[17];
            HUDGrid[1, 3].blockContent[0] = BlockID[18];
            HUDGrid[2, 3].blockContent[0] = BlockID[19];
            HUDGrid[3, 3].blockContent[0] = BlockID[20];
            HUDGrid[4, 3].blockContent[0] = BlockID[21];
            HUDGrid[5, 3].blockContent[0] = BlockID[22];
            HUDGrid[6, 3].blockContent[0] = BlockID[44];
            HUDGrid[0, 4].blockContent[0] = BlockID[23];
            HUDGrid[1, 4].blockContent[0] = BlockID[24];
            HUDGrid[2, 4].blockContent[0] = BlockID[25];
            HUDGrid[3, 4].blockContent[0] = BlockID[26];
            HUDGrid[4, 4].blockContent[0] = BlockID[27];
            HUDGrid[5, 4].blockContent[0] = BlockID[28];
            HUDGrid[6, 4].blockContent[0] = BlockID[29];
            HUDGrid[0, 5].format = 4;
            HUDGrid[0, 5].blockContent[0] = BlockID[34];
            HUDGrid[0, 5].blockContent[3] = BlockID[30];
            HUDGrid[1, 5].format = 4;
            HUDGrid[1, 5].blockContent[0] = BlockID[35];
            HUDGrid[1, 5].blockContent[3] = BlockID[30];
            HUDGrid[2, 5].format = 4;
            HUDGrid[2, 5].blockContent[0] = BlockID[36];
            HUDGrid[2, 5].blockContent[3] = BlockID[30];
            HUDGrid[3, 5].format = 4;
            HUDGrid[3, 5].blockContent[0] = BlockID[37];
            HUDGrid[3, 5].blockContent[3] = BlockID[30];
            HUDGrid[4, 5].format = 4;
            HUDGrid[4, 5].blockContent[0] = BlockID[38];
            HUDGrid[4, 5].blockContent[3] = BlockID[30];
            HUDGrid[5, 5].format = 4;
            HUDGrid[5, 5].blockContent[0] = BlockID[39];
            HUDGrid[5, 5].blockContent[3] = BlockID[30];
            HUDGrid[6, 5].format = 4;
            HUDGrid[6, 5].blockContent[0] = BlockID[40];
            HUDGrid[6, 5].blockContent[3] = BlockID[30];
            preset = "Standard";
        }

        public void PresetKeysanity()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    HUDGrid[x, y].format = 1;
                    HUDGrid[x, y].x = x * 33 + 1;
                    HUDGrid[x, y].y = y * 33 + 21;
                    for (int i = 0; i < 4; i++)
                    {
                        HUDGrid[x, y].blockContent[i] = BlockID[52];
                    }
                }
            }

            HUDGrid[0, 0].blockContent[0] = BlockID[0];
            HUDGrid[1, 0].format = 2;
            HUDGrid[1, 0].blockContent[0] = BlockID[1];
            HUDGrid[1, 0].blockContent[1] = BlockID[2];
            HUDGrid[2, 0].blockContent[0] = BlockID[3];
            HUDGrid[3, 0].blockContent[0] = BlockID[4];
            HUDGrid[4, 0].blockContent[0] = BlockID[5];
            HUDGrid[0, 1].blockContent[0] = BlockID[6];
            HUDGrid[1, 1].blockContent[0] = BlockID[7];
            HUDGrid[2, 1].blockContent[0] = BlockID[8];
            HUDGrid[3, 1].blockContent[0] = BlockID[9];
            HUDGrid[4, 1].blockContent[0] = BlockID[10];
            HUDGrid[0, 2].blockContent[0] = BlockID[11];
            HUDGrid[1, 2].blockContent[0] = BlockID[12];
            HUDGrid[2, 2].blockContent[0] = BlockID[13];
            HUDGrid[3, 2].blockContent[0] = BlockID[14];
            HUDGrid[4, 2].blockContent[0] = BlockID[16];
            HUDGrid[0, 3].blockContent[0] = BlockID[17];
            HUDGrid[1, 3].blockContent[0] = BlockID[18];
            HUDGrid[2, 3].blockContent[0] = BlockID[19];
            HUDGrid[3, 3].blockContent[0] = BlockID[20];
            HUDGrid[4, 3].blockContent[0] = BlockID[21];
            HUDGrid[0, 4].blockContent[0] = BlockID[23];
            HUDGrid[1, 4].blockContent[0] = BlockID[24];
            HUDGrid[2, 4].blockContent[0] = BlockID[25];
            HUDGrid[3, 4].blockContent[0] = BlockID[22];
            HUDGrid[4, 4].blockContent[0] = BlockID[15];
            HUDGrid[0, 5].blockContent[0] = BlockID[27];
            HUDGrid[1, 5].blockContent[0] = BlockID[28];
            HUDGrid[2, 5].blockContent[0] = BlockID[29];
            HUDGrid[3, 5].blockContent[0] = BlockID[26];
            HUDGrid[4, 5].blockContent[0] = BlockID[44];

            for (int x = 5; x < 7; x++)
                for (int y = 0; y < 6; y++)
                    HUDGrid[x,y].format = 4;

            HUDGrid[5, 0].blockContent[0] = BlockID[31];
            HUDGrid[5, 0].blockContent[1] = BlockID[30];
            HUDGrid[6, 0].blockContent[0] = BlockID[48];
            HUDGrid[6, 0].blockContent[1] = BlockID[47];
            HUDGrid[5, 0].blockContent[2] = BlockID[32];
            HUDGrid[5, 0].blockContent[3] = BlockID[30];
            HUDGrid[6, 0].blockContent[2] = BlockID[48];
            HUDGrid[6, 0].blockContent[3] = BlockID[47];
            HUDGrid[5, 1].blockContent[0] = BlockID[33];
            HUDGrid[5, 1].blockContent[1] = BlockID[30];
            HUDGrid[6, 1].blockContent[0] = BlockID[48];
            HUDGrid[6, 1].blockContent[1] = BlockID[47];
            HUDGrid[5, 1].blockContent[2] = BlockID[41];
            HUDGrid[5, 1].blockContent[3] = BlockID[48];
            HUDGrid[6, 1].blockContent[2] = BlockID[42];
            HUDGrid[6, 1].blockContent[3] = BlockID[48];
            HUDGrid[5, 2].blockContent[0] = BlockID[34];
            HUDGrid[5, 2].blockContent[1] = BlockID[30];
            HUDGrid[6, 2].blockContent[0] = BlockID[48];
            HUDGrid[6, 2].blockContent[1] = BlockID[47];
            HUDGrid[5, 2].blockContent[2] = BlockID[35];
            HUDGrid[5, 2].blockContent[3] = BlockID[30];
            HUDGrid[6, 2].blockContent[2] = BlockID[48];
            HUDGrid[6, 2].blockContent[3] = BlockID[47];
            HUDGrid[5, 3].blockContent[0] = BlockID[36];
            HUDGrid[5, 3].blockContent[1] = BlockID[30];
            HUDGrid[6, 3].blockContent[0] = BlockID[48];
            HUDGrid[6, 3].blockContent[1] = BlockID[47];
            HUDGrid[5, 3].blockContent[2] = BlockID[37];
            HUDGrid[5, 3].blockContent[3] = BlockID[30];
            HUDGrid[6, 3].blockContent[2] = BlockID[48];
            HUDGrid[6, 3].blockContent[3] = BlockID[47];
            HUDGrid[5, 4].blockContent[0] = BlockID[38];
            HUDGrid[5, 4].blockContent[1] = BlockID[30];
            HUDGrid[6, 4].blockContent[0] = BlockID[48];
            HUDGrid[6, 4].blockContent[1] = BlockID[47];
            HUDGrid[5, 4].blockContent[2] = BlockID[39];
            HUDGrid[5, 4].blockContent[3] = BlockID[30];
            HUDGrid[6, 4].blockContent[2] = BlockID[48];
            HUDGrid[6, 4].blockContent[3] = BlockID[47];
            HUDGrid[5, 5].blockContent[0] = BlockID[40];
            HUDGrid[5, 5].blockContent[1] = BlockID[30];
            HUDGrid[6, 5].blockContent[0] = BlockID[48];
            HUDGrid[6, 5].blockContent[1] = BlockID[47];
            HUDGrid[5, 5].blockContent[2] = BlockID[43];
            HUDGrid[6, 5].blockContent[2] = BlockID[48];
            HUDGrid[6, 5].blockContent[3] = BlockID[47];
            preset = "Keysanity";
        }

        public void PresetMini()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    HUDGrid[x, y].format = 1;
                    HUDGrid[x, y].x = x * 33 + 1;
                    HUDGrid[x, y].y = y * 33 + 21;
                    for (int i = 0; i < 4; i++)
                    {
                        HUDGrid[x, y].blockContent[i] = BlockID[52];
                    }
                }
            }

            HUDGrid[0, 0].blockContent[0] = BlockID[0];
            HUDGrid[1, 0].format = 2;
            HUDGrid[1, 0].blockContent[0] = BlockID[1];
            HUDGrid[1, 0].blockContent[1] = BlockID[2];
            HUDGrid[2, 0].blockContent[0] = BlockID[3];
            HUDGrid[3, 0].blockContent[0] = BlockID[4];
            HUDGrid[4, 0].blockContent[0] = BlockID[5];
            HUDGrid[5, 0].blockContent[0] = BlockID[23];
            HUDGrid[6, 0].format = 4;
            HUDGrid[6, 0].blockContent[0] = BlockID[31];
            HUDGrid[6, 0].blockContent[3] = BlockID[30];
            HUDGrid[0, 1].blockContent[0] = BlockID[6];
            HUDGrid[1, 1].blockContent[0] = BlockID[7];
            HUDGrid[2, 1].blockContent[0] = BlockID[8];
            HUDGrid[3, 1].blockContent[0] = BlockID[9];
            HUDGrid[4, 1].blockContent[0] = BlockID[10];
            HUDGrid[5, 1].blockContent[0] = BlockID[24];
            HUDGrid[6, 1].format = 4;
            HUDGrid[6, 1].blockContent[0] = BlockID[32];
            HUDGrid[6, 1].blockContent[3] = BlockID[30];
            HUDGrid[0, 2].blockContent[0] = BlockID[11];
            HUDGrid[1, 2].blockContent[0] = BlockID[12];
            HUDGrid[2, 2].blockContent[0] = BlockID[13];
            HUDGrid[3, 2].blockContent[0] = BlockID[14];
            HUDGrid[4, 2].blockContent[0] = BlockID[16];
            HUDGrid[5, 2].blockContent[0] = BlockID[25];
            HUDGrid[6, 2].format = 4;
            HUDGrid[6, 2].blockContent[0] = BlockID[33];
            HUDGrid[6, 2].blockContent[3] = BlockID[30];
            HUDGrid[0, 3].blockContent[0] = BlockID[17];
            HUDGrid[1, 3].blockContent[0] = BlockID[18];
            HUDGrid[2, 3].blockContent[0] = BlockID[19];
            HUDGrid[3, 3].blockContent[0] = BlockID[20];
            HUDGrid[4, 3].blockContent[0] = BlockID[21];
            HUDGrid[5, 3].blockContent[0] = BlockID[22];
            HUDGrid[6, 3].blockContent[0] = BlockID[27];
            HUDGrid[0, 4].format = 4;
            HUDGrid[0, 4].blockContent[0] = BlockID[34];
            HUDGrid[0, 4].blockContent[3] = BlockID[30];
            HUDGrid[1, 4].format = 4;
            HUDGrid[1, 4].blockContent[0] = BlockID[35];
            HUDGrid[1, 4].blockContent[3] = BlockID[30];
            HUDGrid[2, 4].format = 4;
            HUDGrid[2, 4].blockContent[0] = BlockID[36];
            HUDGrid[2, 4].blockContent[3] = BlockID[30];
            HUDGrid[3, 4].format = 4;
            HUDGrid[3, 4].blockContent[0] = BlockID[37];
            HUDGrid[3, 4].blockContent[3] = BlockID[30];
            HUDGrid[4, 4].format = 4;
            HUDGrid[4, 4].blockContent[0] = BlockID[38];
            HUDGrid[4, 4].blockContent[3] = BlockID[30];
            HUDGrid[5, 4].format = 4;
            HUDGrid[5, 4].blockContent[0] = BlockID[39];
            HUDGrid[5, 4].blockContent[3] = BlockID[30];
            HUDGrid[6, 4].format = 4;
            HUDGrid[6, 4].blockContent[0] = BlockID[40];
            HUDGrid[6, 4].blockContent[3] = BlockID[30];
            preset = "Mini";
        }

        public void PresetMiniKeysanity()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    HUDGrid[x, y].format = 1;
                    HUDGrid[x, y].x = x * 33 + 1;
                    HUDGrid[x, y].y = y * 33 + 21;
                    for (int i = 0; i < 4; i++)
                    {
                        HUDGrid[x, y].blockContent[i] = BlockID[52];
                    }
                }
            }

            HUDGrid[0, 0].blockContent[0] = BlockID[0];
            HUDGrid[1, 0].format = 2;
            HUDGrid[1, 0].blockContent[0] = BlockID[1];
            HUDGrid[1, 0].blockContent[1] = BlockID[2];
            HUDGrid[2, 0].blockContent[0] = BlockID[3];
            HUDGrid[3, 0].blockContent[0] = BlockID[4];
            HUDGrid[4, 0].blockContent[0] = BlockID[5];
            HUDGrid[5, 0].blockContent[0] = BlockID[23];
            HUDGrid[6, 0].format = 4;
            HUDGrid[6, 0].blockContent[0] = BlockID[31];
            HUDGrid[6, 0].blockContent[1] = BlockID[30];
            HUDGrid[6, 0].blockContent[2] = BlockID[48];
            HUDGrid[6, 0].blockContent[3] = BlockID[47];
            HUDGrid[0, 1].blockContent[0] = BlockID[6];
            HUDGrid[1, 1].blockContent[0] = BlockID[7];
            HUDGrid[2, 1].blockContent[0] = BlockID[8];
            HUDGrid[3, 1].blockContent[0] = BlockID[9];
            HUDGrid[4, 1].blockContent[0] = BlockID[10];
            HUDGrid[5, 1].blockContent[0] = BlockID[24];
            HUDGrid[6, 1].format = 4;
            HUDGrid[6, 1].blockContent[0] = BlockID[32];
            HUDGrid[6, 1].blockContent[1] = BlockID[30];
            HUDGrid[6, 1].blockContent[2] = BlockID[48];
            HUDGrid[6, 1].blockContent[3] = BlockID[47];
            HUDGrid[0, 2].blockContent[0] = BlockID[11];
            HUDGrid[1, 2].blockContent[0] = BlockID[12];
            HUDGrid[2, 2].blockContent[0] = BlockID[13];
            HUDGrid[3, 2].blockContent[0] = BlockID[14];
            HUDGrid[4, 2].blockContent[0] = BlockID[16];
            HUDGrid[5, 2].blockContent[0] = BlockID[25];
            HUDGrid[6, 2].format = 4;
            HUDGrid[6, 2].blockContent[0] = BlockID[33];
            HUDGrid[6, 2].blockContent[1] = BlockID[30];
            HUDGrid[6, 2].blockContent[2] = BlockID[48];
            HUDGrid[6, 2].blockContent[3] = BlockID[47];
            HUDGrid[0, 3].blockContent[0] = BlockID[17];
            HUDGrid[1, 3].blockContent[0] = BlockID[18];
            HUDGrid[2, 3].blockContent[0] = BlockID[19];
            HUDGrid[3, 3].blockContent[0] = BlockID[20];
            HUDGrid[4, 3].blockContent[0] = BlockID[21];
            HUDGrid[5, 3].blockContent[0] = BlockID[22];
            HUDGrid[6, 3].format = 4;
            HUDGrid[6, 3].blockContent[0] = BlockID[43];
            HUDGrid[6, 3].blockContent[2] = BlockID[48];
            HUDGrid[6, 3].blockContent[3] = BlockID[47];
            HUDGrid[0, 4].format = 4;
            HUDGrid[0, 4].blockContent[0] = BlockID[34];
            HUDGrid[0, 4].blockContent[1] = BlockID[30];
            HUDGrid[0, 4].blockContent[2] = BlockID[48];
            HUDGrid[0, 4].blockContent[3] = BlockID[47];
            HUDGrid[1, 4].format = 4;
            HUDGrid[1, 4].blockContent[0] = BlockID[35];
            HUDGrid[1, 4].blockContent[1] = BlockID[30];
            HUDGrid[1, 4].blockContent[2] = BlockID[48];
            HUDGrid[1, 4].blockContent[3] = BlockID[47];
            HUDGrid[2, 4].format = 4;
            HUDGrid[2, 4].blockContent[0] = BlockID[36];
            HUDGrid[2, 4].blockContent[1] = BlockID[30];
            HUDGrid[2, 4].blockContent[2] = BlockID[48];
            HUDGrid[2, 4].blockContent[3] = BlockID[47];
            HUDGrid[3, 4].format = 4;
            HUDGrid[3, 4].blockContent[0] = BlockID[37];
            HUDGrid[3, 4].blockContent[1] = BlockID[30];
            HUDGrid[3, 4].blockContent[2] = BlockID[48];
            HUDGrid[3, 4].blockContent[3] = BlockID[47];
            HUDGrid[4, 4].format = 4;
            HUDGrid[4, 4].blockContent[0] = BlockID[38];
            HUDGrid[4, 4].blockContent[1] = BlockID[30];
            HUDGrid[4, 4].blockContent[2] = BlockID[48];
            HUDGrid[4, 4].blockContent[3] = BlockID[47];
            HUDGrid[5, 4].format = 4;
            HUDGrid[5, 4].blockContent[0] = BlockID[39];
            HUDGrid[5, 4].blockContent[1] = BlockID[30];
            HUDGrid[5, 4].blockContent[2] = BlockID[48];
            HUDGrid[5, 4].blockContent[3] = BlockID[47];
            HUDGrid[6, 4].format = 4;
            HUDGrid[6, 4].blockContent[0] = BlockID[40];
            HUDGrid[6, 4].blockContent[1] = BlockID[30];
            HUDGrid[6, 4].blockContent[2] = BlockID[48];
            HUDGrid[6, 4].blockContent[3] = BlockID[47];
            preset = "Mini Keysanity";
        }

        //Variables
        public int mousex = 0;
        public int mousey = 0;
        public int resetcounter = 0;
        public int lastmousex = 0;
        public int lastmousey = 0;
        public bool clicked = false;
        public int background = 0;
        Point location, lastlocation;
        public bool AppSetup = false;
        public bool windowIsActive = false;
        public string preset = "Standard";

        //sprites
        private Texture2D pinkPic, brownPic, tealPic, purplePic, smallkeyPic, nosmallkeyPic, checkPic, XPic;
        private Texture2D[] NumberPic = new Texture2D[10];
        
        public void SetupApp()
        {
            if (AppSetup)
            {
            }
            else
            {
                config();
                this.Window.Position = location;
                ResetApp();
                PresetStandard();
                mousex = mousey = lastmousex = lastmousey = resetcounter = 0;
                AppSetup = true;
            }
        }

        public void ResetApp()
        {
            for (int x = 0; x < 7; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        HUDGrid[x, y].currentStep[i] = 1;
                    }
                }
            }
        }

        public int mousePressedTime = 0;
        public int mouseRightPressedTime = 0;
        public MouseState state = Mouse.GetState();

        private void mouse_Where()
        {
            state = Mouse.GetState();

            lastlocation = location;
            location = this.Window.Position;

            if (location != lastlocation)
                updateFile();
            mousex = state.X;
            mousey = state.Y;


            if (state.RightButton == ButtonState.Pressed && windowIsActive)
            {
                mouseRightPressedTime += 1;
            }
            else if (state.RightButton == ButtonState.Released && windowIsActive && mouseRightPressedTime > 0)
            {
                if (mousex> 0 && mousex < 30 && mousey >0 && mousey < 20)
                {
                    if (resetcounter < 2)
                        resetcounter++;
                    else
                    {
                        AppSetup = false;
                        ResetApp();
                    }
                }
                else if (mousex > 0 && mousey > 0 && mousex < graphics.PreferredBackBufferWidth - 3 && mousey < graphics.PreferredBackBufferHeight - 4)
                {
                    if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 4)
                    {// if in 4 corners layout
                        if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 16)
                        {//BOTTOM RIGHT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 16)
                        {//BOTTOM LEFT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[2] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[2], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[2]);
                        }
                        else if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 0)
                        {//TOP RIGHT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//TOP LEFT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                    }
                    else if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 3)
                    {// if in [--] layout
                        if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 16)
                        {//BOTTOM Half of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//TOP half corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                    }
                    else if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 2)
                    {// if in [|] layout
                        if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 0)
                        {//BOTTOM Half of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//TOP half corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                    }
                    else if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 1)
                    {// if in [  ] layout
                        if ((mousex - 1) % 33 > 18 && (mousey - 20) % 33 > 0 && (mousey - 20) % 33 < 13 && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0].name == "Bow")
                        {//If its Bow and the silver tip was clicked -> change step to new step based on left click procedure of silver arrows specifically
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = RightClick(BlockID[53], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//Square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = RightClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                    }
                }

                mouseRightPressedTime = 0;
            }

            if (state.LeftButton == ButtonState.Pressed && windowIsActive)
            {
                resetcounter = 0;
                mousePressedTime += 1;
            }
            else if (state.LeftButton == ButtonState.Released && windowIsActive && mousePressedTime >0)
            {
                if (mousex >= 1 && mousex <= graphics.PreferredBackBufferWidth && mousey < 0)
                {
                    if (background == 3)
                        background = 0;
                    else
                        background++;
                    updateFile();
                }
                else if (mousex > 203 && mousey > 10 && mousex < 213 && mousey < 19)
                {
                    if (preset == "Standard")
                        PresetKeysanity();
                    else if (preset == "Keysanity")
                        PresetStandard();
                    else if (preset == "Mini")
                        PresetMiniKeysanity();
                    else if (preset == "Mini Keysanity")
                        PresetMini();
                }
                else if (mousex > 219 && mousey > 10 && mousex < 229 && mousey < 19)
                {
                    if (preset == "Standard")
                        PresetMini();
                    else if (preset == "Keysanity")
                        PresetMiniKeysanity();
                    else if (preset == "Mini")
                        PresetStandard();
                    else if (preset == "Mini Keysanity")
                        PresetKeysanity();
                }
                else if (mousex > 0 && mousey > 0 && mousex < graphics.PreferredBackBufferWidth - 3 && mousey < graphics.PreferredBackBufferHeight - 4)
                {
                    if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 4)
                    {// if in 4 corners layout
                        if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 16)
                        {//BOTTOM RIGHT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 16)
                        {//BOTTOM LEFT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[2] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[2], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[2]);
                        }
                        else if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 0)
                        {//TOP RIGHT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//TOP LEFT corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                        for (int i = 31; i < 44; i++)
                        {// linking crystals and dungeons in a more flexible way
                            if ((HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0] == BlockID[i] && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1] == BlockID[30]) || (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0] == BlockID[30] && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1] == BlockID[i]))
                            {
                                if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 0 && (mousey - 20) % 33 < 17)
                                    HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                                else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0 && (mousey - 20) % 33 < 17)
                                    HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1]);
                            }
                            else if ((HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[2] == BlockID[i] && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3] == BlockID[30]) || (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[2] == BlockID[30] && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3] == BlockID[i]))
                            {
                                if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 16)
                                    HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[2] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[2], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[2]);
                                else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 16)
                                    HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3]);
                            }
                            else if ((HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0] == BlockID[i] && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3] == BlockID[30]) || (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0] == BlockID[30] && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3] == BlockID[i]))
                            {
                                if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 16)
                                    HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                                else if ((mousex - 1) % 33 > 0 && (mousex - 1) % 33 < 17 && (mousey - 20) % 33 > 0 && (mousey - 20) % 33 < 17)
                                    HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[3], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[3]);
                            }
                        }
                    }
                    else if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 3)
                    {// if in [--] layout
                        if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 16)
                        {//BOTTOM Half of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//TOP half corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                    }
                    else if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 2)
                    {// if in [|] layout
                        if ((mousex - 1) % 33 > 16 && (mousey - 20) % 33 > 0)
                        {//BOTTOM Half of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[1], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[1]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//TOP half corner of a square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                    }
                    else if (HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].format == 1)
                    {// if in [  ] layout
                        if ((mousex - 1) % 33 > 18 && (mousey - 20) % 33 > 0 && (mousey - 20) % 33 < 13 && HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0].name == "Bow")
                        {//If its Bow and the silver tip was clicked -> change step to new step based on left click procedure of silver arrows specifically
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = LeftClick(BlockID[53], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                        else if ((mousex - 1) % 33 > 0 && (mousey - 20) % 33 > 0)
                        {//Square clicked -> change step to new step based on left click procedure
                            HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0] = LeftClick(HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].blockContent[0], HUDGrid[((mousex - 1) / 33), ((mousey - 20) / 33)].currentStep[0]);
                        }
                    }
                }

                mousePressedTime = 0;
            }
            if (!windowIsActive)
            {
                mousePressedTime = 0;
                mouseRightPressedTime = 0;
            }
        }
    }
}