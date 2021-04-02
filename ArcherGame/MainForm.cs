using System;
using System.Windows.Forms;

namespace ArcherGame
{
    public partial class MainForm : Form
    {
        private readonly Game game;
        public MainForm()
        {
            InitializeComponent();
            game = new Game(archerPanel, ballonPanel);
            game.BalonVuruldu += balon_Vuruldu;

            game.TimeChanged += Game_TimeChanged;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
           
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    infoLabel.Hide();
                    game.Start();
                    break;
                case Keys.Up:
                    game.moveArcher(Direction.Up);
                    break;
                case Keys.Down:
                    game.moveArcher(Direction.Down);
                    break;
                case Keys.Space:
                    game.Fire();
                    break;
            }
        }
        private void Game_TimeChanged(object sender, EventArgs e)
        {
            sureLabel.Text = game.PassTime.ToString(@"m\:ss");
        }
        private void balon_Vuruldu(object sender, EventArgs e)
        {
            puanLabel.Text = game.Skor.ToString();
            Asama_Control();
            
        }
       
        private void Asama_Control()
        {
            if (game.Puan==100)
            {
                MessageBox.Show("2. Asamaya Gectiniz.  5 Puan Kazandiniz");
                game.Puan = 105;
            }
            if(game.Puan>=200 && game.Puan<=210)
            {
                MessageBox.Show("3. Asamaya Gectiniz. Ekstra Puan Kazandiniz");
                game.Puan = 215;
            }

        }



       
    }
}
