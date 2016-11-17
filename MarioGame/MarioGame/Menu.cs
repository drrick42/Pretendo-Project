using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public struct MenuOption
    {
        public ICommand command;
        public string name;

        public MenuOption(ICommand command, string name)
        {
            this.command = command;
            this.name = name;
        }
    }

    public class Menu: ISprite
    {
        public Vector2 Position { get; set; }
        private int selection;
        private List<MenuOption> optionList;
        private SpriteFont font;

        public Menu(SpriteFont font)
        {
            this.font = font;
            optionList = new List<MenuOption>();
            selection = 0;
        }

        public void AddOption(ICommand command, string name)
        {
            optionList.Add(new MenuOption(command, name));
        }

        public void Select()
        {
            optionList[selection].command.Execute();
        }

        public void ScrollDown()
        {
            selection = (selection + 1) % optionList.Count;
        }

        public void ScrollUp()
        {
            selection = (selection - 1);
            if (selection < 0) selection = optionList.Count + selection;
        }

        public void Update(float elapsed)
        {

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < optionList.Count; i++ )
            {
                float y = Position.Y + (i * 20f);
                if (i == selection) spriteBatch.DrawString(font,">", new Vector2(Position.X,y), Color.White);
                Vector2 pos = new Vector2(Position.X + 20f, y);
                spriteBatch.DrawString(font, optionList[i].name, pos, Color.White);
            }
                
        }
    }
}
