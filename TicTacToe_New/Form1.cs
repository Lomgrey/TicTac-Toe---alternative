using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_New
{
    public partial class Form1 : Form
    {
        bool turn = true;
        string rules = "Альтернативные крестики-нолики\nИмеется 9 маленьких полей размера 3х3\nПравила:\n1). Каждый ход делается в одно из маленьких полей\n2). Достигший в маленьком поле расположения трёх одинаковых фигур в ряд, выигрывает это поле.\n3). Чтобы выиграть игру, необходимо одержать победу в трёх маленьких полях в ряд.\nПримечания:\n1). Ход оппонента определяет Ваш ход.Если он, например, установил фигуру в правом верхнем углу одного из полей, Вы делаете свой ход в правом верхнем маленьком поле.\n2). Если оппонент отправляет Вас в поле, где уже одержана победа, Вам всё равно придётся выбрать одну из незаполненных клеток.\n3). Если оппонент отправляет Вас в заполненное поле, то Вы в праве выбрать любое другое поле для хода.\n";
        string[] Field_cycle = new string[9] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };
        int Play_Area;
        bool[] Main_Winner = new bool[9];
        short[] CRUTCH = new short[9]; //создаем массив костылей
        Bitmap _ImageX = TicTacToe_New.Properties.Resources.X;
        Bitmap _ImageO = TicTacToe_New.Properties.Resources.O;


        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(rules, "Правила Игры");
        }

        private void Click_button(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
                        
            WhoseMove(sender, e);
            whichPlaingField(sender, e);
            disableButtons();
            checkForWinner_UnMain();
        }

        void whichPlaingField(object sender, EventArgs e)
        {
            string NameButton = (sender as Button).Name;
            char[] n = NameButton.ToCharArray(); //преобразовываем srting в char
            Play_Area = (int)Char.GetNumericValue(n[1]);
        }

        //Блокировка Областей 
        private void disableButtons()
        {
            int CheckOfField = 8; //Проверка: занята ли область или нет

            for (int i = 0; i < 9; ++i)
            {
                if ((i + 1) == Play_Area)
                {
                    for (int j = 1; j <= 9; ++j)
                    {
                        //если в кнопке есть надпись, то оставляем недоступной
                        if (String.IsNullOrEmpty((Controls[Field_cycle[i] + j] as Button).Text))
                        {
                            (Controls[Field_cycle[i] + j] as Button).Enabled = true;
                            --CheckOfField;
                        }
                    }
                    continue;
                }
                for (int j = 1; j <= 9; ++j)
                    (Controls[Field_cycle[i] + j] as Button).Enabled = false;
            }

            if (CheckOfField == 8)
            {
                for (int i = 0; i < 9; ++i)
                    for (int j = 1; j <= 9; ++j)
                    {
                        if (String.IsNullOrEmpty((Controls[Field_cycle[i] + j] as Button).Text))
                        {
                            (Controls[Field_cycle[i] + j] as Button).Enabled = true;
                        }
                    }
                CheckOfField = 8;
            }
            else
                CheckOfField = 8;
        }

        private void disableAllButtons()
        {
            for (int i = 0; i < 9; ++i)
                for (int j = 1; j <= 9; ++j)
                    (Controls[Field_cycle[i] + j] as Button).Enabled = false;
        }

        private void WhoseMove(object sender, EventArgs e)
        {
            if (turn)
                labelMotion.Text = "X";
            else
                labelMotion.Text = "O";
        }

        public void DrawPicMain(int i)
        {
            if (!Main_Winner[i])
            {
                switch (i + 1)
                {
                    case 1:
                        {
                            if (!turn)
                            {
                                Box1.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box1.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 2:
                        {
                            if (!turn)
                            {
                                Box2.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box2.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 3:
                        {
                            if (!turn)
                            {
                                Box3.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box3.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 4:
                        {
                            if (!turn)
                            {
                                Box4.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box4.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 5:
                        {
                            if (!turn)
                            {
                                Box5.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box5.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 6:
                        {
                            if (!turn)
                            {
                                Box6.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box6.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 7:
                        {
                            if (!turn)
                            {
                                Box7.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box7.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 8:
                        {
                            if (!turn)
                            {
                                Box8.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box8.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                    case 9:
                        {
                            if (!turn)
                            {
                                Box9.Image = _ImageX;
                                CRUTCH[i] = 1;
                            }
                            else
                            {
                                Box9.Image = _ImageO;
                                CRUTCH[i] = 2;
                            }
                            Main_Winner[i] = true;
                            break;
                        }
                }
            }
            CheckForWinner_Main();
        }

        private void checkForWinner_UnMain()
        {
            string empty = "";

            // Горизонталь
            for (int i = 0; i < 9; ++i)
                for (int j = 1; j <= 7; j += 3)
                {
                    if (((Controls[Field_cycle[i] + j]).Text == (Controls[Field_cycle[i] + (j + 1)]).Text)
                        && ((Controls[Field_cycle[i] + (j + 1)]).Text == (Controls[Field_cycle[i] + (j + 2)]).Text)
                        && ((Controls[Field_cycle[i] + j]).Text != empty))
                    {
                        DrawPicMain(i);
                        break;
                    }
                }

            // Вертикаль 
            for (int i = 0; i < 9; ++i)
                for (int j = 1; j <= 3; ++j)
                {
                    if (((Controls[Field_cycle[i] + j]).Text == (Controls[Field_cycle[i] + (j + 3)]).Text)
                      && ((Controls[Field_cycle[i] + (j + 3)]).Text == (Controls[Field_cycle[i] + (j + 6)]).Text)
                      && ((Controls[Field_cycle[i] + j]).Text != empty))
                    {
                        DrawPicMain(i);
                        break;
                    }
                }

            // Правая Диагональ
            for (int i = 0, j = 1; i < 9; ++i)
            {
                if ((Controls[Field_cycle[i] + j]).Text == (Controls[Field_cycle[i] + (j + 4)]).Text
                      && (Controls[Field_cycle[i] + (j + 4)]).Text == (Controls[Field_cycle[i] + (j + 8)]).Text
                      && ((Controls[Field_cycle[i] + j]).Text != empty))
                {
                    DrawPicMain(i);
                }
            }

            // Левая Диагональ 
            for (int i = 0, j = 3; i < 9; ++i)
            {
                if ((Controls[Field_cycle[i] + j]).Text == (Controls[Field_cycle[i] + (j + 2)]).Text
                    && (Controls[Field_cycle[i] + (j + 2)]).Text == (Controls[Field_cycle[i] + (j + 4)]).Text
                    && ((Controls[Field_cycle[i] + j]).Text != empty))
                {
                    DrawPicMain(i);
                }
            }
        }

        private void CheckForWinner_Main()
        {
            bool is_winner = false;

            // Горизонталь
            for (int i = 0; i <= 6; i += 3)
                if (CRUTCH[i] == CRUTCH[i + 1]
                    && CRUTCH[i + 1] == CRUTCH[i + 2]
                    && CRUTCH[i] != 0)
                {
                    is_winner = true;
                    break;
                }

            // Вертикаль 
            for (int i = 0; i <= 2; ++i)
                if (CRUTCH[i] == CRUTCH[i + 3]
                    && CRUTCH[i + 3] == CRUTCH[i + 6]
                    && CRUTCH[i] != 0)
                {
                    is_winner = true;
                    break;
                }

            // Правая Диагональ 
            {
                int i = 0;
                if (CRUTCH[i] == CRUTCH[i + 4]
                    && CRUTCH[i + 4] == CRUTCH[i + 8]
                    && CRUTCH[i] != 0)
                {
                    is_winner = true;
                }
            }

            //Левая Диагональ
            {
                int i = 2;
                if (CRUTCH[i] == CRUTCH[i + 2]
                    && CRUTCH[i + 2] == CRUTCH[i + 4]
                    && CRUTCH[i] != 0)
                {
                    is_winner = true;
                }
            }

            if (is_winner)
            {
                string winner;
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                disableAllButtons();
                MessageBox.Show(winner + " Wins!", "END");
            }
        }

        private void New_Game(object sender, EventArgs e)
        {
            string empty = ""; //подчищаем кледки поля 

            turn = true;
            for (int i = 0; i < 9; ++i)
                for (int j = 1; j <= 9; ++j)
                {
                    {                        
                        WhoseMove(sender, e);
                        (Controls[Field_cycle[i] + j] as Button).Text = empty;
                        (Controls[Field_cycle[i] + j] as Button).Enabled = true;                        
                    }
                }
            Box_Null();
            (Controls["E5"]).Enabled = false;
            for (int i = 0; i < 9; ++i)
                Main_Winner[i] = false;
            for (int i = 0; i < 9; ++i)
                CRUTCH[i] = 0;
        }

        public void Box_Null()
        {
            Box1.Image = null;
            Box2.Image = null;
            Box3.Image = null;
            Box4.Image = null;
            Box5.Image = null;
            Box6.Image = null;
            Box7.Image = null;
            Box8.Image = null;
            Box9.Image = null;
        }

        private void mouse_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }
    }
}
