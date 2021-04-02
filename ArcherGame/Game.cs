using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ArcherGame
{
    public class Game : IGame
    {
        private readonly Timer _passTimeTimer = new Timer { Interval = 1000 };
        private readonly Timer _movementTimer = new Timer { Interval = 500 };

        private readonly Timer _createBallonTimer = new Timer { Interval = 2000 };
        private readonly Timer _createYellowBallonTimer = new Timer { Interval = 3000 };
        private readonly Timer _createRedBallonTimer = new Timer { Interval = 9000 };
        private TimeSpan _passTime;

        private readonly Panel _archerPanel;
        private readonly Panel _ballonPanel;

        private Archer _archer;
        private readonly List<Arrow> _arrow = new List<Arrow>();
        private readonly List<Ballon> _ballon = new List<Ballon>();
        private readonly List<YellowBallon> _yellowBallon = new List<YellowBallon>();
        private readonly List<RedBallon> _redBallon = new List<RedBallon>();

        public event EventHandler TimeChanged;
        public event EventHandler BalonVuruldu;
        public int puan; // Asama icin puan tutulan yer
        public int skor; // Kullaniciya gostermek icin puan tutulan yer
        

        public int Skor
        {
            get => skor;
        
        set{
                if (value <= -1) return;
                skor = value;
                BalonVuruldu?.Invoke(this, new EventArgs());
            }
        }
        public int Puan
            {
            get => puan;
            set {  
                if(value<=0) return;
            puan=value;
                BalonVuruldu?.Invoke(this, new EventArgs());
            }
        }

        public bool IsContinue { get; private set; }
        public TimeSpan PassTime {
            get => _passTime;
            private set
            {
                _passTime = value;
                TimeChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        #region Methods

        public Game(Panel archerPanel, Panel ballonPanel)
        {
            _passTimeTimer.Tick += PassTimeTimer_Tick;
            _movementTimer.Tick += MovementTimer_Tick;

            _createBallonTimer.Tick += CreateBallonTimer_Tick;
            _createYellowBallonTimer.Tick += CreateYellowBallonTimer_Tick;
            _createRedBallonTimer.Tick += CreateRedBallonTimer_Tick;

            _archerPanel = archerPanel;
            _ballonPanel = ballonPanel;
        }

       
        private void PassTimeTimer_Tick(object sender, EventArgs e) //Sure Sayaci
        {
            PassTime += TimeSpan.FromSeconds(1);
        }

        private void MovementTimer_Tick(object sender, EventArgs e)  //Asamaya gore uretim ve hareket sureleri degisiyor.
        {
            if (puan < 100)
                _movementTimer.Interval = 500;

            else if (puan < 200)
            {
                _movementTimer.Interval = 200;
                
            }

            else
            {
                _movementTimer.Interval = 100;
                _createYellowBallonTimer.Interval = 4000;
                _createRedBallonTimer.Interval = 6000;
            }
                
            MoveArrow();
            MoveBallon();
            MoveYellowBallon();
            MoveRedBallon();
            DeleteBallon();
            DeleteYellowBallon();
            DeleteRedBallon();
        }
        //---------------BALONLARIN VURULUNCA SILINMESI------------------
       
        private void DeleteBallon()
        {
            for (var i=_ballon.Count-1; i >= 0; i--)
            {
                var ballon = _ballon[i];

                var vuranOk = ballon.IsShot(_arrow);
                if (vuranOk is null) continue;

                _ballon.Remove(ballon);
                Puan += 5;
                Skor += 5;
                _arrow.Remove(vuranOk);
                _ballonPanel.Controls.Remove(ballon);
                _ballonPanel.Controls.Remove(vuranOk);
            }
        }
        private void DeleteYellowBallon()
        {
            for (var i = _yellowBallon.Count - 1; i >= 0; i--)
            {
                var ballon = _yellowBallon[i];

                var vuranOk = ballon.IsShot(_arrow);
                if (vuranOk is null) continue;

                _yellowBallon.Remove(ballon);
                Puan += 15;
                Skor += 15;
                _arrow.Remove(vuranOk);
                _ballonPanel.Controls.Remove(ballon);
                _ballonPanel.Controls.Remove(vuranOk);
            }
        }
        private void DeleteRedBallon()
        {
            for (var i = _redBallon.Count - 1; i >= 0; i--)
            {
                var ballon = _redBallon[i];

                var vuranOk = ballon.IsShot(_arrow);
                if (vuranOk is null) continue;

                _redBallon.Remove(ballon);
                  Skor = 0;
                _arrow.Remove(vuranOk);
                _ballonPanel.Controls.Remove(ballon);
                _ballonPanel.Controls.Remove(vuranOk);
            }
        }

        //-----------------------------------------------

         //------------BALONLARIN HAREKETI
        private void MoveBallon()
        {
            foreach (var ballon in _ballon)
            {
               var IsOutOfRange = ballon.MoveIt(Direction.Down);
                if (!IsOutOfRange) continue;

                Bitir();
                break;
            }
        }

        private void MoveYellowBallon()
        {
            for (int i = _yellowBallon.Count - 1; i >= 0; i--)
            {
                var yellowBallon = _yellowBallon[i];
                var IsOutOfRange = yellowBallon.MoveIt(Direction.Down);
                if (IsOutOfRange)
                {
                    _yellowBallon.Remove(yellowBallon);
                    _ballonPanel.Controls.Remove(yellowBallon);
                }
            }
        }
        private void MoveRedBallon()
        {
            for (int i = _redBallon.Count - 1; i >= 0; i--)
            {
                var redBallon = _redBallon[i];
                var IsOutOfRange = redBallon.MoveIt(Direction.Down);
                if (IsOutOfRange)
                {
                    _redBallon.Remove(redBallon);
                    _ballonPanel.Controls.Remove(redBallon);
                }
            }
        }
        //------------------------------------


        //----------BALONLARIN SUREYE GORE OLUSMASI------------


            private void CreateBallonTimer_Tick(object sender, EventArgs e)
        {
            createBallon();
        }

        private void CreateYellowBallonTimer_Tick(object sender, EventArgs e)
        {
            createYellowBallon();

        }
        private void CreateRedBallonTimer_Tick(object sender, EventArgs e)
        {
            createRedBallon();
        }

        //----------------------
        private void MoveArrow()
        {
            for(int i= _arrow.Count-1; i>=0;i--)
            {
                var arrow = _arrow[i];
                var IsOutOfRange = arrow.MoveIt(Direction.Right);
                if(IsOutOfRange)
                {
                    _arrow.Remove(arrow);
                    _ballonPanel.Controls.Remove(arrow);
                }
            }
        }

        public void Start()
        {
            if (IsContinue) return;
            
            IsContinue = true;
            StartTimer();

            createArcher();
            createBallon(); //Basta elimizle bir tane olusturuyoruz.Bu sayede tik olayi daha hizli isleme girer. 
        }
        
        //-----BALONLARIN OLUSMASI-------------
        private void createBallon()
        {
            var ballon = new Ballon(_ballonPanel.Size);
           
            _ballon.Add(ballon);
            _ballonPanel.Controls.Add(ballon);
            
        }
        private void createYellowBallon()
        {
            var yellowBallon = new YellowBallon(_ballonPanel.Size);
            if(puan>100)
            { 
            _yellowBallon.Add(yellowBallon);
            _ballonPanel.Controls.Add(yellowBallon);
            }
        }

        private void createRedBallon()
        {
            var redBallon = new RedBallon(_ballonPanel.Size);
            if (puan > 200)
            {
                _redBallon.Add(redBallon);
                _ballonPanel.Controls.Add(redBallon);
            }
        }
        //--------------------

        private void StartTimer()
        {
            _passTimeTimer.Start();
            _movementTimer.Start();
            _createBallonTimer.Start();
            _createYellowBallonTimer.Start();
            _createRedBallonTimer.Start();
        }
        private void Bitir()
        {
            if (!IsContinue) return;

            IsContinue = false;
            StopTimer();
            MessageBox.Show("PUANINIZ " + Skor);
        }
        private void StopTimer()
        {
            _passTimeTimer.Stop();
            _movementTimer.Stop();
            _createBallonTimer.Stop();
            _createYellowBallonTimer.Stop();
            _createRedBallonTimer.Stop();
        }

        private void createArcher()
        {
            _archer = new Archer(_archerPanel.Height, _archerPanel.Size);
            
            
            _archerPanel.Controls.Add(_archer);
        }
        public int counterArrow = 0; 
        public void Fire()
        {
            if (!IsContinue) return; //Oyun baslamadan mermi olusmasi engelleniyor

            if (puan > 200) // Asama kontrolu puan ile yapiliyor.
            {
                
                if (counterArrow!=50)
                {
                    var arrow = new Arrow(_ballonPanel.Size, _archer.Middle);
                    _arrow.Add(arrow);
                    _ballonPanel.Controls.Add(arrow);
                    counterArrow++;
                }
                else
                {
                    Bitir();
                    
                    MessageBox.Show("MERMI BITTI");
                }
                
            }
            else
            {
                var arrow = new Arrow(_ballonPanel.Size, _archer.Middle);
                _arrow.Add(arrow);
                _ballonPanel.Controls.Add(arrow);
                
            }
        }

        public void moveArcher(Direction direction)
        {
            if (!IsContinue) return; //Oyun baslamadan hareket etmeyi engelliyor

            _archer.MoveIt(direction);
        }
       
        #endregion
        
    }
}
